using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Sockets;
namespace Building_OPC_UA
{
    public partial class OPC_UA : Form
    {
        Image ButtonStartUp = Image.FromFile(@"images\btStartup.png");
        Image ButtonStartDown = Image.FromFile(@"images\btStartdown.png");
        Image ButtonStopUp = Image.FromFile(@"images\btStopup.png");
        Image ButtonStopDown = Image.FromFile(@"images\btStopdown.png");
        Image GreyLight = Image.FromFile(@"images\gray_light.png");
        Image GreenLight = Image.FromFile(@"images\green_light.png");
        Image RedSensor = Image.FromFile(@"images\SensorRed.png");
        Image GreySensor = Image.FromFile(@"images\SensorGrey.png");
        Image RedSensorHi = Image.FromFile(@"images\SensorRedHI.png");
        Image GreySensorHi = Image.FromFile(@"images\SensorGreyHI.png");
        Image YellowLight = Image.FromFile(@"images\yellow_light.png");
        Image Tank = Image.FromFile(@"images\tank.png");
        Image MotorOn = Image.FromFile(@"images\MotorOn.png");
        Image MotorOff = Image.FromFile(@"images\MotorOff.png");
        Image Motor3On = Image.FromFile(@"images\motor3on.png");
        Image Motor3Off = Image.FromFile(@"images\motor3off.png");
        Image BlackBar = Image.FromFile(@"images\blackbar.png");
        Image BlueBar = Image.FromFile(@"images\bluebar.png");
        Image Pipe = Image.FromFile(@"images\pipe.gif");
       

        public OPC_UA()
        {
            InitializeComponent();
            
        }

        private void OPC_UA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oPC_UADataSet.Water_Management' table. You can move, or remove it, as needed.
           
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            pbTank.BackgroundImage = Tank;
            pbTank.BackColor = Color.Transparent;
            pbTank.BackgroundImageLayout = ImageLayout.Stretch;

            pbMotor_1.BackgroundImage = MotorOff;
            pbMotor_1.BackColor = Color.Transparent;
            pbMotor_1.BackgroundImageLayout = ImageLayout.Stretch;

            pbMotor_2.BackgroundImage = MotorOff;
            pbMotor_2.BackColor = Color.Transparent;
            pbMotor_2.BackgroundImageLayout = ImageLayout.Stretch;

            pbMotor_3.BackgroundImage = Motor3Off;
            pbMotor_3.BackColor = Color.Transparent;
            pbMotor_3.BackgroundImageLayout = ImageLayout.Stretch;

            pbSenHi.BackgroundImage = GreySensorHi;
            pbSenHi.BackColor = Color.Transparent;
            pbSenHi.BackgroundImageLayout = ImageLayout.Stretch;

            pbSenLo.BackgroundImage = GreySensor;
            pbSenLo.BackColor = Color.Transparent;
            pbSenLo.BackgroundImageLayout = ImageLayout.Stretch;

            pbStart.BackgroundImage = ButtonStartUp;
            pbStart.BackColor = Color.Transparent;
            pbStart.BackgroundImageLayout = ImageLayout.Stretch;

            pbStop.BackgroundImage = ButtonStopUp;
            pbStop.BackColor = Color.Transparent;
            pbStop.BackgroundImageLayout = ImageLayout.Stretch;

            UpdateTimer.Start();
            Read_Data.Start();

        }
       

        private void OPC_UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateTimer.Stop();
            Program.Root.Devices[0].Disconnect();
            Read_Data.Stop();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lbWaterLevel.Text = Convert.ToString(Program.Root.Devices[0].Water_Level);
            pbLevel.Value = Program.Root.Devices[0].Water_Level;
            if (Convert.ToBoolean(Program.Root.FindMotor("MOTOR_1").FindTag("RUNFEEDBACK").Value) == true)
            {
                pbMotor_1.BackgroundImage = MotorOn;
            }
            else
            {
                pbMotor_1.BackgroundImage = MotorOff;
            }
            if (Convert.ToBoolean(Program.Root.FindMotor("MOTOR_2").FindTag("RUNFEEDBACK").Value) == true)
            {
                pbMotor_2.BackgroundImage = MotorOn;
            }
            else
            {
                pbMotor_2.BackgroundImage = MotorOff;
            }
          
            if (Convert.ToBoolean(Program.Root.Devices[0].Hi) == true)
            {
                pbSenHi.BackgroundImage = RedSensorHi;
            }
            else
            {
                pbSenHi.BackgroundImage = GreySensorHi;
            }
            if (Convert.ToBoolean(Program.Root.Devices[0].Lo) == true)
            {
                pbSenLo.BackgroundImage = RedSensor;
            }
            else
            {
                pbSenLo.BackgroundImage = GreySensor;
            }
            if (Convert.ToBoolean(Program.Root.FindMotor("MOTOR_3").FindTag("RUNFEEDBACK").Value) == true)
            {
                pbMotor_3.BackgroundImage = Motor3On;
            }
            else
            {
                pbMotor_3.BackgroundImage = Motor3Off;
            }
        }

        private void pbStart_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Root.Devices[0].WriteTag("CTRL_PANEL.START", true);
            pbStart.BackgroundImage = ButtonStartDown;
        }

        private void pbStart_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Root.Devices[0].WriteTag("CTRL_PANEL.START", false);
            pbStart.BackgroundImage = ButtonStartUp;
        }

        private void pbStop_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Root.Devices[0].WriteTag("CTRL_PANEL.STOP", true);
            pbStop.BackgroundImage = ButtonStopDown;
        }

        private void pbStop_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Root.Devices[0].WriteTag("CTRL_PANEL.STOP", false);
            pbStop.BackgroundImage = ButtonStopUp;
        }
        public Control fpl1 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_1")); 
        public Control fpl2 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_2"));
        public Control fpl3 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_3"));
        private void pbMotor_1_Click(object sender, EventArgs e)
        {
            if(!fpl1.IsDisposed)
                fpl1.Show();
            else
            {
                fpl1 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_1"));
                fpl1.Show();
            }
                

        }

        private void pbMotor_2_Click(object sender, EventArgs e)
        {
            if (!fpl2.IsDisposed)
                fpl2.Show();
            else
            {
                fpl2 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_2"));
                fpl2.Show();
            }
        }

        private void pbMotor_3_Click(object sender, EventArgs e)
        {
            if (!fpl3.IsDisposed)
                fpl3.Show();
            else
            {
                fpl3 = new Motor_Faceplates(Program.Root.FindMotor("MOTOR_3"));
                fpl3.Show();
            }
        }

        private void Read_Data_Tick(object sender, EventArgs e)
        {
            Program.Root.Devices[0].Insert_To_SQL();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Program.Root.Devices[0].Delete_Data();
        }
    }
}
