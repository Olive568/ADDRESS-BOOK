using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> Address = new Dictionary<string, string[]>();

            string[] Dic = new string[] { };
            string name;
            bool cont = true;
            bool type = true;
            string input;
            string Lines;
            string outputfilname = "Addressbook.txt";
            bool append = true;
            string orig = "";
            string line = "";
           

            using (StreamReader sr = new StreamReader("AddressBook.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] val = new string[2];
                    Lines = sr.ReadLine();
                    Dic = line.Split(",");
                    int y = 0;
                    for (int x = 1; x < Dic.Length -1; x++)
                    {
                        val[y] = Dic[x];
                        y++;
                    }
                    Address.Add(Dic[0], val);
                }
            }
           
            while (cont)
            {
                Console.WriteLine("There are " + Address.Count + " Entries");
                string[] info = new string[2];
                type = true;
                while (type)
                {
                    Console.WriteLine("This is an address book. If you want to add Type a if you want t view type v and c to end the program. It must be lower case.");
                    Console.Write("Type your input: ");
                    input = Console.ReadLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    if (input == "a")
                    {
                        Console.Clear();
                        type = false;
                        Console.Write("Type your name: ");
                        name = Console.ReadLine();
                        Console.Write("Type your number: ");
                        info[0] = Console.ReadLine();
                        Console.Write("Type Your address: ");
                        info[1] = Console.ReadLine();
                        Address.Add(name, info);

                        using (StreamWriter sw = new StreamWriter(outputfilname, append))
                        {
                            foreach (KeyValuePair < string,string[]> kvp in Address)
                            {
                                sw.Write(kvp.Key + ",");
                                for(int i = 0; i < kvp.Value.Length; i++)
                                {
                                    sw.Write(kvp.Value[i] + ",");
                                }
                                sw.WriteLine();
                            }
                        }
                    }
                    else if (input == "v")
                    {
                        Console.Clear();
                        Console.WriteLine("Name" + "\t" + "Number" + "\t" + "Address");
                        type = false;
                        foreach (KeyValuePair<string, string[]> kvp in Address)
                        {
                            Console.Write(kvp.Key + "\t");
                            for (int x = 0; x < 2; x++)
                            {
                                Console.Write(kvp.Value[x] + "\t");
                            }
                            Console.WriteLine("");

                        }
                    }
                    else if (input == "c")
                    {                        
                        cont = false;
                        type = false;
                        Console.WriteLine("Exiting Program");
                        break;
                    }

                    
                    else
                    {
                        Console.WriteLine("wrong input");
                    }
                    Console.WriteLine();
                    
                }
                
            }
            Console.ReadKey();



        }
    }
}
