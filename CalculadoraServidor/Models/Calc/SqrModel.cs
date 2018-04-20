using System;

using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.Models
{
    /*Calculos para realizar raiz cuadrada */
    public class SqrModel : Icalculos<respSqr>
    {
        private double _numero;
        private double _result;

        public SqrModel(double datos)
        {
            _numero = datos;
        }
        public  respSqr calcular()
        {
            
            _result = Math.Sqrt(_numero);
           
            return new respSqr(_result);
        }

        public override string ToString()
        {
            string OperacionSt = $"{_numero} Sqrt = ";
            return OperacionSt;
        }
    }
}