using System.Runtime.Serialization;

[DataContract(Name = "JournalComplete")]
class respJournalConjunta
{
    [DataMember(Name = "Operations")]
    private respJournal[] filas;

    public respJournalConjunta(respJournal[] values)
    {
        SetFilas(values);
    }
    public respJournal[] GetFilas()
    {
        return filas;
    }
    public void SetFilas(respJournal[] value)
    {
        filas = value;
    }
}
