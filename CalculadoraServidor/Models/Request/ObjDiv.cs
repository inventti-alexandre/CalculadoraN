using System.Runtime.Serialization;
/*Objeto para deserializar division */
public class ObjDiv
{
    public double dividend { get; set; }

    public double[] divisor { get; set; }

    public ObjDiv()
    { }
    public ObjDiv(double dividendo, double[] divisorEntrada)
    {
        dividend = dividendo;
        divisor = divisorEntrada;
    }
}