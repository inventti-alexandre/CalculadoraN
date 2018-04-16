using System;
namespace CalculadoraServidor.Models
{
    /*Calculos de multiplicación */
    public class MultModel
    {
       

        public static string multiplicar(ObjMult datosMul, string EviId)
        {
            double[] DatosT = datosMul.GetFactors();
            double resultadoD = 1;
            string OperacionSt = "";
            for(var a = 0; a < DatosT.Length; a++)
            {
                resultadoD = resultadoD * DatosT[a];
                if(a < ( DatosT.Length - 1)) OperacionSt = OperacionSt + DatosT[a] + " * ";
                else  OperacionSt = OperacionSt + DatosT[a] + " = ";
            }
            OperacionSt = OperacionSt + resultadoD;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId,OperacionSt,tiempo,"Mul");
            return crearJson.Crear(3,resultadoD);

        }
    }
}
