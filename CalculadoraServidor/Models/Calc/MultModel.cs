using System;
using System.Linq;
using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.Models
{
    /*calculos de suma */
    public class MultModel : Icalculos<respMult>
    {

        private double[] _numeros;
        private double _resultado;

        public MultModel(double[] valores)
        {
            _numeros = valores;
        }

        public respMult calcular()
        {
            _resultado = 1;
            for(var a = 0; a < _numeros.Length; a++)
            {
                _resultado = _resultado * _numeros[a];
            }
            return new respMult(_resultado);
        }
        public override string ToString()
        {
            var a = $"{_numeros[0]}";
            for(var b = 1; b < _numeros.Length; b++)
            {
                a = $"{a} * {_numeros[b]}";
            } 
            return a;
        }

    }
}


