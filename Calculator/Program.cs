using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Lista                                             // Skapar en klass för variabler som ska matas in i listan.
    {
        public float Value1 { get; set; }                   // Ta emot värdet och tilldela Value1
        public string Operand { get; set; }                 // Ta emot värdet och tilldela Operand
        public float Value2 { get; set; }
        public string Likamed { get; set; }
        public float Sum { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //Fredrik Törnberg, TUCSweden, syne21lin, Programmering Grund, 21-10-13.

            List<Lista> resultat = new List<Lista>();       // Skapar en List för historiken från miniräknaren

            string input = string.Empty;                    // Variabler 
            string _operator;
            float value1;
            float value2;

            Console.WriteLine(" - Välkommen till en fantastisk miniräknare - ");        // Välkomstmeddelande

            while (true)                                                                // While-loop för att miniräknaren ska fortsätta.
            {
                bool value1isvalid = false;                                             // Sätter en bool-variabel med värdet false.
                do                                                                      // do/while-loop för inmatning av första talet
                {
                    Console.Write("Mata in ditt första tal: ");
                    input = Console.ReadLine();                                         // Lyssnar efter värde från användaren och sätter det i variabeln input.
                    Marcus(input);                                                      // Anropar metoden Marcus() för att kontrollera om det inmatade värdet är "Marcus" 
                        
                        if (float.TryParse(input, out value1))                          // if-sats som försöker göra om input till en float-variabel, om det går så ger den variabeln value1 det värdet.
                        {
                            value1isvalid = true;                                       // Om den lyckades göra om input till float så sätter den value1isvalid = true och kan lämna do/while loopen.
                        }
                        else                                                            // Om den inte lyckas göra om input till float så är det ett felaktigt tecken (inte numeriskt).
                        {
                            Console.WriteLine("Felaktig inmatning: Endast numeriska tal kan användas!");        // Uppmanar användaren till att endast använda numeriska tal.
                        }

                } while (!value1isvalid);                                               // Kontrollerar om variabeln value1isvalid är true/false (true bryter loopen och går till nästa rad).

                do                                                                      // do/while-loop för inmatning av operand, den här gör i princip samma sak som första talet, men anropar förutom Marcus() även metoden Isvalidoperator() för att kontrollera så att det är en giltig operand.
                {
                    Console.Write("Mata in din operand: ");
                    input = Console.ReadLine();
                    Marcus(input);
                    _operator = input;

                } while (!Isvalidoperator(input));

                bool value2isvalid = false;                                             // Exakt likadan som för första talet, men för andra talet. 
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

                // if-loopar för att kontrollera vilket räknesätt som ska användas, kommer även att utföra beräkningen och föra in värdet i variablerna i listan.

                if (_operator == "+")                                                // Kontrollerar om addition
                {
                    float sum = value1 + value2;                                        // Ger variabeln sum, summan av value1 och value2. 
                    Console.WriteLine("Din uträkning: " + value1 + " + " + value2 + " = " + sum);  // Skriver ut beräkningen för användaren.
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = sum });            // Lägger till värdena i listan.
                    
                }

                if (_operator == "-")                                               // Kontrollerar om subtraktion
                {
                    float diff = value1 - value2;
                    Console.WriteLine("Din uträkning: " + value1 + " - " + value2 + " = " + diff);
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = diff });
                }

                if (_operator == "/")                                              // Kontrollerar om division
                {
                    
                    if (value2 == 0)                                                    // Kontroll om value2 är 0, för att undvika att dividera med noll.
                    {
                        Console.WriteLine("Det går inte att dividera med noll, du borde veta bättre än så.");        // Meddelar användaren att det inte går att dela med noll, skickar tillbaka till början för att göra om inmatningen.
                    }
                    else
                    {
                        float kvot = value1 / value2;                                           // Om value2 inte är 0 så utförs beräkningen.
                        Console.WriteLine("Din uträkning: " + value1 + " / " + value2 + " = " + kvot);
                        resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = kvot });
                    }
                }

                if (_operator == "*")                                               // Kontrollerar om multiplikation.
                {
                    float prod = value1 * value2;
                    Console.WriteLine("Din uträkning: " + value1 + " * " + value2 + " = " + prod);
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Likamed = "=", Sum = prod });
                }
                Console.Clear();
                Console.WriteLine("-= Historik =-");                                // Rubrik för historiken som är i listan.
                Console.WriteLine("");                                              // Radbryt

                foreach (Lista post in resultat)                                    // Skriver ut värden ur listan.
                {
                    
                    Console.Write(post.Value1 + " ");                               // Skriv ut värdet som finns i kolumnen Value1
                    Console.Write(post.Operand + " ");                              // Skriv ut värdet som finns i kolumnen Operand
                    Console.Write(post.Value2 + " ");
                    Console.Write(post.Likamed + " ");
                    Console.Write(post.Sum + " ");
                    Console.WriteLine("");                                          // Radbryt

                }
                Console.WriteLine("");
            }
        }

        

        private static bool Isvalidoperator(string input)                           // Metod för att kontrollera om operanden är giltig. 
        {
            if (input == "+")                                                       // om input är "+" så.. 
            {
                return true;                                                        // skicka tillbaka "true", annars kolla om nästa if stämmer.
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
            
            Console.WriteLine("Felaktig inmatning, endast operanderna: + - / *");       // om input inte stämmer med något av räknesätten så skriv ut meddelande. 
            return false;                                                               // och returnera false.
           
        }

        public static void Marcus(string input)                                     // Metod för att kontrollera om användaren har skrivit in marcus.

        {

            if (input.ToLower() == "marcus")                                        // gör om inmatningen till gemener för att lättare kunna kontrollera om det är marcus om är inmatat. 
            {
                Console.WriteLine("Hej Marcus!");                                   // om värdet i input är marcus så skriver vi ut "Hej Marcus!" och...
                Environment.Exit(0);                                                // Avslutar programmet.
            }

        }
    }
}
