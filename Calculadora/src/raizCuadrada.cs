using System.Runtime.Serialization;
/*Objeto para serializar la petición de raiz cuadrada */

[DataContract(Name="raiz_cuadrada")]
public class raizCuadrada
{
    [DataMember(Name="Number")]  
    private double number;

    public raizCuadrada(double numeroEn)
    {
        SetNumber(numeroEn);
    }
    public double GetNumber()
    {
        return number;
    }

    public void SetNumber(double value)
    {
        number = value;
    }
}
