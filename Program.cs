using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building_OPC_UA
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SCADA Root = new SCADA();
        public static int DefineMode = 1;
        [STAThread]
        static void Main()
        {
            Device PLC_1 = new Device("opc.tcp://192.168.1.201:4840");
            Root.AddDevice(PLC_1);
            Motor MOTOR_1 = new Motor("MOTOR_1", 500);
            Tag MODE = new Tag("MODE", "");
            Tag START = new Tag("START", "");
            Tag STOP = new Tag("STOP", "");
            Tag RESET = new Tag("RESET", "");
            Tag RUNFEEDBACK = new Tag("RUNFEEDBACK", "");
            Tag FAULT = new Tag("FAULT", "");
            MOTOR_1.AddTag(MODE);
            MOTOR_1.AddTag(START);
            MOTOR_1.AddTag(STOP);
            MOTOR_1.AddTag(RESET);
            MOTOR_1.AddTag(RUNFEEDBACK);
            MOTOR_1.AddTag(FAULT);

            Motor MOTOR_2 = new Motor("MOTOR_2", 500);
            MODE = new Tag("MODE", "");
            START = new Tag("START", "");
            STOP = new Tag("STOP", "");
            RESET = new Tag("RESET", "");
            RUNFEEDBACK = new Tag("RUNFEEDBACK", "");
            FAULT = new Tag("FAULT", "");
            MOTOR_2.AddTag(MODE);
            MOTOR_2.AddTag(START);
            MOTOR_2.AddTag(STOP);
            MOTOR_2.AddTag(RESET);
            MOTOR_2.AddTag(RUNFEEDBACK);
            MOTOR_2.AddTag(FAULT);

            Motor MOTOR_3 = new Motor("MOTOR_3", 500);
            MODE = new Tag("MODE", "");
            START = new Tag("START", "");
            STOP = new Tag("STOP", "");
            RESET = new Tag("RESET", "");
            RUNFEEDBACK = new Tag("RUNFEEDBACK", "");
            FAULT = new Tag("FAULT", "");
            MOTOR_3.AddTag(MODE);
            MOTOR_3.AddTag(START);
            MOTOR_3.AddTag(STOP);
            MOTOR_3.AddTag(RESET);
            MOTOR_3.AddTag(RUNFEEDBACK);
            MOTOR_3.AddTag(FAULT);

            Root.AddMotor(MOTOR_1);
            Root.AddMotor(MOTOR_2);
            Root.AddMotor(MOTOR_3);

            Root.RunMotor("MOTOR_1");
            Root.RunMotor("MOTOR_2");
            Root.RunMotor("MOTOR_3");
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OPC_UA());
        }
    }
}
