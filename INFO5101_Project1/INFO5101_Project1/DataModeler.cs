using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace INFO5101_Project1
{
    public static class DataModeler
    {
        public static Dictionary<string, CityInfo> CityCatalogue;

        private static void ParseXML(string fileName)
        {

        }
        private static void ParseJSON(string fileName)
        {

        }
        private static void ParseCSV(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(",");
                int.TryParse(values[8], out int population);
                string name = values[0];
                string ascii = values[1];
                double.TryParse(values[2],out double lat);
                double.TryParse(values[3], out double lng);
                int.TryParse(values[8],out int cityId);
                string province = values[5];

                //int CityId, string CityName, string CityAscii, int Population, string Province, double latitude, double longitude)
                //city[0] , city_ascii[1] , lat[2] , lng[3] , country[4] , admin_name[5] , capital[6] , population[7] , id[8]
                CityInfo city = new CityInfo(cityId,name,ascii,population,province,lat,lng);
                CityCatalogue.Add(name, city);
            }
        }

        public static Dictionary<string, CityInfo> ParseFile(string fileName, string type)
        {
            return new Dictionary<string, CityInfo>();
        }
    }
}
