using System.Runtime.Serialization;

/*Objeto serialización de resta */
[DataContract(Name="ResSum")]
public class respSuma
{
    [DataMember(Name="Sum")]  
    private double Sum;

    public respSuma(double ResEn)
    {
        SetSum1(ResEn);
    }

    public double GetSum1()
    {
        return Sum;
    }

    public void SetSum1(double value)
    {
        Sum = value;
    }
}