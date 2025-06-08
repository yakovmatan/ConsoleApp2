using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Agent
    {
        public int id { get; }
        public string codeName { get; }
        public string realName { get; }
        public string location { get; }
        public string status { get; }
        public int missionCompleted { get; }

        public Agent(int id, string codeName, string realName, string location, string status, int missionCompleted)
        {
            this.id = id;
            this.codeName = codeName;
            this.realName = realName;
            this.location = location;
            this.status = status;
            this.missionCompleted = missionCompleted;
        }
    }
}
