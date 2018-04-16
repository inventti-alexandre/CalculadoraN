using System.Runtime.Serialization;

/*Objeto serialización de resta */
[DataContract(Name="ResResta")]
public class respResta
{
    [DataMember(Name="Difference")]  
    private double diferencia;

    public respResta(double ResEn)
    {
        SetDiferencia(ResEn);
    }

    public double GetDiferencia()
    {
        return diferencia;
    }

    public void SetDiferencia(double value)
    {
        diferencia = value;
    }
}
