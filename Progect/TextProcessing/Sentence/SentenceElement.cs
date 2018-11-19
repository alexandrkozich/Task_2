

namespace TextProcessing
{
    public class SentenceElement : ISentenceElement
    {
        public string Value { get; set; }
        public SentenceElementType SentenceElementType { get;  }

        public SentenceElement(string sentenceElementValue, SentenceElementType type)
        {
            this.Value = sentenceElementValue;
            this.SentenceElementType = type;
        }

    }
}