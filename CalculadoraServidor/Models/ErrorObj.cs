
using System.Runtime.Serialization;
/*Objeto para serializar error y enviarlo al cliente */
[DataContract(Name="Error")]
class ErrorObj
{
    [DataMember(Name="ErrorCode")]
    private string ErrorCode;
    [DataMember(Name="ErrorStatus")]
    private string ErrorStatus;
    [DataMember(Name="ErrorMessage")]
    private string ErrorMessage;


    public ErrorObj(string Code, string Estado, string Mensaje)
    {
        SetErrorCode(Code);
        SetErrorMessage(Mensaje);
        SetErrorStatus(Estado);
    }

    public string GetErrorMessage()
    {
        return ErrorMessage;
    }

    public void SetErrorMessage(string value)
    {
        ErrorMessage = value;
    }
    public string GetErrorStatus()
    {
        return ErrorStatus;
    }

    public void SetErrorStatus(string value)
    {
        ErrorStatus = value;
    }

    public string GetErrorCode()
    {
        return ErrorCode;
    }

    public void SetErrorCode(string value)
    {
        ErrorCode = value;
    }
}