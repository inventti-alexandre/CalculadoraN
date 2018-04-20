 
 using CalculadoraServidor.Interfaces;

namespace CalculadoraServidor.Interfaces
{

    public interface IservicioCalc
    {
        
 
        T calcular<T>(Icalculos<T> operacion);
        string  ToString<T>(Icalculos<T> operacion);
    }
}