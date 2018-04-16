using System.Runtime.Serialization;

/*Objeto para serializar el envío de la división */
[DataContract(Name = "division")]
public class division
{
    [DataMember(Name = "Dividend")]
    private double dividend;

    [DataMember(Name = "Divisor")]
    private double[] divisor;

    public division(double dividendo, double[] divisor)
    {
        SetDividend(dividendo);
        SetDivisor(divisor);
    }

    public double GetDividend()
    {
        return dividend;
    }

    public void SetDividend(double value)
    {
        dividend = value;
    }

    public double[] GetDivisor()
    {
        return divisor;
    }

    public void SetDivisor(double[] value)
    {
        divisor = value;
    }
}