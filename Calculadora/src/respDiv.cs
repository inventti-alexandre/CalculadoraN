using System.Runtime.Serialization;

[DataContract(Name="ResDiv")]

public class respDiv
{
    [DataMember(Name="Quotient")]  
    private double Resultado;

    [DataMember(Name="Remainder")]  
    private double Resto;

    public respDiv(double ResEn, double ResEn2)
    {
        SetResultado(ResEn);
        SetResto(ResEn2);
    }

    public double GetResultado()
    {
        return Resultado;
    }

    public void SetResultado(double value)
    {
        Resultado = value;
    }

    public double GetResto()
    { 
        return Resto; 
    }

    public void SetResto(double value)
    {
        Resto = value;
    }
}
