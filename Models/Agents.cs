using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Agents
    {
        private int id;
        private string codeName;
        private string realName;
        private string location;
        private string status;
        private int missiionCompleted;

        public Agents(int id, string codeName, string realName, string location, string status, int missiionCompleted)
        {
            this.id = id;
            this.codeName = codeName;
            this.realName = realName;
            this.location = location;
            this.status = status;
            this.missiionCompleted = missiionCompleted;
        }
    }
}
