using System;
using System.Runtime.Serialization.Json;
using System.IO;
namespace CalculadoraServidor.Models
{
    public class SqrModel
    {
       

        public static string RaizCuadrada(ObjSqr datos, string EviId)
        {

            double DatosT = datos.GetNumber();
            double  resultado = Math.Sqrt(DatosT);
            string OperacionSt = DatosT + " Sqrt = " + resultado;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId,OperacionSt,tiempo,"Sqr");

            return crearJson.Crear(5,resultado);

        }
    }
}