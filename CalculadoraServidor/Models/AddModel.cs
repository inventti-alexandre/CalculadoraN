using System;
using System.Runtime.Serialization.Json;
using System.IO;
namespace CalculadoraServidor.Models
{
    public class AddModel
    {
       

        public static string sumar(Objsuma datosSuma, string EviId)
        {
            double[] DatosT = datosSuma.GetSumandos();
            double resultadoD = 0;
            string OperacionSt = "";
            for(var a = 0; a < DatosT.Length; a++)
            {
                resultadoD = resultadoD + DatosT[a];
                if(a < ( DatosT.Length - 1)) OperacionSt = OperacionSt + DatosT[a] + " + ";
                else  OperacionSt = OperacionSt + DatosT[a] + " = ";
            }
            OperacionSt = OperacionSt + resultadoD;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId,OperacionSt,tiempo,"Sum");
            
            return crearJson.Crear(1,resultadoD);

        }
    }
}


