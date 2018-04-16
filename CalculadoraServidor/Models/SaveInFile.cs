
using System;
using System.IO;

/*Calculo para guardar el journal en un archivo */
class saveInFile
{
    public static void GuardarOperaciones(string Id, string Operacion, string tiempo, string tipoOp)
    {
        string archivoRut = "Journal\\" + Id + ".txt";
        //Crear archivo
        FileStream ArchivoOperaciones = new FileStream(archivoRut, FileMode.Append, FileAccess.Write);

        StreamWriter sw1 = new StreamWriter(ArchivoOperaciones);
        /*Escribir datos del archivo separando variables por || y nuevas operaciones por salto de linea */
        sw1.Write(tiempo + "||" + tipoOp + "||" + Operacion + Environment.NewLine);
        sw1.Close();
        ArchivoOperaciones.Close();


    }



}