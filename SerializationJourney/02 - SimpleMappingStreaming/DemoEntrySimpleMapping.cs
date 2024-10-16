namespace SerializationJourney._02___SimpleMappingStreaming;

public class DemoEntrySimpleMappingStreaming
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int Grade { get; set; }

    public IList<string> AList { get; set; }

    public ComplexTypeSimpleMappingStreaming ComplexObject { get; set; }
}

public class ComplexTypeSimpleMappingStreaming
{
    public string OneProp { get; set; }

    public string AnotherProp { get; set; }
}
