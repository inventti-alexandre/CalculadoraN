using System;
using System.Runtime.Serialization.Json;
using System.IO;
namespace CalculadoraServidor.Models
{
    public class SubModel
    {
       

        public static string restar(ObjResta datosResta, string EviId)
        {
            double minuendo = datosResta.GetMinuend();
            double [] sustraendo = datosResta.GetSubtrahend();
            string OperacionSt = "" + minuendo;
            for(int a = 0; a < sustraendo.Length; a++)
            {
                minuendo = minuendo - sustraendo[a];
                if(a < (sustraendo.Length-1)) OperacionSt = OperacionSt + sustraendo[a]+" - ";
                else OperacionSt = OperacionSt + sustraendo[a] + " = ";
            }
            OperacionSt = OperacionSt + minuendo;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId,OperacionSt,tiempo,"Res");
            return crearJson.Crear(2,minuendo);

        }
    }
}