using System;
using System.Linq;
using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.Models
{
    /*calculos de suma */
    public class AddModel : Icalculos<respSuma>
    {

        private double[] _numeros;
        private double _resultado;

        public AddModel(double[] valores)
        {
            _numeros = valores;
        }

        public respSuma calcular()
        {
            _resultado = _numeros.Sum();
            return new respSuma(_resultado);
        }
        public override string ToString()
        {
            var a = $"{_numeros[0]}";
            for(var b = 1; b < _numeros.Length; b++)
            {
                a = $"{a} + {_numeros[b]}";
            } 
            a = $"{a} = ";
            return a;
        }

    }
}


