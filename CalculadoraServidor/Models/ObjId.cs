
using System.Runtime.Serialization;
/*Objeto para deserializar Id de peticion journal */

[DataContract(Name="Evi-Id")]
public class ObjId
{
    [DataMember(Name="Id")]  
    private string Id;
    public ObjId(string id)
    {
        SetId(id);
    }
     public string GetId()
    {
        return Id;
    }

    public void SetId(string value)
    {
        Id = value;
    }
}