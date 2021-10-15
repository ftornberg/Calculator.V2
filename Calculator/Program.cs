using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Calculator
{
    class Lista                                             // Skapar en klass för att kunna variablerna i kolumner för lättare utskrift.
    {
        public float Value1 { get; set; }                   // Ta emot värdet och tilldela Value1
        public string Operand { get; set; }                 // Ta emot värdet och tilldela Operand
        public float Value2 { get; set; }
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

            Console.WriteLine(" - Välkommen till en fantastisk miniräknare - ");                                // Välkomstmeddelande

            while (true)                                                                                        // While-loop för att miniräknaren ska fortsätta.
            {
                MataInNummer(out input, out value1);                                                            // Metod för inmatning av nummer ger värdet till variabeln value1.

                do                                                                                              // do/while-loop för inmatning av operand, den här gör i princip samma sak som första talet, men anropar förutom Marcus() även metoden Isvalidoperator() för att kontrollera så att det är en giltig operand.
                {
                    Console.Write("Mata in din operand: ");
                    input = Console.ReadLine();
                    Marcus(input);                                                                              //Eftersom att användare inte går att lita på så kontrollerar vi om de skriver Marcus även här.
                    _operator = input;

                } while (!Isvalidoperator(input));

                MataInNummer(out input, out value2);                                                            // Metod för inmatning av nummer ger värdet till variabeln value2.

                // if-loopar för att kontrollera vilket räknesätt som ska användas, kommer även att utföra beräkningen och föra in värdet i variablerna i listan.
                // FÖRBÄTTRING: jag hade kunnat lägga in alla räknesätt i en och samma if-loop eller göra en metod för hanteringen av dem.

                if (_operator == "+")                                                                           // Kontrollerar om addition
                {
                    float sum = value1 + value2;                                                                // Ger variabeln sum, summan av value1 och value2. 
                    Console.WriteLine($"Din uträkning: {value1} {_operator} {value2} = {sum}");                           // Skriver ut beräkningen för användaren.
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = sum });            // Lägger till värdena i listan.

                }

                if (_operator == "-")                                                                           // Kontrollerar om subtraktion
                {
                    float diff = value1 - value2;
                    Console.WriteLine($"Din uträkning: {value1} {_operator} {value2} = {diff}");
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = diff });
                }

                if (_operator == "/")                                                                           // Kontrollerar om division
                {

                    if (value2 == 0)                                                                            // Kontroll om value2 är 0, för att undvika att dividera med noll.
                    {
                        do
                        {
                            Console.WriteLine("Det går inte att dividera med noll, du borde veta bättre än så.\nMata in ditt andra tal igen.");        // Meddelar användaren att det inte går att dela med noll, skickar tillbaka till början för att göra om inmatningen.
                            MataInNummer(out input, out value2);
                        }
                        while (value2 == 0);

                        float kvot = value1 / value2;
                        resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = kvot });
                    }
                    else
                    {
                        float kvot = value1 / value2;                                                           // Om value2 inte är 0 så utförs beräkningen.
                        Console.WriteLine($"Din uträkning: {value1} {_operator} {value2} = {kvot}");
                        resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = kvot });
                    }
                }

                if (_operator == "*")                                                                           // Kontrollerar om multiplikation.
                {
                    float prod = value1 * value2;
                    Console.WriteLine($"Din uträkning: {value1} {_operator} {value2} = {prod}");
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = prod });
                }
                
                if (_operator == "^")                                                                           // Kontrollerar om multiplikation.
                {
                    float potens = (float)Math.Pow(value1, value2);
                    Console.WriteLine($"Din uträkning: {value1} {_operator} {value2} = {potens}");
                    resultat.Add(new Lista { Value1 = value1, Operand = _operator, Value2 = value2, Sum = potens });
                }

                Console.Clear();
                Console.WriteLine("-= Historik =-\n");                                                          // Rubrik för historiken som är i listan.                                                             

                GetHistory(resultat);                                                                           // Metod för att hämta historik, gjorde metod utifall man i framtiden skulle vilja skriva ut historiken fler gånger. 

                Console.WriteLine("");
            }
        }

        private static void GetHistory(List<Lista> resultat)
        {
            foreach (Lista post in resultat)                                                                // Skriver ut värden ur listan.
            {

                Console.Write($"{ post.Value1} {post.Operand} {post.Value2} = {post.Sum}\n");               // Skriv ut värdet som finns i kolumnen Value1

            }
        }

        private static void MataInNummer(out string input, out float valueOut)
        {
            bool valueisvalid = false;                                                                      // Sätter en bool-variabel med värdet false.
            do                                                                                              // do/while-loop för inmatning av talet.
            {
                Console.Write("Mata in ditt tal: ");                                                        
                input = Console.ReadLine();                                                                 // Lyssnar efter värde från användaren och sätter det i variabeln input.
                Marcus(input);                                                                              // Anropar metoden Marcus() för att kontrollera om det inmatade värdet är "Marcus"

                if (float.TryParse(input, out valueOut))                                                    // if-sats som försöker göra om input till en float-variabel, om det går så ger den variabeln value1 det värdet.
                {
                    valueisvalid = true;                                                                    // Om den lyckades göra om input till float så sätter den value1isvalid = true och kan lämna do/while loopen.
                }
                else                                                                                        // Om den inte lyckas göra om input till float så är det ett felaktigt tecken (inte numeriskt).
                {
                    Console.WriteLine("Felaktig inmatning: Endast numeriska tal kan användas!");            // Uppmanar användaren till att endast använda numeriska tal.
                }

            } while (!valueisvalid);                                                                        // Kontrollerar om variabeln valueisvalid är true/false (true bryter loopen).
        }


        private static bool Isvalidoperator(string input)                           // Metod för att kontrollera om operanden är giltig. 
        {
            if (input == "+" || input == "-" || input == "/" || input == "*" || input == "^")                                                       // om input är "+" så.. 
            {
                return true;                                                        // skicka tillbaka "true", annars kolla om nästa if stämmer.
            }

            Console.WriteLine("Felaktig inmatning, endast operanderna: + - / * ^");       // om input inte stämmer med något av räknesätten så skriv ut meddelande. 
            return false;                                                               // och returnera false.
           
        }

        public static void Marcus(string input)                                     // Metod för att kontrollera om användaren har skrivit in marcus.

        {

            if (input.ToLower() == "marcus")                                        // gör om inmatningen till gemener för att lättare kunna kontrollera om det är marcus om är inmatat. 
            {
                Console.WriteLine("Hej Marcus!");                                   // om värdet i input är marcus så skriver vi ut "Hej Marcus!" och...
                Thread.Sleep(1000);
                Console.WriteLine("Hejdå, Marcus!");
                Thread.Sleep(1000);
                Console.WriteLine("Tack för idag!");
                Thread.Sleep(2000);
                Environment.Exit(0);                                                // Avslutar programmet.
            }

        }
    }
}
