using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;
using MySql.Data.MySqlClient;

namespace ConsoleApp2.DAL
{
    internal class AgentDal
    {
        private string ConnStr = "server=localhost;username=root;password=;database=eagleeyedb";
        private MySqlConnection Conn;

        public AgentDal()
        {
            this.Conn = new MySqlConnection(this.ConnStr);
            this.Connection();
        }

        public void Connection()
        {
            Conn.Open();
            Console.WriteLine("connection success");
        }

        public MySqlCommand Command(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, this.Conn);
            return cmd;
        }

        public void AddAgent(Agent agent)
        {
            string query = $"INSERT INTO agents (codeName,realName,location,status,missiionCompleted) VALUES({agent.codeName}, {agent.realName}, {agent.location}, {agent.status}, {agent.missiionCompleted});";
            var cmd = this.Command(query);
            cmd.ExecuteNonQuery();
        }

        public List<Agent> GetAllAgents()
        {
            List<Agent> allAgentes = new List<Agent>();
            string query = "SELECT * FROM agents";
            var cmd = this.Command(query);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Agent agent = new Agent(
                    reader.GetInt32("id"),
                    reader.GetString("codeName"),
                    reader.GetString("realName"),
                    reader.GetString("location"),
                    reader.GetString("status"),
                    reader.GetInt32("missiionCompleted")
                    );
                allAgentes.Add(agent);
            }
            return allAgentes;
        }

        public void UpdateAgentLocation(int agantId,string newLocation)
        {
            string query = $"UPDATE agents SET location = {newLocation} WHERE id = {agantId}";
            var cmd = this.Command(query);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAgent(int agentId)
        {
            string query = $"DELETE FROM agents WHERE id = {agentId}";
            var cmd = this.Command(query);
            cmd.ExecuteNonQuery();
        }

    }
}
