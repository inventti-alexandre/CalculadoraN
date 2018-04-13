using System.Runtime.Serialization;

[DataContract(Name="raiz_cuadrada")]
public class respSqr
{
    [DataMember(Name="Square")]  
    private double resultado;

    public respSqr(double numeroEn)
    {
        SetResultado(numeroEn);
    }

    public double GetResultado()
    {
        return resultado;
    }

    public void SetResultado(double value)
    {
        resultado = value;
    }
}
