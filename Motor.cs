using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_OPC_UA
{
    public class Motor
    {
        public string Name;
        public int Period;
        System.Timers.Timer UpdateTimer = null;
        public List<Tag> Tags = new List<Tag>();
        public SCADA Parent;
        public Motor (string name, int period)
        {
            Name = name;
            Period = period;
        }
        public void AddTag(Tag tag)
        {
            tag.Parents = this;
            Tags.Add(tag);
        }

        public Tag FindTag(string name)
        {
            foreach(Tag tag in Tags)
            {
                if (tag.Name == name)
                    return tag;
            }
            return null;
        }

        public void Engine()
        {
            UpdateTimer = new System.Timers.Timer(Period);
            UpdateTimer.Elapsed += UpdateTags;
            UpdateTimer.Start();
        }

        public void Sleep()
        {
            if(UpdateTimer!=null)
            {
                UpdateTimer.Stop();
            }
        }

        public void Resume()
        {
            if(UpdateTimer!=null)
            {
                UpdateTimer.Start();
            }
        }

        public void Kill()
        {
            if(UpdateTimer!=null)
            {
                UpdateTimer.Dispose();
                UpdateTimer = null;
            }    
        }

        public void UpdateTags(object sender, System.Timers.ElapsedEventArgs e)
        {
            Tag tag = null;
            for (int i=0;i<Tags.Count;i++)
            {
                tag = Tags[i];
                tag.Value = Parent.Devices[0].ReadTag($"{Name}.{tag.Name}");
                tag.TimeStamp = DateTime.Now;
            }
        }

        private void MonitorTags(object sender, System.Timers.ElapsedEventArgs e)
        {
            Tag tag = null;
            for (int i = 0; i < Tags.Count; i++)
            {
                tag = Tags[i];
                Console.WriteLine($"Tag Name = {tag.Name} TimeStamp = {tag.TimeStamp} Value = {tag.Value}");
            }
        }
        public void WriteTag(string address, object value)
        {
            Parent.Devices[0].WriteTag($"{Name}.{address}", value); //$ before a string equal String.Format(Name.value) aka string interpolation
        }
    }
}
