using System;
using System.Security.Cryptography;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace testCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            string id = conversion("a1");
            string id2 = conversion("a3");
            string servidor = "http://localhost:5000";
            string jsonSuma = crearJson(rnd);
            string jsonSuma2 = crearJson(rnd);
            string jsonSuma3 = crearJson(rnd);
            string jsonConsulta = crearJsonJournal(id);
            string jsonConsulta2 = crearJsonJournal(id2);
           

            llamadas[] ListaLlamadas = new llamadas[5];
            for(int a = 0; a < 5; a++)
            {
            ListaLlamadas[a] = new llamadas();
            }
            /*Test de soporte de carga de servidor */
            for(int a = 0; a < 1000; a++)
            {
                ListaLlamadas[0].responder($"{servidor}/Calculator/Add", jsonSuma, id);               
                ListaLlamadas[1].responder($"{servidor}/Calculator/Add", jsonSuma2, id);
                ListaLlamadas[3].responder($"{servidor}/Calculator/Journal", jsonConsulta, id);                
                ListaLlamadas[1].responder($"{servidor}/Calculator/Add", jsonSuma3, id);
                ListaLlamadas[4].responder($"{servidor}/Calculator/Journal", jsonConsulta2, id);
                Thread.Sleep(50);
                
                
            }


        }
        public static string crearJson(Random rnd)
        {
            JArray array = new JArray();
            array.Add( rnd.Next(1, 100));
            array.Add(rnd.Next(1, 100));
            array.Add(rnd.Next(1, 100));
            array.Add(rnd.Next(1, 100));
            JObject o = new JObject();
            o["Addens"] = array;
            string JsonCompleto = o.ToString();
            return JsonCompleto;
        }
        public static string crearJsonJournal(string id)
        {
            JObject o = new JObject();
            o["Id"] = id;
            string JsonCompleto = o.ToString();
            return JsonCompleto;
        }


         public static string conversion(string Id)
        {
            using (var algorithm = SHA512.Create()) //or MD5 SHA256 etc.
            {
                var IdHash = algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Id));
                return BitConverter.ToString(IdHash).Replace("-", "").ToLower();
            }

        }

    }
}

