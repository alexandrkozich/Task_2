using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TextProcessing
{
    public class TextReader : IFileReader
    {
        private string _fileName;
        private string _bufLine = string.Empty;

        public TextReader(string fName)
        {
            this._fileName = fName;
        }

        public List<string> Read()
        {
            var stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                result.AddRange(SplitText(line, reader.EndOfStream));
            }
            reader.Close();
            return result;
        }

        private List<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _bufLine, line);
            int endOfSentence = 1;
            List<string> sentences = new List<string>();
            string remained = line;

            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }

                endOfSentence = (pointIndex < 0 ? remained.Length : pointIndex);

                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;

                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;

                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _bufLine = remained;
            }

            return sentences;
        }

    }
}

