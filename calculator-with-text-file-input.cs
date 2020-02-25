using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/*
This is a Windows console application that does the job for the problem given above: (this was a junior software developer job application question)

Problem: Calculator Write some code to calculate a result from a set of instructions. 
Instructions comprise of a keyword and a number that are separated by a space per line. 
Instructions are loaded from file and results are output to the screen. Any number of Instructions can be specified. 
Instructions can be any binary operators of your choice (e.g., add, divide, subtract, multiply etc). The instructions will ignore mathematical precedence. 
The last instruction should be “apply” and a number (e.g., “apply 3”). 
The calculator is then initialised with that number and the previous instructions are applied to that number. 
Examples of the calculator lifecycle might be:

Example 1.
[Input from file]
add 2
multiply 3
apply 3
[Output to screen]
15
[Explanation]
(3 + 2) * 3 = 15


Example 2.
[Input from file]
multiply 9
apply 5
[Output to screen]
45
[Explanation]
5 * 9 = 45


Example 3.
[Input from file]
apply 1
[Output to screen]
1
*/

namespace csharp_practices
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string line;
                List<string> operations = new List<string>();
                Console.WriteLine("Your text file consists of:");

                //PUT THE calc.txt FILE IN THE SAME FOLDER WITH THE EXE FILE. (or dll file in .Net Core)
                //IF DEBUGGING, PUT IT IN THE DEBUGGING FOLDER WHERE THE EXE IS CREATED
                //E.G. .../calculator-with-text-file-input/Bin/Debug
                string path = Environment.CurrentDirectory;
                StreamReader file = new StreamReader(path + @"\\calculator-with-text-file-input-sample.txt");
                while ((line = file.ReadLine()) != null)
                {
                    operations.Add(line);
                    Console.WriteLine(line);
                }
                file.Close();

                string[] ops = operations.ToArray();
                string lastline = ops.Last();
                int myint;
                if (lastline.Contains("apply"))
                {
                    lastline = lastline.Replace("apply", "").Trim();
                    myint = Convert.ToInt32(lastline);

                    double result = myint;
                    foreach (string s in ops)
                    {
                        if (s.Contains("add"))
                        {
                            int a = Convert.ToInt32(s.Replace("add", "").Trim());
                            result = result + a;
                        }
                        else if (s.Contains("divide"))
                        {
                            int a = Convert.ToInt32(s.Replace("divide", "").Trim());
                            if (a != 0)
                                result = result / a;
                            else
                                Console.WriteLine("You cannot divide by zero so one of the lines that contains 'divide 0' is skipped.");
                        }
                        else if (s.Contains("subtract"))
                        {
                            int a = Convert.ToInt32(s.Replace("subtract", "").Trim());
                            result = result - a;
                        }
                        else if (s.Contains("multiply"))
                        {
                            int a = Convert.ToInt32(s.Replace("multiply", "").Trim());
                            result = result * a;
                        }
                        else if (s.Contains("apply"))
                        { }
                        else
                            Console.WriteLine("One of the lines in your text file does not include any of the keywrods: 'add', 'subtract', 'multiply' or 'divide', so that line is skipped.");


                    }

                    Console.WriteLine("");
                    Console.WriteLine("and the result is:" + result);


                }
                else
                {
                    Console.WriteLine("Your last line does not include the keyword 'apply'");
                }

            }

            catch (Exception Ex)
            {
                Console.WriteLine("There has been an exception. The exception detail is: " + Ex);
            }

            Console.ReadLine();
        }
    }
}
