using System.Runtime.Serialization;
/*Objeto para deserializar la respuesta del servidor a la petición de restar */

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
