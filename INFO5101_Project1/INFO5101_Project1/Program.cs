using System;
using System.Collections.Generic;

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
            //    if (int.TryParse(Console.ReadLine(), out selection))
            //    {
            //        if (selection < 1 || selection > 3)
            //            Console.WriteLine("The selection must be 1 or 2 or 3");
            //        else
            //            validChoice = true;
            //    }
            //    else
            //        Console.WriteLine("The selection must be 1 or 2 or 3");
            //} while (!validChoice);

            DataModeler.ParseFile(".\\Data\\Canadacities.csv", "csv");
            var batman = DataModeler.ParseFile(".\\Data\\Canadacities-JSON.json", "json");
            DataModeler.ParseFile(".\\Data\\Canadacities-XML.xml", "xml");



            //foreach (var kvp in batman)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}",
            //        kvp.Key, kvp.Value);
            //}
            //foreach (var contents in batman.Keys)
            //{

            //    foreach (var listMember in batman[contents])
            //    {
            //        Console.WriteLine("Key : " + contents + " member :" + listMember);
            //    }
            //}

            //foreach (var a in batman.Values)
            //{
            //    a.ForEach(x => Console.WriteLine(x));
            //}
            //foreach (var value in batman)
            //{
            //    Console.WriteLine(value.Key);
            //    foreach (var item in value.Value)
            //        Console.WriteLine(item.Province);

            //}
            Statistics b = new Statistics(".\\Data\\Canadacities-JSON.json", "json");

            Console.WriteLine(b.GetCapital("Ontario"));
        }//End of Main
    }//End of class
}//End of namespace
