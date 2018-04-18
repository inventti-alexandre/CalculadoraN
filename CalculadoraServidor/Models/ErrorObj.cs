using System.Runtime.Serialization;
/*Objeto para deserializar respuesta de error */
class ErrorObj
{
    public string errorCode { get; set; }
    public string errorStatus { get; set; }
    public string errorMessage { get; set; }
    public ErrorObj()
    {

    }
    public ErrorObj(string code, string status, string message)
    {
        errorCode = code;
        errorStatus = status;
        errorMessage = message;
    }
}