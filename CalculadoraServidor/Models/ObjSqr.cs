using System.Runtime.Serialization;

/*Objeto deserializar raiz cuadrada */
[DataContract(Name = "raiz_cuadrada")]
public class ObjSqr
{
    [DataMember(Name = "Number")]
    private double number;

    public ObjSqr(double numeroEn)
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
