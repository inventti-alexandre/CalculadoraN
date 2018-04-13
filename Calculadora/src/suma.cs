using System;
using System.Runtime.Serialization;

[DataContract(Name="suma")]
public class suma
{
    [DataMember(Name="addens")]  
    private double[] addens;

    public suma(double[] sumandosEn)
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