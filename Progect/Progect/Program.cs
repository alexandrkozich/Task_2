using System;
using System.Collections.Generic;
using TextProcessing;

namespace Project_Task2
{
    class Program
    {
        /*
        Задача 1. Создать программу обработки текста учебника по программированию с использованием классов: Символ, Слово, Предложение, Знак препинания и др. (состав и иерархию классов продумать самостоятельно). Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.
                    Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.

        */
        private static void Main(string[] args)
        {
            IFileReader r = new TextProcessing.TextReader("input.txt");
            List<string> listSentences = new List<string>();
            IParser<Text> parser = new TextParser();
            listSentences = r.Read();
            var text = parser.Parse(listSentences);
            //1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            foreach (var item in text.SortSentences())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************************");
            //2 Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            text.FindWordsOfPredeterminedLenght(text, 6);
            Console.WriteLine("*************************");
            Console.ReadKey();
        }

    }
}
