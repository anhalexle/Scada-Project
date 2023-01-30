using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_OPC_UA
{
    public class SCADA
    {
        public List<Motor> Motors = new List<Motor>();
        public List<Device> Devices = new List<Device>();

        public SCADA()
        {

        }
        public void AddMotor(Motor motor)
        {
            motor.Parent = this;
            Motors.Add(motor);
        }

        public Motor FindMotor(string name)
        {
            foreach (Motor motor in Motors)
            {
                if (motor.Name == name)
                    return motor;
            }
            return null;
        }

        public void RunMotor(string name)
        {
            foreach (Motor motor in Motors)
            {
                if (motor.Name == name)
                    motor.Engine();
            }
        }
        public void AddDevice(Device dev)
        {
            Devices.Add(dev);
        }
    }
}
