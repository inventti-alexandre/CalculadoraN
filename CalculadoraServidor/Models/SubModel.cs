using System;
namespace CalculadoraServidor.Models
{
    /*Calculos para realizar resta */
    public class SubModel
    {


        public static object restar(ObjResta datosResta, string EviId)
        {
            double minuendo = datosResta.GetMinuend();
            double[] sustraendo = datosResta.GetSubtrahend();
            string OperacionSt = $"{minuendo}";
            for (int a = 0; a < sustraendo.Length; a++)
            {
                minuendo = minuendo - sustraendo[a];
                if (a < (sustraendo.Length - 1)) OperacionSt = $"{OperacionSt}{sustraendo[a]} - ";
                else OperacionSt = $"{OperacionSt}{sustraendo[a]} = ";
            }
            OperacionSt = OperacionSt + minuendo;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId, OperacionSt, tiempo, "Res");
            return crearJson.Crear(2, minuendo);

        }
    }
}