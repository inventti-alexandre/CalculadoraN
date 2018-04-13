using System.Runtime.Serialization;

[DataContract(Name="multiplicacion")]
public class ObjMult
{
    [DataMember(Name="factors")]  
    private double[] factors;

    public ObjMult(double[] multiplicandos)
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