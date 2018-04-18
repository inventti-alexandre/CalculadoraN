using System.Runtime.Serialization;
/*Objetot para serializar el envío de la multiplicación */
public class multiplicacion
{


    public double[] factors { get; set; }
    public multiplicacion()
    { }
    public multiplicacion(double[] factores)
    {
        this.factors = factores;
    }
}