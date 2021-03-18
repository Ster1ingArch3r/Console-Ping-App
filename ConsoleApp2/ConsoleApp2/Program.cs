using System;
using System.Text.RegularExpressions;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //get IP info from user.
                Console.WriteLine("Please enter the IP address Range: ");
                Console.WriteLine("IP Address Base (0.0.0)");
                string baseIp = Console.ReadLine();
                Console.WriteLine("Enter the final octet of the IP Addresses.");
                Console.WriteLine("IP Address 1: ");
                string ipRange1 = Console.ReadLine();
                Console.WriteLine("IP Address 2:");
                string ipRange2 = Console.ReadLine();


                string fullIp1 = baseIp + "." + ipRange1;
                string fullIp2 = baseIp + "." + ipRange2;

                //Checks the inputed values before moving on. 
                static bool validip(string a, string b)
                {
                    string pattern = @"([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
                    Regex check = new Regex(pattern);
                    if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                    {
                        
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("IP Addresses are valid.");
                        return true;
                    }
                }
                if (validip(fullIp1, fullIp2) == true)
                {
                    Class1.BuildList(fullIp1, fullIp2, ipRange1, ipRange2, baseIp);
                }
                else
                {
                    break;
                }

                Console.WriteLine("Would you like to continue? (Y/N)");

                string ans = Console.ReadLine();

                if (ans == "n" || ans == "N")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
