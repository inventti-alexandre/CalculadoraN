using System;

using CalculadoraServidor.Interfaces;
namespace CalculadoraServidor.Models
{
    /*Calculos de division */
    public class DivModel : Icalculos<respDiv>
    {
        private double _dividend;
        private double[] _divisor;
        private long _result;
        private long _resto;

        public DivModel(double dividendo, double[] divisor)
        {
            _dividend = dividendo;
            _divisor = divisor;
        }

        public respDiv calcular()
        {
            long dividendo = Convert.ToInt64(_dividend);
            long divisor = 1;
            
            for (int a = 0; a < _divisor.Length; a++)
            {
                divisor = divisor * Convert.ToInt64(_divisor[a]);
                
            }
             _result = dividendo / divisor;
             _resto = dividendo % divisor;
            
            return new respDiv(_result, _resto);
        }

        public override string ToString()
        {
            string OperacionSt = $"{_dividend} : ";
            for (int a = 0; a < _divisor.Length; a++)
            {
                if (a < (_divisor.Length - 1)) OperacionSt = $"{OperacionSt}{_divisor[a]} : ";
                else OperacionSt = $"{OperacionSt}{_divisor[a]} = ";
            }
            return OperacionSt;
        }
    }
}

