/*Objeto para serializar el envío de la división */
public class division
{
    public double dividend { get; set; }

    public double[] divisor { get; set; }

    public division(double dividendo, double[] divisorEntrada)
    {
        dividend = dividendo;
        divisor = divisorEntrada;
    }
    public division()
    {

    }
}