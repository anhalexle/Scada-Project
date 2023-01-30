using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building_OPC_UA
{
    public partial class Motor_Faceplates : Form
    {
        Image GreyLight = Image.FromFile(@"images\gray_light.png");
        Image GreenLight = Image.FromFile(@"images\green_light.png");
        Image YellowLight = Image.FromFile(@"images\yellow_light.png");
        public Motor Parent;
        
        public string MotorName;
        public int FindMode = Program.DefineMode;
        
        public Motor_Faceplates(Motor parent)
        {
            if (parent!=null)
            {
                Parent = parent;
                MotorName = Parent.Name;
                InitializeComponent();
            }
           
        }

        private void Motor_Faceplates_Load(object sender, EventArgs e)
        {
            this.Text = MotorName;
            pbRunFeedback.BackgroundImage = GreyLight;
            pbRunFeedback.BackColor = Color.Transparent;
            pbRunFeedback.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            pbFault.BackgroundImage = GreyLight;
            pbFault.BackColor = Color.Transparent;
            pbFault.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateMode();
            CheckRunFeedBack();
            CheckFault();
            cbMode.SelectedIndex = Program.DefineMode-1;
            SelectMode();
        }
        private void SelectMode()
        {
            UpdateTimer.Stop();
            if (cbMode.SelectedIndex == 0)
            {
                ushort value = 1;
                Program.Root.Devices[0].WriteTag($"{Parent.Name}.MODE", value);

            }
            if (cbMode.SelectedIndex == 1)
            {
                ushort value = 2;
                Program.Root.Devices[0].WriteTag($"{Parent.Name}.MODE", value);

            }
            UpdateTimer.Start();
        }
        private void UpdateMode()
        {

            if (Convert.ToInt32(Parent.FindTag("MODE").Value) != FindMode)
            {
                FindMode = Convert.ToInt32(Parent.FindTag("MODE").Value);
                if (FindMode == 1)
                {
                    cbMode.SelectedIndex = 0;
                }
                else if (FindMode == 2)
                {
                    cbMode.SelectedIndex = 1;
                }

            }
        }
        private void CheckRunFeedBack()
        {
            if (Convert.ToBoolean(Parent.FindTag("RUNFEEDBACK").Value) == true)
            {
                pbRunFeedback.BackgroundImage = GreenLight;
                pbRunFeedback.BringToFront();
                pbRunFeedback.Update();
                pbRunFeedback.Show();
            }
            else if (Convert.ToBoolean(Parent.FindTag("RUNFEEDBACK").Value) == false)
            {
                pbRunFeedback.BackgroundImage = GreyLight;
                //pbRunfeedback.SendToBack();
                pbRunFeedback.Update();
                pbRunFeedback.Show();
            }
        }
        private void CheckFault()
        {
            if (Convert.ToBoolean(Parent.FindTag("FAULT").Value) == true)
            {
                pbFault.BackgroundImage = YellowLight;
                pbFault.Update();
                pbFault.Show();
            }
            else if (Convert.ToBoolean(Parent.FindTag("FAULT").Value) == false)
            {
                pbFault.BackgroundImage = GreyLight;
                pbFault.Update();
                pbFault.Show();
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            CheckRunFeedBack();
            CheckFault();
            SelectMode();
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMode();
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("START", true);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("START", false);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("STOP", true);
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("STOP", false);
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("RESET", true);
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.WriteTag("RESET", false);
        }

        private void Motor_Faceplates_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(MotorName)
            {
                case "MOTOR_1":
                    {
                        if (!Program.Root.Devices[0].Parent.fpl1.IsDisposed)
                        {
                            Program.Root.Devices[0].Parent.fpl1.Hide();
                            Program.Root.Devices[0].Parent.fpl1.Dispose();
                        }
                        break;
                    }
                case "MOTOR_2":
                    {
                        if (!Program.Root.Devices[0].Parent.fpl2.IsDisposed)
                        {
                            Program.Root.Devices[0].Parent.fpl2.Hide();
                            Program.Root.Devices[0].Parent.fpl2.Dispose();
                        }
                        break;
                    }
                case "MOTOR_3":
                    {
                        if (!Program.Root.Devices[0].Parent.fpl3.IsDisposed)
                        {
                            Program.Root.Devices[0].Parent.fpl3.Hide();
                            Program.Root.Devices[0].Parent.fpl3.Dispose();
                        }
                        break;
                    }

            }
            Program.DefineMode = cbMode.SelectedIndex + 1;
            UpdateTimer.Stop();
            

        }
       
    }
}
