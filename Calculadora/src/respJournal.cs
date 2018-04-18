class respJournal
{
    public string operation { get; set; }
    public string calculation { get; set; }
    public string date { get; set; }
    public respJournal(string fechaEn, string OperEn, string CalculoEn)
    {
        operation = OperEn;
        calculation = CalculoEn;
        date = fechaEn;
    }
    public respJournal()
    { }
    public override string ToString()
    {
        return $"{date} || {operation} || {calculation}";
    }
}