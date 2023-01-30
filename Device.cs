using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building_OPC_UA;
using Opc.Ua;
using Opc.Ua.Client;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
namespace Building_OPC_UA
{
    public class Device
    {
        const string strCon = @"Data Source=DESKTOP-2KG4JBM;Initial Catalog=OPC_UA;Integrated Security=True";
        public SqlConnection SqlConnect = new SqlConnection(strCon);
        public OPC_UA Parent=new OPC_UA();
        public Motor_Data MOTOR_1 = new Motor_Data();
        public Motor_Data MOTOR_2 = new Motor_Data();
        public Motor_Data MOTOR_3 = new Motor_Data();
        public Session mDeviceSession;
        public UAClientHelperAPI mDeviceClientApi = null;
        public EndpointDescription mSelectedEndpoint;
        public MonitoredItem myMonitoredItem;
        public string mDiscoveryUrl;
        public bool Hi;
        public bool Lo;
        public short Water_Level;
        System.Timers.Timer UpdateTimer = null;
        object Lock=new object();
        
        public Device(string discoveryUrl)
        {
            mDiscoveryUrl = discoveryUrl;
            mDeviceClientApi=new UAClientHelperAPI();
            FindingEndpoints();
            Connect();
            UpdateTimer = new System.Timers.Timer();
            UpdateTimer.Elapsed += UpdateTags;
            UpdateTimer.Start();
        }
        private void UpdateTags(object sender,System.Timers.ElapsedEventArgs e)
        {
            if(mDeviceSession!=null)
            {
                lock(Lock)
                {
                    Hi = Convert.ToBoolean(ReadClass("CTRL_PANEL.HI"));
                    Lo = Convert.ToBoolean(ReadClass("CTRL_PANEL.LO"));
                    Water_Level = Convert.ToInt16(Read("LEVEL"));

                    MOTOR_1.MODE = Convert.ToInt16(ReadClass("MOTOR_1.MODE"));
                    MOTOR_1.START = Convert.ToBoolean(ReadClass("MOTOR_1.START"));
                    MOTOR_1.STOP = Convert.ToBoolean(ReadClass("MOTOR_1.STOP"));
                    MOTOR_1.RESET = Convert.ToBoolean(ReadClass("MOTOR_1.RESET"));
                    MOTOR_1.RUNFEEDBACK = Convert.ToBoolean(ReadClass("MOTOR_1.RUNFEEDBACK"));
                    MOTOR_1.FAULT = Convert.ToBoolean(ReadClass("MOTOR_1.FAULT"));

                    MOTOR_2.MODE = Convert.ToInt16(ReadClass("MOTOR_2.MODE"));
                    MOTOR_2.START = Convert.ToBoolean(ReadClass("MOTOR_2.START"));
                    MOTOR_2.STOP = Convert.ToBoolean(ReadClass("MOTOR_2.STOP"));
                    MOTOR_2.RESET = Convert.ToBoolean(ReadClass("MOTOR_2.RESET"));
                    MOTOR_2.RUNFEEDBACK = Convert.ToBoolean(ReadClass("MOTOR_2.RUNFEEDBACK"));
                    MOTOR_2.FAULT = Convert.ToBoolean(ReadClass("MOTOR_2.FAULT"));

                    MOTOR_3.MODE = Convert.ToInt16(ReadClass("MOTOR_3.MODE"));
                    MOTOR_3.START = Convert.ToBoolean(ReadClass("MOTOR_3.START"));
                    MOTOR_3.STOP = Convert.ToBoolean(ReadClass("MOTOR_3.STOP"));
                    MOTOR_3.RESET = Convert.ToBoolean(ReadClass("MOTOR_3.RESET"));
                    MOTOR_3.RUNFEEDBACK = Convert.ToBoolean(ReadClass("MOTOR_3.RUNFEEDBACK"));
                    MOTOR_3.FAULT = Convert.ToBoolean(ReadClass("MOTOR_3.FAULT"));
                    
                }
                   
                
            }
        }
        public void FindingEndpoints()
        {
            bool foundEndpoints = false;
            try
            {
                ApplicationDescriptionCollection servers = mDeviceClientApi.FindServers(mDiscoveryUrl);
                foreach (ApplicationDescription ad in servers)
                {
                    foreach (string url in ad.DiscoveryUrls)
                    {
                        try
                        {
                            EndpointDescriptionCollection endpoints = mDeviceClientApi.GetEndpoints(url);
                            foundEndpoints = foundEndpoints || endpoints.Count > 0;
                            foreach (EndpointDescription ep in endpoints)
                            {
                                string securityPolicy = ep.SecurityPolicyUri.Remove(0, 42);
                                string key = "[" + ad.ApplicationName + "] " + " [" + ep.SecurityMode + "] " + " [" + securityPolicy + "] " + " [" + ep.EndpointUrl + "]";
                                mSelectedEndpoint = ep;
                            }
                        }
                        catch (ServiceResultException sre)
                        {
                            MessageBox.Show(sre.Message, "Error");
                        }
                    }
                    if (!foundEndpoints)
                    {
                        MessageBox.Show("Could not get any Endpoints", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void Connect()
        {
            try
            {
                mDeviceClientApi.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
                mDeviceClientApi.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);
                if (mSelectedEndpoint != null)
                {
                    mDeviceClientApi.Connect(mSelectedEndpoint, false, null, null).Wait(1);
                    mDeviceSession = mDeviceClientApi.Session;
                    
                }
                else
                {
                    MessageBox.Show("Can't Connect");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message, "Error");
            }
        }

        public void Disconnect()
        {
            UpdateTimer.Stop();

            mDeviceClientApi.Disconnect();
            
        }
        public void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (Parent.InvokeRequired)
            {
                Parent.BeginInvoke(new KeepAliveEventHandler(Notification_KeepAlive), sender, e);
                return;
            }

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(sender, mDeviceSession))
                {
                    return;
                }

                // check for disconnected session.
                if (!ServiceResult.IsGood(e.Status))
                {
                    // try reconnecting using the existing session state
                    mDeviceSession.Reconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }
        }
        public void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            //Handle certificate here
            //To accept a certificate manually move it to the root folder (Start > mmc.exe > add snap-in > certificates)
            //Or handle via UAClientCertForm

            if (Parent.InvokeRequired)
            {
                Parent.BeginInvoke(new CertificateValidationEventHandler(Notification_ServerCertificate), cert, e);
                return;
            }

            try
            {
                //Search for the server's certificate in store; if found -> accept
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509CertificateCollection certCol = store.Certificates.Find(X509FindType.FindByThumbprint, e.Certificate.Thumbprint, true);
                store.Close();
                e.Accept = true;
            }
            catch
            {
                ;
            }
        }

        public void Insert_To_SQL()
        {
            try
            {
                string query = "INSERT INTO Water_Management([level_time],[water_level]) VALUES (@level_time,@water_level)";
                SqlConnect.Open();
                using (SqlCommand command = new SqlCommand(query, SqlConnect))
                {
                    command.Parameters.AddWithValue("@level_time", DateTime.Now);
                    command.Parameters.AddWithValue("@water_level", Water_Level);
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        MessageBox.Show("Cannot insert values to database");
                    }
                    SqlConnect.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw ex;
            }
           
        }
        public void Delete_Data()
        {
            try
            { 
                string query = "DELETE FROM Water_Management";
                SqlConnect.Open();
                using (SqlCommand command=new SqlCommand(query,SqlConnect))
                {
                    command.ExecuteNonQuery();
                    SqlConnect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw ex;
            }
        }
        public object ReadTag(string address)
        {
            object val = null;
            string[] temp = address.Split('.');
            switch (temp[0])
            {
                case "MOTOR_1":
                    switch (temp[1])
                    {
                        case "MODE":
                            val = MOTOR_1.MODE;
                            break;
                        case "START":
                            val = MOTOR_1.START;
                            break;
                        case "STOP":
                            val = MOTOR_1.STOP;
                            break;
                        case "RUNFEEDBACK":
                            val = MOTOR_1.RUNFEEDBACK;
                            break;
                        case "RESET":
                            val = MOTOR_1.RESET;
                            break;
                        case "FAULT":
                            val = MOTOR_1.FAULT;
                            break;
                    }
                    break;
                case "MOTOR_2":
                    switch (temp[1])
                    {
                        case "MODE":
                            val = MOTOR_2.MODE;
                            break;
                        case "START":
                            val = MOTOR_2.START;
                            break;
                        case "STOP":
                            val = MOTOR_2.STOP;
                            break;
                        case "RUNFEEDBACK":
                            val = MOTOR_2.RUNFEEDBACK;
                            break;
                        case "RESET":
                            val = MOTOR_2.RESET;
                            break;
                        case "FAULT":
                            val = MOTOR_2.FAULT;
                            break;
                    }
                    break;
                case "MOTOR_3":
                    switch (temp[1])
                    {
                        case "MODE":
                            val = MOTOR_3.MODE;
                            break;
                        case "START":
                            val = MOTOR_3.START;
                            break;
                        case "STOP":
                            val = MOTOR_3.STOP;
                            break;
                        case "RUNFEEDBACK":
                            val = MOTOR_3.RUNFEEDBACK;
                            break;
                        case "RESET":
                            val = MOTOR_3.RESET;
                            break;
                        case "FAULT":
                            val = MOTOR_3.FAULT;
                            break;
                    }
                    break;
            }
            return val;
        }
        public void WriteTag(string address, object value)
        {
            string[] temp = address.Split('.');
            lock (Lock)
            {
                switch (temp[0])
                {
                    case "MOTOR_1":
                        switch (temp[1])
                        {
                            case "MODE":
                                Write(Convert.ToString(value),temp);
                                break;
                            case "START":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "STOP":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "RESET":
                                Write(Convert.ToString(value), temp);
                                break;
                        }
                        break;
                    case "MOTOR_2":
                        switch (temp[1])
                        {
                            case "MODE":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "START":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "STOP":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "RESET":
                                Write(Convert.ToString(value), temp);
                                break;
                        }
                        break;
                    case "MOTOR_3":
                        switch (temp[1])
                        {
                            case "MODE":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "START":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "STOP":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "RESET":
                                Write(Convert.ToString(value), temp);
                                break;
                        }
                        break;
                    case "CTRL_PANEL":
                        switch (temp[1])
                        {
                            
                            case "START":
                                Write(Convert.ToString(value), temp);
                                break;
                            case "STOP":
                                Write(Convert.ToString(value), temp);
                                break;
                            
                        }
                        break;

                }
            }
        }
        
        public void Write(string value, string[] nodeId)
        {
            List<String> values = new List<string>();
            List<String> nodeIdStrings = new List<string>();
            string framenodeId = $"ns=3;s=\"{nodeId[0]}\".\"{nodeId[1]}\"";
            values.Add(value);
            nodeIdStrings.Add(framenodeId);
            try
            {
                mDeviceClientApi.WriteValues(values, nodeIdStrings);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public object ReadClass(string nodeId)
        {
            object val=new object();
            string[] temp = nodeId.Split('.');
            List<String> nodeIdStrings = new List<string>();
            List<String> values = new List<string>();
            nodeIdStrings.Add($"ns=3;s=\"{temp[0]}\".\"{temp[1]}\"");
            try
            {
                values=mDeviceClientApi.ReadValues(nodeIdStrings);
                val = values.ElementAt<String>(0);
                return val;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }
        public object Read(string nodeId)
        {
            object val = new object();
            List<String> nodeIdStrings = new List<string>();
            List<String> values = new List<string>();
            nodeIdStrings.Add($"ns=3;s=\"{nodeId}\"");
            try
            {
                values = mDeviceClientApi.ReadValues(nodeIdStrings);
                val = values.ElementAt<String>(0);
                return val;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }
        public class Motor_Data
        {
            public short MODE { get; set; }
            public bool START { get; set; }
            public bool STOP { get; set; }
            public bool RESET { get; set; }
            public bool RUNFEEDBACK { get; set; }
            public bool FAULT { get; set; }
        }
    }
}
