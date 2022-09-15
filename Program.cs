using System.Text;

namespace SpecialisationChoice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = new string[][]
            {
                new string[]{"W", "Hello", "Wo", "Wor", "World", "!" },
                new string[]{ "Russia", "Kazan", "Denmark" },
                new string[]{ "1234", "1567", "-2", "computer science" },
                new string[]{ "hello", "2", "word", ":-)" }

            };
            for (int i = 0; i < inputs.Length; i++)
            {
                string[] input = inputs[i];
                string[] filtered = FilterArrayOfString(input, (str) => str.Length <= 3);
                Console.Write($"[{ArrayToString(input, ", ")}]");
                Console.Write($" -> [{ArrayToString(filtered, ", ")}]");
                Console.WriteLine();
            }
        }

        static string[] FilterArrayOfString(string[] arr, Predicate<string> p)
        {
            int[] matchPredicate = new int[arr.Length];
            int nextInx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (p(arr[i]))
                {
                    matchPredicate[nextInx] = i;
                    nextInx++;
                }
            }

            string[] result = new string[nextInx];
            for (int i = 0; i < nextInx; i++)
            {
                int stringIdx = matchPredicate[i];
                result[i] = arr[stringIdx];
            }

            return result;
        }

        static string ArrayToString<T>(T[] arr, string separator)
        {
            var resultString = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                resultString.Append(arr[i] == null ? "" : arr[i]!.ToString());
                if (i < arr.Length-1)
                {
                    resultString.Append(separator);
                }
            }
            return resultString.ToString();
        }
    }
}