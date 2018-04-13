using System.Runtime.Serialization;

[DataContract(Name="ResResta")]
public class respMult
{
    [DataMember(Name="Product")]  
    private double multip;

    public respMult(double ResEn)
    {
        SetMultip(ResEn);
    }

    public double GetMultip()
    {
        return multip;
    }

    public void SetMultip(double value)
    {
        multip = value;
    }
}
