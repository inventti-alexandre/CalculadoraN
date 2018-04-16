
using System.Runtime.Serialization;
/*Objeto para serializar el id que se envía a la petición de journal */

[DataContract(Name = "Evi-Id")]
public class ObjId
{
    [DataMember(Name = "Id")]
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