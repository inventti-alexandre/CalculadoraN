
using System.Runtime.Serialization;

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