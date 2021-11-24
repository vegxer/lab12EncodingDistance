using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab12EncodingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу: ");
            List<string> codesDistances = ReadMatrix(Console.ReadLine());
            Console.Write("Кодовые расстояния: ");
            GetCodesDistances(codesDistances).ForEach(x => Console.Write(x + " "));
            Console.ReadKey();
        }

        static List<int> GetCodesDistances(List<string> matrix)
        {
            List<int> codesDistances = new List<int>();

            for (int i = 0; i < matrix.Count; ++i)
            {
                for (int j = i + 1; j < matrix.Count; ++j)
                {
                    int distance = 0;
                    for (int k = 0; k < matrix[0].Length; ++k)
                    {
                        if (matrix[i][k] != matrix[j][k])
                            ++distance;
                    }
                    codesDistances.Add(distance);
                }
            }

            return codesDistances;
        }

        static List<string> ReadMatrix(string filePath)
        {
            List<string> matrix = new List<string>();
            using (StreamReader reader = new StreamReader(@filePath))
            {
                while (!reader.EndOfStream)
                    matrix.Add(reader.ReadLine());
            }

            return matrix;
        }
    }
}
