using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> Address = new Dictionary<string, string[]>();

            string name;
            bool cont = true;
            bool type = true;
            string input;

            while (cont)
            {
                string[] info = new string[2];
                type = true;
                while (type)
                {
                    Console.WriteLine("This is an address book. If you want to add Type a if you want t view type v. It must be lower case.");
                    Console.Write("Type your input: ");
                    input = Console.ReadLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    if (input == "a")
                    {
                        type = false;
                        Console.Write("Type your name: ");
                        name = Console.ReadLine();
                        Console.Write("Type your number: ");
                        info[0] = Console.ReadLine();
                        Console.Write("Type Your address: ");
                        info[1] = Console.ReadLine();
                        Address.Add(name, info);                

                    }
                    else if (input == "v")
                    {
                        Console.WriteLine("Name" + "\t" + "Number" + "\t" + "Address");
                        type = false;
                        foreach(KeyValuePair<string, string[]> kvp in Address)
                        {
                            Console.Write(kvp.Key + "\t");
                            for(int x = 0; x < 2; x++)
                            {
                                Console.Write(kvp.Value[x] + "\t");
                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("wrong input");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press anything to continue");
                    Console.ReadKey();
                }
                
            }
            Console.ReadKey();



        }
    }
}
