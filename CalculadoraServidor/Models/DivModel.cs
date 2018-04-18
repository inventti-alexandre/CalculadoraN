using System;
namespace CalculadoraServidor.Models
{
    /*Calculos de division */
    public class DivModel
    {
        public static object dividir(ObjDiv datos, string EviId)
        {
            long dividendo = Convert.ToInt64(datos.GetDividend());
            long divisor = 1;
            string OperacionSt = $"{dividendo}";
            for (int a = 0; a < datos.GetDivisor().Length; a++)
            {
                divisor = divisor * Convert.ToInt64(datos.GetDivisor()[a]);
                if (a < (datos.GetDivisor().Length - 1)) OperacionSt = $"{OperacionSt}{datos.GetDivisor()[a]} : ";
                else OperacionSt = $"{OperacionSt}{datos.GetDivisor()[a]} = ";
            }
            double resultado = dividendo / divisor;
            double resto = dividendo % divisor;
            OperacionSt = $"{OperacionSt}{resultado} R: {resto}";
            string tiempo = String.Format("{0:u}", DateTime.Now);
            saveInFile.GuardarOperaciones(EviId, OperacionSt, tiempo, "Div");
            return crearJson.Crear(4, resultado, resto);
        }
    }
}

