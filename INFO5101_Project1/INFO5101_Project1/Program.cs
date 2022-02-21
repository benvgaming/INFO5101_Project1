using System;
using System.Collections.Generic;
namespace INFO5101_Project1
{
    class Program
    {
        const string PATHXML = ".\\..\\..\\..\\..\\Data\\Canadacities-XML.xml";
        const string PATHJSON = ".\\..\\..\\..\\..\\Data\\Canadacities-JSON.json";
        const string PATHCSV = ".\\..\\..\\..\\..\\Data\\Canadacities.csv";
        const string XMLNAME = "Canadacities-XML.xml";
        const string JSONNAME = "Canadacities-JSON.json";
        const string CSVNAME = "Canadacities.csv";
        static void Main(string[] args)
        {
            try
            {
                do
                {


                    Console.WriteLine("=============================");
                    Console.WriteLine("City Info Program");
                    Console.WriteLine("=============================");
                    Console.WriteLine("\nSelect files to parse");
                    Console.WriteLine("\n1)canadiancities.csv" +
                                      "\n2)canadiancities.json" +
                                      "\n3)canadiancities.xml" +
                                      "\n0)Exit the program");

                    bool validChoice = false;
                    int selection;
                    do
                    {
                        Console.WriteLine("\nSelect an option from the list above (e.g 1, 2)");
                        if (int.TryParse(Console.ReadLine(), out selection))
                        {
                            if (selection < 0 || selection > 3)
                                Console.WriteLine("The selection must be 1 or 2 or 3");
                            else
                                validChoice = true;
                        }
                        else
                            Console.WriteLine("The selection must be 1 or 2 or 3");
                    } while (!validChoice);

                    string choice = "";
                    Dictionary<string, List<CityInfo>> cityList = new Dictionary<string, List<CityInfo>>();
                    Statistics statistics = null;
                    string fileName = "";
                    switch (selection)
                    {
                        case 1:
                            choice = "csv";
                            statistics = new Statistics(PATHCSV, choice);
                            fileName = CSVNAME;
                            break;
                        case 2:
                            choice = "json";
                            statistics = new Statistics(PATHJSON, choice);
                            fileName = JSONNAME;
                            break;
                        case 3:
                            choice = "xml";
                            statistics = new Statistics(PATHXML, choice);
                            fileName = XMLNAME;
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }

                    bool isDone = false;

                    do
                    {


                        Console.WriteLine($"\nA city catalouge has now been populated from {fileName}");
                        Console.WriteLine($"\nFetching list of available data query routines that can be run on the {fileName}");
                        Console.WriteLine("\n1)Display city information" +
                          "\n2)Display province cities" +
                          "\n3)Calculate province population" +
                          "\n4)Match cities population" +
                          "\n5)Distance between cities" +
                          "\n6)Restart the program and choose another file type to query" +
                          "\n7)Display city on website" +

                          "\n0)Exit the program");

                        validChoice = false;
                        selection = 0;
                        do
                        {
                            Console.WriteLine($"\nSelect a data query routine from the list above for the {fileName} (e.g 1, 2)");
                            if (int.TryParse(Console.ReadLine(), out selection))
                            {
                                if (selection < 0 || selection > 7)
                                    Console.WriteLine("The selection must be 0 to 7");
                                else
                                    validChoice = true;
                            }
                            else
                                Console.WriteLine("The selection must be 0 to 7");
                        } while (!validChoice);


                        switch (selection)
                        {
                            case 1:
                                //DisplayCityInformation    
                                break;

                            case 2:
                                //Calculate Province population
                                break;
                            case 3:
                                //Match Cities population
                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:
                                isDone = true;
                                Console.Clear();
                                break;
                            case 7:
                                //Show City On Map
                                Console.WriteLine("Enter City's Name: ");
                                string cityName = Console.ReadLine();
                                Console.WriteLine("Enter Province's Name: ");
                                string provinceName = Console.ReadLine();
                                statistics.ShowCityOnMap(cityName, provinceName);
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                        }
                    } while (!isDone);
                } while (true);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }//End of Main
    }//End of class
}//End of namespace
