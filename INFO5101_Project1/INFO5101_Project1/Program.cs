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
                          "\n4)Display city with largest population in a province" +
                          "\n5)Display city with smallest population in a province" +
                          "\n6)Distance between cities" +
                          "\n7)Display city on website" +

                          "\n8)Restart the program and choose another file type to query" +
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

                        string province = "";
                        string city1 = "";
                        string city2 = "";
                        CityInfo city = null;
                        switch (selection)
                        {
                            case 1:
                                //DisplayCityInformation    
                                break;

                            case 2:
                                //Display province cities
                                Console.WriteLine("Enter Province's Name: ");
                                province = Console.ReadLine();
                                statistics.DisplayProvinceCities(province);
                                break;
                            case 3:
                                //Calculate Province population
                                Console.WriteLine("Enter Province's Name: ");
                                province = Console.ReadLine();
                                statistics.DisplayProvincePopulation(province);
                                break;
                            case 4:
                                //Display Largest population
                                Console.WriteLine("Enter Province's Name: ");
                                province = Console.ReadLine();
                                city = statistics.DisplayLargestPopulationCity(province);
                                Console.WriteLine($"City with the smallest population in {province} province is {city.GetName()}");
                                break;
                            case 5:
                                //Display smallest population
                                Console.WriteLine("Enter Province's Name: ");
                                province = Console.ReadLine();
                                city = statistics.DisplayLargestPopulationCity(province);
                                Console.WriteLine($"City with the smallest population in {province} province is {city.GetName()}");
                                break;
                            case 6:
                                //Distance between cities
                                Console.WriteLine("Enter City 1's Name: ");
                                city1 = Console.ReadLine();
                                Console.WriteLine("Enter City 2's Name: ");
                                city2 = Console.ReadLine();
                                statistics.CalculateDistanceBetweenCities(city1, city2);
                                break;
                            case 7:
                                //Show City On Map
                                Console.WriteLine("Enter City's Name: ");
                                city1 = Console.ReadLine();
                                Console.WriteLine("Enter Province's Name: ");
                                province = Console.ReadLine();
                                statistics.ShowCityOnMap(city1, province);
                                break;
                            case 8:
                                isDone = true;
                                Console.Clear();
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
