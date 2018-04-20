using System;

using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.Models
{
    /*Calculos para realizar resta */
    public class SubModel :Icalculos<respResta>
    {
        private double _minuend;
        private double[] _subtrahend;
    
        private double _result;

        public SubModel(double minuendo, double[] sustraendo)
        {
            _minuend = minuendo;
            _subtrahend = sustraendo;
        }

        public  respResta calcular()
        {
            string OperacionSt = $"{_minuend}";
            _result = _minuend;
            for (int a = 0; a < _subtrahend.Length; a++)
            {
                _result = _result - _subtrahend[a];
                if (a < (_subtrahend.Length - 1)) OperacionSt = $"{OperacionSt}{_subtrahend[a]} - ";
                else OperacionSt = $"{OperacionSt}{_subtrahend[a]} = ";
            }
            OperacionSt = OperacionSt + _minuend;
            string tiempo = String.Format("{0:u}", DateTime.Now);
            return new respResta(_result);
        }

        public override string ToString()
        {
            string OperacionSt = $"{_minuend} - ";
            for (int a = 0; a < _subtrahend.Length; a++)
            {
                _result = _minuend - _subtrahend[a];
                if (a < (_subtrahend.Length - 1)) OperacionSt = $"{OperacionSt}{_subtrahend[a]} - ";
                else OperacionSt = $"{OperacionSt}{_subtrahend[a]} = ";
            }
            return OperacionSt;
        }
    }
}