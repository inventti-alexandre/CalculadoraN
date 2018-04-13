using System;
using System.Runtime.Serialization;

[DataContract(Name="multiplicacion")]
public class multiplicacion
{
    [DataMember(Name="factors")]  
    private double[] factors;

    public multiplicacion(double[] multiplicandos)
    {
        SetFactors(multiplicandos);
    }

    public double[] GetFactors()
    {
        return factors;
    }

    public void SetFactors(double[] value)
    {
        factors = value;
    }
}