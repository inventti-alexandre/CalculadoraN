
using System;
using System.IO;

class saveInFile
{
    public static void GuardarOperaciones(string Id, string Operacion, string tiempo, string tipoOp)
    {
        string archivoRut = "Journal\\" + Id + ".txt"; 
        //Crear archivo
        FileStream ArchivoOperaciones = new FileStream(archivoRut, FileMode.Append, FileAccess.Write);
            // Create a new stream to write to the file
        StreamWriter sw1 = new StreamWriter(ArchivoOperaciones);
            // Write a string to the file
        sw1.Write(tiempo + "||" + tipoOp + "||" + Operacion+ Environment.NewLine);
            // Close StreamWriter
        sw1.Close();
            // Close file
        ArchivoOperaciones.Close();


    }



}