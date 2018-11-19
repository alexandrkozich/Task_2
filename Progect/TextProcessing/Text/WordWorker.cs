
namespace TextProcessing
{
    public class WordWorker : IWordWorker
    {

        public int GetWordLength(ISentenceElement element)
        {
            return element.Value.Length;
        }
        
    }
}