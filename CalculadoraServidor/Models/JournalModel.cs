using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

/*Operaciones para devulver el modelo */
namespace CalculadoraServidor.Models
{
    public class JournalModel
    {
        /*IdEvi nombre del archivo para abrir y devolver el log */
        public static object PedirJournal(string IdEvi)
        {
            string ruta = $"Journal\\{IdEvi}.txt";
            /*Se realizan 15 intentos de abrir el fichero con un delay de 200ms, para evitar casos en 
            los que el fichero este ya en uso */
            respJournal[] ListadoOperaciones = new respJournal[0];
            for (int a = 0; a < 15; a++)
            {

                try
                {
                    ListadoOperaciones = new respJournal[File.ReadLines(ruta).Count()];
                    respJournal OperacionTupla;
                    string[] DatosOperacion;
                    using (StreamReader LectorStream = new StreamReader(ruta))
                    {
                        int fila = 0;
                        while (LectorStream.Peek() >= 0)
                        {
                            /*Split sobre ||, formato guardado en el txt divididos los tres parámetros por || dentro del archivo */
                            DatosOperacion = LectorStream.ReadLine().Split("||");
                            OperacionTupla = new respJournal(DatosOperacion[0], DatosOperacion[1], DatosOperacion[2]);
                            ListadoOperaciones[fila] = OperacionTupla;
                            fila++;
                        }
                    }
                    a = 15;
                }
                /*Si el archivo no existe devuelve el error */
                catch (Exception)
                {

                }
            }
            respJournalConjunta ObjetoOperacionesConjuntas = new respJournalConjunta(ListadoOperaciones);
            return ObjetoOperacionesConjuntas;

        }
    }
}
