using System;

namespace csharp_practices
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tested with both .Net Standart and .Net Core
            Console.WriteLine("How many dots will you throw?");
            string userInput = Console.ReadLine();
            double dotCount = double.Parse(userInput);

            Random r = new Random();

            double x = 0.0, y = 0.0, insideCircleCount = 0.0, pi;

            Console.WriteLine("Started throwing dots..");

            for (int i = 1; i <= dotCount; i++)
            {
                //r.NextDouble() - Generates a random number between 0 and 1
                x = r.NextDouble();
                y = r.NextDouble();

                if (((x * x) + (y * y) <= 1))
                    insideCircleCount++;


                Console.Write(i.ToString() + ", ");

            }

            pi = 4.0 * (insideCircleCount / dotCount);
            Console.WriteLine("Finished throwing dots...");
            Console.WriteLine("Pi Value Estimation: {0:0.000000}, Total number of throwed dots: {1}, Number of dots in the circle: {2}", pi, dotCount, insideCircleCount);
            Console.Read();
        }
    }
}
