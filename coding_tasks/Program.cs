using System;
using System.Collections.Generic;
using System.Text;

namespace coding_tasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string> { "a", "b", "c", "d", "e", "f", "r", "g", "b" };
            int chunkSize = 2;

            List<List<string>> chunks = Chunked(input, chunkSize);

            Console.Write("[");
            for (int i = 0; i < chunks.Count; i++)
            {
                Console.Write("[");
                Console.Write("'" + string.Join("', '", chunks[i]) + "'");
                Console.Write("]");
                if (i != chunks.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        public static List<List<string>> Chunked(List <string> list, int n)
        {
            List<List<string>> result = new List<List<string>>();
            while (list.Count() > 0)
            {
                if (list.Count() >= n)
                {
                    List<string> chunk_add = new List<string>();
                    for (int i = 0; i < n; i++)
                    {
                        chunk_add.Add(list[i]);
                    }
                    list.RemoveRange(0, n);
                    result.Add(chunk_add);
                }
                else if (list.Count() < n && list.Count() > 0)
                {
                    result.Add(new List<string>(list));
                    list.Clear();
                }
            }
            return result;
        }
    }
}
