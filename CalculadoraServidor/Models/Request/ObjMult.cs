using System.Runtime.Serialization;
/*Objetot para serializar el envío de la multiplicación */
public class ObjMult
{
    public double[] factors { get; set; }
    public ObjMult()
    { }
    public ObjMult(double[] factores)
    {
        factors = factores;
    }
}