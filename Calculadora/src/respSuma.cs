using System.Runtime.Serialization;

[DataContract(Name="ResSum")]
public class respSuma
{
    [DataMember(Name="Sum")]  
    private double Sum;

    public respSuma(double ResEn)
    {
        SetSum(ResEn);
    }

    public double GetSum()
    {
        return Sum;
    }

    public void SetSum(double value)
    {
        Sum = value;
    }
}