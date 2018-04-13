using System.Runtime.Serialization;

[DataContract(Name="suma")]
public class Objsuma
{
    [DataMember(Name="addens")]  
    private double[] addens;

    public Objsuma(double[] sumandosEn)
    {

        addens =  sumandosEn;
    }
    public double[] GetSumandos()
    {
        return addens;
    }

    public void SetSumandos(double[] value)
    {
        addens = value;
    }

   
}