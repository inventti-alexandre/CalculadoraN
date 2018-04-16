
using System.Runtime.Serialization;
/*Objeto para deserializar la respuesta del servidor a la petición de journal */

[DataContract(Name="journal")]
class respJournal
{
    [DataMember(Name="Operation")]
    private string operacion;

    [DataMember(Name="Calculation")]
    private string calculo;
    [DataMember(Name="Date")]
    private string fecha;

    public respJournal(string fechaEn, string OperEn, string CalculoEn )
    {
        SetOperacion(OperEn);
        SetCalculo(CalculoEn);
        SetFecha(fechaEn);
    }
    public string GetFecha()
    {
        return fecha;
    }

    public void SetFecha(string value)
    {
        fecha = value;
    }

    public string GetCalculo()
    {
        return calculo;
    }

    public void SetCalculo(string value)
    {
        calculo = value;
    }

    public string GetOperacion()
    {
        return operacion;
    }

    public void SetOperacion(string value)
    {
        operacion = value;
    }
}