using System;
namespace CalculadoraServidor.Models
{
    /*Calculos para realizar raiz cuadrada */
    public class SqrModel
    {
        public static object RaizCuadrada(ObjSqr datos, string EviId)
        {
            double DatosT = datos.number;
            double resultado = Math.Sqrt(DatosT);
            string OperacionSt = $"{DatosT} Sqrt = {resultado}";
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId, OperacionSt, tiempo, "Sqr");
            return crearJson.Crear(5, resultado);
        }
    }
}