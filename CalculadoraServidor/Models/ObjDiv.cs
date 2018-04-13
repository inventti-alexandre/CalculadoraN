using System.Runtime.Serialization;

[DataContract(Name="division")]
public class ObjDiv
{
    [DataMember(Name="Dividend")]  
    private double dividend;

    [DataMember(Name="Divisor")]  
    private double[] divisor;

    public ObjDiv(double dividendo, double[] divisor)
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