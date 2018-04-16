using System.Runtime.Serialization;
/*Objeto para serializar resta */

[DataContract(Name = "resta")]
public class resta
{
    [DataMember(Name = "Minuend")]
    private double minuend;

    [DataMember(Name = "Subtrahend")]
    private double[] subtrahend;

    public resta(double minuendo, double[] sustraendo)
    {
        SetMinuend(minuendo);



        SetSubtrahend(sustraendo);
    }

    public double GetMinuend()
    {
        return minuend;
    }

    public void SetMinuend(double value)
    {
        minuend = value;
    }

    public double[] GetSubtrahend()
    {
        return subtrahend;
    }

    public void SetSubtrahend(double[] value)
    {
        subtrahend = value;
    }
}