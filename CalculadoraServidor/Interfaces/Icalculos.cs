
namespace CalculadoraServidor.Interfaces
{

    public interface Icalculos<out T>
    {

        T calcular();
        string ToString();
    }
}