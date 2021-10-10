using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> resultat = new List<int>();

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

                } while (!isvalidoperator(input));

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
                    float summa = value1 + value2;
                    Console.WriteLine("Din uträkning: " + value1 + " + " + value2 + " = " + summa);
                }

                if (_operator == "-")
                {
                    float differans = value1 + value2;
                    Console.WriteLine("Din uträkning: " + value1 + " - " + value2 + " = " + differans);
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
                    }
                }

                if (_operator == "*")
                {
                    float produkt = value1 + value2;
                    Console.WriteLine("Din uträkning: " + value1 + " * " + value2 + " = " + produkt);
                }
            }
        }

        

        private static bool isvalidoperator(string input)
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
