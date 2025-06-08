using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;
using MySql.Data.MySqlClient;
using Mysqlx;

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

        public void Close()
        {
            Conn.Close();
        }

        public MySqlCommand Command(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, this.Conn);
            return cmd;
        }

        public void AddAgent(Agent agent)
        {
            string query = @"INSERT INTO agents (codeName, realName, location, status, missionCompleted)
                     VALUES (@codeName, @realName, @location, @status, @missionCompleted)";
            try
            {
                var cmd = this.Command(query);
                cmd.Parameters.AddWithValue("@codeName", agent.codeName);
                cmd.Parameters.AddWithValue("@realName", agent.realName);
                cmd.Parameters.AddWithValue("@location", agent.location);
                cmd.Parameters.AddWithValue("@status", agent.status);
                cmd.Parameters.AddWithValue("@missionCompleted", agent.missionCompleted);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding agent: " + ex.Message);
            }
        }



        public List<Agent> GetAllAgents()
        {
            List<Agent> allAgentes = new List<Agent>();
            string query = "SELECT * FROM agents";
            try
            {
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
                        reader.GetInt32("missionCompleted")
                        );
                    allAgentes.Add(agent);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving agents: " + ex.Message);
            }
            return allAgentes;
        }

        public void UpdateAgentLocation(int agentId,string newLocation)
        {
            string query = "UPDATE agents SET location = @location WHERE id = @id";

            try
            {
                var cmd = this.Command(query);
                cmd.Parameters.AddWithValue("@location", newLocation);
                cmd.Parameters.AddWithValue("@id", agentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating location: " + ex.Message);
            }
        }

        public void DeleteAgent(int agentId)
        {
            string query = "DELETE FROM agents WHERE id = @id";

            try
            {
                var cmd = this.Command(query);
                cmd.Parameters.AddWithValue("@id", agentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting agent: " + ex.Message);
            }
        }

    }
}
