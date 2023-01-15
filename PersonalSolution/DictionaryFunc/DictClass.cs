using System;
using System.Collections.Generic;

namespace DictionaryFunc
{
    class DictClass
    {
        public readonly Dictionary<int, Func<int>> DictFunction;
        public readonly Dictionary<int, Action> DictAction;

        public DictClass()
        {
            DictFunction = new()
            {
                { 1, () => NumFunc(1) },
                { 2, () => NumFunc(2) },
                { 3, () => NumFunc(3) },
                { 4, () => NumFunc(4) },
                { 5, () => NumFunc(5) }
            };

            DictAction = new()
            {
                // currying (from Action => to Action<string>)
                { 1, () => StringAct("Num1") },
                { 2, () => StringAct("Num2") },
                { 3, () => StringAct("Num3") },
                { 4, () => StringAct("Num4") },
                { 5, () => StringAct("Num5") }
            };
        }

        private static int NumFunc(int num)
        {
            //Action act = new(() =>StringAct(""));
            //act();

            return num * num;
        }

        private static void StringAct(string text)
        {
            Console.WriteLine(text);
        }
    }
}