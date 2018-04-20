using System.Collections.Generic;
using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.servicios
{
    public class servicioCalc : IservicioCalc
    {
        public T calcular<T>(Icalculos<T> operation)
        {
            var result = operation.calcular();
            return result;
        }
        public string ToString<T>(Icalculos<T> operation)
        {
            var cadena = operation.ToString();
            return cadena;
        }
    }
}