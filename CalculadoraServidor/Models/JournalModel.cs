using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

/*Operaciones para devulver el modelo */
namespace CalculadoraServidor.Models
{
    public class JournalModel
    {
        /*IdEvi nombre del archivo para abrir y devolver el log */
        public static string PedirJournal(string IdEvi)
        {
            string ruta = "Journal\\" + IdEvi + ".txt";
            string JsonSerializado;
            try
            {
                List<respJournal> ListadoOperaciones = new List<respJournal>();
                respJournal OperacionTupla;
                string[] DatosOperacion;
                using (StreamReader LectorStream = new StreamReader(ruta))
                {
                    while (LectorStream.Peek() >= 0)
                    {
                        /*Split sobre ||, formato guardado en el txt divididos los tres parámetros por || dentro del archivo */
                        DatosOperacion = LectorStream.ReadLine().Split("||");
                        OperacionTupla = new respJournal(DatosOperacion[0], DatosOperacion[1], DatosOperacion[2]);
                        ListadoOperaciones.Add(OperacionTupla);
                    }
                }
                JsonSerializado = JsonConvert.SerializeObject(ListadoOperaciones, Formatting.Indented);
            }
            /*Si el archivo no existe devuelve el error */
            catch (Exception)
            {
                JsonSerializado = crearJson.CrearError("Internal Error", "400", "No se pudo abrir el fichero del usuario");

            }
            JsonSerializado = JsonSerializado.Replace("\\n", string.Empty);
            JsonSerializado = JsonSerializado.Replace("\\r", string.Empty);
            JsonSerializado = JsonSerializado.Replace("\\", string.Empty);
            JsonSerializado = JsonSerializado.Trim('"');
            return JsonSerializado;

        }


    }
}
