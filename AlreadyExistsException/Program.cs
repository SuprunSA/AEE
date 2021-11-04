using System;
using System.Collections.Generic;

namespace AEE
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();

            var count = 0;
            try
            {
                while (true)
                {
                    Console.Write("Введите значение >>>");
                    var value = Console.ReadLine().ToLower().Trim();
                    if (values.ContainsKey(value))
                    {
                        throw new AlreadyExistsException(value, values[value]);
                    }
                    values.Add(value, ++count);
                }
            }
            catch(AlreadyExistsException e)
            {
                Console.WriteLine();
                Console.WriteLine("{0} - значение, {1} - номер вхождения значения", e.Value, e.Position);
            }
        }
    }

    class AlreadyExistsException : ArgumentException
    {
        public string Value { get; set; }
        public int Position { get; set; }

        public AlreadyExistsException(string value, int pos) : base("Такое значение уже было введено!")
        {
            Value = value;
            Position = pos;
        }
    }
}
