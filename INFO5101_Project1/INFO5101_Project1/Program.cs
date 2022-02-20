using System;

namespace INFO5101_Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("City Info Program");
            Console.WriteLine("=============================");
            Console.WriteLine("\nSelect files to parse");
            Console.WriteLine("\n1)canadiancities.csv" +
                              "\n2)canadiancities.json" +
                              "\n3)canadiancities.xml");

            //JT: Commented the below out for parsing testing.
            //bool validChoice = false;
            //int selection;
            //do
            //{
            //    Console.WriteLine("\nSelect an option from the list above (e.g 1, 2)"); 
            //    if(int.TryParse(Console.ReadLine(), out selection))
            //    {
            //        if (selection < 1 || selection > 3)
            //            Console.WriteLine("The selection must be 1 or 2 or 3");
            //        else
            //            validChoice = true;
            //    }
            //    else
            //            Console.WriteLine("The selection must be 1 or 2 or 3");
            // } while (!validChoice);

            //DataModeler.ParseFile(".\\Data\\Canadacities.csv", "csv");
            //DataModeler.ParseFile(".\\Data\\Canadacities-JSON.json", "json");
            DataModeler.ParseFile(".\\Data\\Canadacities-XML.xml", "xml");
            


        }//End of Main
    }//End of class
}//End of namespace
