namespace SerializationJourney;

public class DemoEntry
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int Grade { get; set; }

    public IList<string> AList { get; set; }

    public ComplexType ComplexObject { get; set; }
}

public class ComplexType
{
    public string OneProp { get; set; }

    public string AnotherProp { get; set; }
}
