using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;


namespace ConsoleApp2
{
    class Class1
    {
        public static void BuildList(string a, string b, string c, string d, string e)
        {
            Console.WriteLine("Your Selected IP Range is " + a + " through " + b + ". Is this correct?");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                //build list of all IPs in range 
                int numIpRange1 = Convert.ToInt32(c);
                int numIpRange2 = Convert.ToInt32(d);
                List<string> ipList = new List<string>();
                for (int i = 0; i <= (numIpRange2 - numIpRange1); i++)
                {
                    ipList.Add(e + "." + (i + numIpRange1).ToString());

                }
                Console.WriteLine(string.Join(", \n", ipList));
                Console.ReadLine();

                //send IP list to pingip method
                PingIp(ipList);
            }
        }
        //method for pinging IP
        public static void PingIp(List<String> a)
        {
            //Ping ip addresses in the list.
            try
            {
                Ping p = new Ping();
                for(int i = 0; i < a.Count; i++)
                {
                    PingReply pr = p.Send(a[i], 5000);
                    if (pr != null)
                    {
                        Console.WriteLine("Status: " + pr.Status + " Time: " + pr.RoundtripTime.ToString() + " Address: " + pr.Address);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Danger Will Robinson, Danger! Time out has occurred.");
            }
        }
    }
}
