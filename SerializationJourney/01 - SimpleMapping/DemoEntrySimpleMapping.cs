namespace SerializationJourney._01___SimpleMapping;

public class DemoEntrySimpleMapping
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int Grade { get; set; }

    public IList<string> AList { get; set; }

    public ComplexTypeSimpleMapping ComplexObject { get; set; }
}

public class ComplexTypeSimpleMapping
{
    public string OneProp { get; set; }

    public string AnotherProp { get; set; }
}
