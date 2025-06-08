using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.DAL;
using ConsoleApp2.Models;

namespace ConsoleApp2.Menu
{
    internal class Menu
    {
        private AgentDal Dal = new AgentDal();
        private CreateAgent agent = new CreateAgent();
        public void ShowMenu()
        {
            Console.WriteLine("\n===== Main Menu =====");
            Console.WriteLine("Enter your choose");
            Console.WriteLine("1.Add agents");
            Console.WriteLine("2.Get all agents");
            Console.WriteLine("3.Update agent location");
            Console.WriteLine("4.Delete agent");
            Console.WriteLine("=====================");
            Console.Write("Enter your choice: ");
        }

        public void Choose()
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "0":
                        Dal.Close();
                        Console.WriteLine("Exiting program...");
                        running = false;
                        break;

                    case "1":
                        Agent agent = this.agent.Create();
                        Dal.AddAgent(agent);
                        break;

                    case "2":
                        var list = Dal.GetAllAgents();
                        foreach (var Theagent in list)
                        {
                            Console.WriteLine(Theagent.id);
                            Console.WriteLine(Theagent.codeName);
                            Console.WriteLine(Theagent.realName);
                            Console.WriteLine(Theagent.status);
                            Console.WriteLine(Theagent.location);
                            Console.WriteLine(Theagent.missionCompleted);
                        }
                        break;

                    case "3":
                        int agentId;
                        while (true)
                        {
                            Console.WriteLine("Enter agentId:");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out agentId))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                        }
                        Console.WriteLine("enter new location");
                        string location = Console.ReadLine();
                        Dal.UpdateAgentLocation(agentId, location);
                        break;

                    case "4":
                        int Id;
                        while (true)
                        {
                            Console.WriteLine("Enter agentId:");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out Id))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                        }
                        Dal.DeleteAgent(Id);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
