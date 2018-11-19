

namespace TextProcessing
{
    public interface ISentenceElement
    {
        string Value { get; set; }
        SentenceElementType SentenceElementType { get; }
    }
}
