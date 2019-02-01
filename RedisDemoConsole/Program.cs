using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Configuration;

namespace RedisDemoConsole
{
    class Program
    {

        //This is Sample redis Console Application wich send Ping to the Azure Redis
        // Please update the cacheConnection at Line 32
        static void Main(string[] args)
        {
            
            IDatabase cache = lazyConnection.Value.GetDatabase();
           
            for (int ctr = 0; ctr < 50; ctr++)
            {              

                string cacheCommand = "PING";
                Console.WriteLine("\nCache command  : " + cacheCommand + " : "+ ctr.ToString());
                Console.WriteLine("Cache response : " + cache.Execute(cacheCommand).ToString() + " : " + ctr.ToString());
            }

            Console.ReadLine();
        }


        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = "127.0.0.1:6379,abortConnect=False";// Replace this by Azure Redis access Key.
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }


}
