using System;
namespace CalculadoraServidor.Models
{
    /*calculos de suma */
    public class AddModel
    {
        public static object sumar(ObjSuma datosSuma, string EviId)
        {
            double[] DatosT = datosSuma.addens;
            double resultadoD = 0;
            string OperacionSt = "";
            for (var a = 0; a < DatosT.Length; a++)
            {
                resultadoD = resultadoD + DatosT[a];
                if (a < (DatosT.Length - 1)) OperacionSt = $"{OperacionSt}{DatosT[a]} + ";
                else OperacionSt = $"{OperacionSt}{DatosT[a]} = ";
            }
            OperacionSt = $"{OperacionSt}{resultadoD}";
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId, OperacionSt, tiempo, "Sum");
            return crearJson.Crear(1, resultadoD);

        }
    }
}


