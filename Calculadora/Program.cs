using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;



namespace Calculadora
{
    class Program
    {
        public static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            menus.menu();
        }


        
    
    }

}
