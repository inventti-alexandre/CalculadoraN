using System.Runtime.Serialization;
/*Objeto para deserializar la respuesta del servidor a la petición de suma */

[DataContract(Name = "ResSum")]
public class respSuma
{
    [DataMember(Name = "Sum")]
    private double Sum;

    public respSuma(double ResEn)
    {
        SetSum(ResEn);
    }

    public double GetSum()
    {
        return Sum;
    }

    public void SetSum(double value)
    {
        Sum = value;
    }
}