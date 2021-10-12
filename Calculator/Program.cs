using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Lista> resultat = new List<Lista>();

            string input = string.Empty;
            string _operator;
            float value1;
            float value2;

            Console.WriteLine(" - Välkommen till en fantastisk miniräknare - ");

            while (true)
            {
                bool value1isvalid = false;
                do
                {
                    Console.Write("Mata in ditt första tal: ");
                    input = Console.ReadLine();
                    Marcus(input);
                        
                        if (float.TryParse(input, out value1))
                        {
                            value1isvalid = true;
                        }
                        else
                        {
                            Console.WriteLine("Felaktig inmatning: Endast numeriska tal kan användas!");
                        }

                } while (!value1isvalid);

                do
                {
                    Console.Write("Mata in din operand: ");
                    input = Console.ReadLine();
                    Marcus(input);
                    _operator = input;

                } while (!Isvalidoperator(input));

                bool value2isvalid = false;
                do
                {
                    Console.Write("Mata in ditt andra tal: ");
                    input = Console.ReadLine();
                    Marcus(input);
                        
                        if (float.TryParse(input, out value2))
                        {
                            value2isvalid = true;
                        }
                        else
                        {
                            Console.WriteLine("Felaktig inmatning: Endast numeriska tal kan användas!");
                        }

                } while (!value2isvalid);

                
                if (_operator == "+")
                {
                    float sum = value1 + value2;
                    Console.WriteLine("Din uträkning: " + value1 + " + " + value2 + " = " + sum);
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = sum });
                    
                }

                if (_operator == "-")
                {
                    float diff = value1 - value2;
                    Console.WriteLine("Din uträkning: " + value1 + " - " + value2 + " = " + diff);
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = diff });
                }

                if (_operator == "/")
                {
                    
                    if (value2 == 0)
                    {
                        Console.WriteLine("Tyvärr går det inte att dividera med noll.");
                    }
                    else
                    {
                        float kvot = value1 / value2;
                        Console.WriteLine("Din uträkning: " + value1 + " / " + value2 + " = " + kvot);
                        resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = kvot });
                    }
                }

                if (_operator == "*")
                {
                    float prod = value1 * value2;
                    Console.WriteLine("Din uträkning: " + value1 + " * " + value2 + " = " + prod);
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = prod });
                }

                foreach (Lista post in resultat)
                {
                    Console.Write(post.Value1 + " ");
                    Console.Write(post.Operand + " ");
                    Console.Write(post.Value2 + " ");
                    Console.Write(post.Likamed + " ");
                    Console.Write(post.Sum + " ");
                    Console.WriteLine("");          //Radbryt

                }
                Console.WriteLine("");
            }
        }

        

        private static bool Isvalidoperator(string input)
        {
            if (input == "+")
            {
                return true;
            }
            if (input == "-")
            {
                return true;
            }
            if (input == "/")
            {
                return true;
            }
            if (input == "*")
            {
                return true;
            }
            
            Console.WriteLine("Felaktig inmatning, endast operanderna: + - / *");
            return false;
           
        }

        public static void Marcus(string input)

        {

            if (input.ToLower() == "marcus")
            {
                Console.WriteLine("Hej Marcus!");
                Environment.Exit(0);
            }

        }
    }
}
