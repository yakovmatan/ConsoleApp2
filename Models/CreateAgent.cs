using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class CreateAgent
    {
        private int num = 0;
        public Agent Create()
        {
            num++;
            Agent agent = new Agent(num, $"carot{num}", $"yakov{num}", $"galil{num}", "active", num);
            return agent;
        }
    }
}
