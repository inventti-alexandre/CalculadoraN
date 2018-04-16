
using System;
using System.IO;

/*Calculo para guardar el journal en un archivo */
class saveInFile
{
    public static void GuardarOperaciones(string Id, string Operacion, string tiempo, string tipoOp)
    {
        string archivoRut = $"Journal\\{Id}.txt";
        /*Se realizan 15 intentos de abrir el fichero con un delay de 200ms, para evitar casos en 
            los que el fichero este ya en uso */
        for (int a = 0; a < 10; a++)
        {
            try
            {
                FileStream ArchivoOperaciones = new FileStream(archivoRut, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

                StreamWriter sw1 = new StreamWriter(ArchivoOperaciones);
                /*Escribir datos del archivo separando variables por || y nuevas operaciones por salto de linea */
                sw1.Write($"{tiempo}||{tipoOp}||{Operacion}{Environment.NewLine}");
                sw1.Close();
                ArchivoOperaciones.Close();
                a = 10;
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(200);
            }
        }

    }



}