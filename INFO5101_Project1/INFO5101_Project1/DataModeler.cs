﻿/* Authors: Manh Cuong Nguyen, Devon Tully, James Thornton
 * Class: DataModeler.cs
 * Purposes: Parse files to create dictionary for the program
 */

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace INFO5101_Project1
{
    public static class DataModeler
    {

        private class JsonCity
        {
            public string city = "";
            public string city_ascii = "";
            public double lat = 0.0;
            public double lng = 0.0;
            public string country = "";
            public string admin_name = "";
            public string capital = "";
            public int population = 0;
            public int id = 0;

        }//End of JsonCity Class

        public static Dictionary<string, List<CityInfo>> CityCatalogue;

        //name: ParseXML
        //description: parses the XML file and creates a dictionary of cities
        //parameters: string fileName
        //returns: the parsed dictionary filled with cities and their information
        private static void ParseXML(string fileName)
        {

            StreamReader reader = new StreamReader(fileName);
            string rawXml = "";
            while (!reader.EndOfStream)
            {
                rawXml += reader.ReadLine();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rawXml);
            XmlNodeList canadaCities = xmlDoc.GetElementsByTagName("CanadaCity");

            List<CityInfo> cities = new List<CityInfo>();
            foreach (XmlNode node in canadaCities)
            {
                int population = 0;
                int.TryParse(node.ChildNodes[7].InnerText, out population);

                int id = 0;
                int.TryParse(node.ChildNodes[8].InnerText, out id);

                double lat = 0.0;
                double lng = 0.0;

                double.TryParse(node.ChildNodes[2].InnerText, out lat);
                double.TryParse(node.ChildNodes[3].InnerText, out lng);

                string capital = node.ChildNodes[6].InnerText;

                cities.Add(
                    new CityInfo(
                        id,
                        DeFrenchify(node.ChildNodes[0].InnerText),
                        node.ChildNodes[1].InnerText,
                        population,
                        DeFrenchify(node.ChildNodes[5].InnerText),
                        lat,
                        lng,
                        capital
                        )
                    );
            }

            foreach (CityInfo city in cities)
            {
                if (!CityCatalogue.ContainsKey(city.GetName()))
                {
                    CityCatalogue.Add(city.GetName(), new List<CityInfo>());
                }

                CityCatalogue[city.GetName()].Add(city);
            }
        }//End of ParseXML

        //name: ParseJSON
        //description: parses the JSON file and creates a dictionary of cities
        //parameters: string fileName
        //returns: the parsed dictionary filled with cities and their information
        private static void ParseJSON(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string rawJson = "";
            while (!reader.EndOfStream)
            {
                rawJson += reader.ReadLine();
            }
            List<JsonCity> output = JsonConvert.DeserializeObject<List<JsonCity>>(rawJson);

            foreach (JsonCity city in output)
            {
                CityInfo cityObj = new CityInfo(city.id, DeFrenchify(city.city), city.city_ascii, city.population, DeFrenchify(city.admin_name), city.lat, city.lng, city.capital);
                if (!CityCatalogue.ContainsKey(DeFrenchify(city.city)))
                {
                    CityCatalogue.Add(DeFrenchify(city.city), new List<CityInfo>());
                }

                CityCatalogue[DeFrenchify(city.city)].Add(cityObj);
            }
        }//End of ParseJSON

        //name: ParseCSV
        //description: parses the CSV file and creates a dictionary of cities
        //parameters: string fileName
        //returns: the parsed dictionary filled with cities and their information
        private static void ParseCSV(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(",");
                int.TryParse(values[7], out int population);
                string name = DeFrenchify(values[0]);
                string ascii = values[1];
                double.TryParse(values[2], out double lat);
                double.TryParse(values[3], out double lng);
                int.TryParse(values[8], out int cityId);
                string province = DeFrenchify(values[5]);
                string capital = values[6];

                //int CityId, string CityName, string CityAscii, int Population, string Province, double latitude, double longitude)
                //city[0] , city_ascii[1] , lat[2] , lng[3] , country[4] , admin_name[5] , capital[6] , population[7] , id[8]
                CityInfo city = new CityInfo(cityId, name, ascii, population, province, lat, lng, capital);
                if (!CityCatalogue.ContainsKey(name))
                {
                    CityCatalogue.Add(name, new List<CityInfo>());
                }

                CityCatalogue[name].Add(city);
            }
        }//End of ParseCSV

        //name: ParseFile
        //description: parses the file and creates a dictionary of cities
        //parameters: string fileName
        //returns: the parsed dictionary filled with cities and their information
        public static Dictionary<string, List<CityInfo>> ParseFile(string fileName, string type)
        {
            CityCatalogue = new Dictionary<string, List<CityInfo>>();
            switch (type)
            {
                case "xml":
                    ParseXML(fileName);
                    return CityCatalogue;
                case "csv":
                    ParseCSV(fileName);
                    return CityCatalogue;
                case "json":
                    ParseJSON(fileName);
                    return CityCatalogue;
                default:
                    return new Dictionary<string, List<CityInfo>>();
            }
        }//End of ParseFile()

        //name: DeFrenchify
        //description: convert all French letters to English so user type easier
        //parameters: string input
        //returns: the converted string
        private static string DeFrenchify(string input)
        {
            return input.Replace('é', 'e').Replace('è', 'e').Replace("Î", "I").Replace('â', 'a').Replace('ô', 'o');
        }
    }//End of class
}//End of namespace
