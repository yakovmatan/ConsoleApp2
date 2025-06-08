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
        private static readonly Random Random = new Random();

        public string CodeName()
        {
            string[] codeNames = new string[]
            {
                "ShadowFox",
                "IronSpecter",
                "NightOwl",
                "GhostViper",
                "CrimsonHawk"
            };
            return codeNames[Random.Next(codeNames.Length)];

        }

        public string RealName()
        {
            string[] realNames = new string[]
            {
                "josh",
                "Ethan Drake",
                "Natalie Pierce",
                "Samuel Cross",
                "Lena Hart",
                "Victor Kane"
            };
            return realNames[Random.Next(realNames.Length)];
        }

        public string Location()
        {
            string[] locations = new string[]
            {
                "Berlin, Germany",
                "Tehran, Iran",
                "Istanbul, Turkey",
                "Moscow, Russia",
                "Beirut, Lebanon",
                "London, UK",
                "Dubai, UAE",
                "Cairo, Egypt",
                "Kyiv, Ukraine",
                "Riyadh, Saudi Arabia"
            };
            return locations[Random.Next(locations.Length)];
        }

        public string Status()
        {
            string[] statuses = new string[]
            {
                "Active",
                "injured",
                "Missing",
                "Retired"
            };
            return statuses[Random.Next(statuses.Length)];
        }

        public int MissionCompleted()
        {
            return Random.Next(100, 1000);
        }
        public Agent Create()
        {
            num++;
            string codeName = CodeName();
            string realName = RealName();
            string location = Location();
            string status = Status();
            int missionCompleted = MissionCompleted();
            Agent agent = new Agent(codeName, realName, location, status, missionCompleted);
           
            return agent;
        }
    }
}
