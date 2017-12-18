using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator_with_text_file_input
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

                //PUT THE calc.txt FILE IN THE SAME FOLDER WITH THE EXE FILE. 
                //IF DEBUGGING, PUT IT IN THE DEBUGGING FOLDER WHERE THE EXE IS CREATED
                //E.G. .../calculator-with-text-file-input/Bin/Debug
                string path = System.Environment.CurrentDirectory;
                System.IO.StreamReader file = new System.IO.StreamReader(path + @"\\calc.txt");
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

            catch (Exception Ex) { Console.WriteLine("There has been an exception. The exception detail is: " + Ex); }



            Console.ReadLine();
        }
    }
}
