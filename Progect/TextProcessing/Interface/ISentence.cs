
namespace TextProcessing
{
    public interface ISentence
    {
       
        int GetWordsCount();
       int GetElementsCount();
        ISentenceElement GetElementByIndex(int index);
    }
}

