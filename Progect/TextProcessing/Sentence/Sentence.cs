using System.Collections.Generic;
using System.Text;


namespace TextProcessing
{
    public class Sentence : ISentence

    {

        private readonly List<ISentenceElement> _sententenceElements;
        private readonly IWordWorker _wordWorker;
        public Sentence()
        {
            _sententenceElements = new List<ISentenceElement>();
           
        }
        public int GetElementsCount()
        {
            return _sententenceElements.Count;
        }
        public ISentenceElement GetElementByIndex(int index)
        {
            if (index < 0 || index >= _sententenceElements.Count) return null;
            return _sententenceElements[index];
        }
        public void AddElementToEnd(ISentenceElement element)
        {
            _sententenceElements.Add(element);
        }

        public int GetWordsCount()
        {
            int count = 0;
            foreach (var sentenceElement in _sententenceElements)
            {
                if (sentenceElement.SentenceElementType == SentenceElementType.Word)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_sententenceElements[0].Value);
            for (int i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(_sententenceElements[i].Value);
            }
            return builder.ToString();
        }

       

       
    }
}
