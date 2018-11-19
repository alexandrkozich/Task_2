using System.Collections.Generic;


namespace TextProcessing
{
    public interface IParser<T>
    {
        T Parse(List<string> str);
    }
}
