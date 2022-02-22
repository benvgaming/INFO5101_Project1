using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    public class Statistics
    {
        public Dictionary<string, List<CityInfo>> CityCatalogue;

        public Statistics(string fileName, string type) => CityCatalogue = DataModeler.ParseFile(fileName, type); //End of c'tor

        //Name:DisplayCityInformation
        //Description: Returns the city information for the given city name
        //Parameters:CityName 
        //Return: String Format of all the information 
        public void DisplayCityInformation(string CityName)
        {   //Returns the city information for the given city name
            List<CityInfo> cityInfo = new List<CityInfo>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Key == CityName)
                {
                    cityInfo = entry.Value;
                    break;
                }
            }
            //print our the city information
            foreach (CityInfo city in cityInfo)
            {
                //display the information of the city provided
                Console.WriteLine("\nCity Name: " + city.GetName());
                Console.WriteLine("Population: " + city.GetPopulation());
                Console.WriteLine("Province: " + city.GetProvince());
                Console.WriteLine("Latitude: " + city.GetLatitude());
                Console.WriteLine("Longitude: " + city.GetLongitude());
                Console.WriteLine("\n");
            }


        }// End of DisplayCityInformation

        //Name:DisplayLargestPopulationCity
        //Description: Returns the city information for the largest population city
        //Parameters: province
        //Return: CityInfo
        public CityInfo DisplayLargestPopulationCity(string province)
        {
            List<CityInfo> city = null;
            Dictionary<string, List<CityInfo>> CityList = new Dictionary<string, List<CityInfo>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == province)
                {
                    CityList.Add(entry.Key, entry.Value);
                }
            }
            if (CityList.Count > 0)
            {
                //Need to be fixed
                city = CityList.Values.Max();

            }
            return city.First();
        }// End of DisplayLargestPopulationCity

        //Name:DisplaySmallestPopulationCity
        //Description: Returns the city information for the smallest population city
        //Parameters:province
        //Return: CityInfo
        public CityInfo DisplaySmallestPopulationCity(string province)
        {
            List<CityInfo> city = null;
            Dictionary<string, List<CityInfo>> CityList = new Dictionary<string, List<CityInfo>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == province)
                {
                    CityList.Add(entry.Key, entry.Value);
                }
            }
            if (CityList.Count > 0)
            {
                //Need to be fixed
                city = CityList.Values.Min();
            }
            return city.First();
        }// End of DisplaySmallestPopulationCity

        //Name:ShowCityOnMap
        //Description:
        //Parameters: Province,CityName
        //Return: 
        public void ShowCityOnMap(string CityName, string Province)
        {

            double lng = 0.0;
            double lat = 0.0;
            // search through the catalogue to find the longitude and latitude of the city
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province && entry.Key == CityName)
                {
                    lng = entry.Value[0].GetLongitude();
                    lat = entry.Value[0].GetLatitude();

                    //show the map in google maps with the longitude and latitude of the city
                    //load the map with the longitude and latitude of the city
                    // open google maps with location of the city from the catalogue using the longitude and latitude
                }
            }

            if (lat != 0.0 && lng != 0.0)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://maps.google.com/?q=" + lat + "," + lng, UseShellExecute = true });
            else
                Console.WriteLine("Can't find city/province, be sure the name of both city and province are correct");
        }// End of ShowCityOnMap

        //Name:CalculateDistanceBetweenCities
        //Description: calculate the distance between two cities u sing the DistanceTo method
        //Parameters: City1,City2
        //Return: String Format of the distance between the two cities
        public void CalculateDistanceBetweenCities(string CityName1, string CityName2)
        {
            // calculate the distance between two cities u sing the DistanceTo method
            //get latitude and longitude of each city
            double lat1 = 0, lat2 = 0, lon1 = 0, lon2 = 0;
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetName() == CityName1)
                {

                    lat1 = entry.Value[0].GetLatitude();
                    lon1 = entry.Value[0].GetLongitude();
                }
                if (entry.Value[0].GetName() == CityName2)
                {
                    lat2 = entry.Value[0].GetLatitude();
                    lon2 = entry.Value[0].GetLongitude();
                }
            }
            //calculate the distance between the two cities
            double distance = DistanceTo(lat1, lon1, lat2, lon2, 'K');
            //display the distance between the two cities
            Console.WriteLine("The distance between {0} and {1} is {2} km", CityName1, CityName2, distance);
        }// End of CalculateDistanceBetweenCities

        //Name:DisplayProvincePopulation
        //Description: Display the population of the province
        //Parameters: Province
        //Return: String formated of the population of the province
        public void DisplayProvincePopulation(string Province)
        {
            if (Province == "Quebec")
                Province = "Québec";
            int population = 0;

            //display the population of the province
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province)
                {
                    population += entry.Value[0].GetPopulation();
                }
            }
            if (population != 0)
                Console.WriteLine("The population of {0} is {1}", Province, population);
            else
                Console.WriteLine("Province's name is incorrect");
        }// End of DisplayProvincePopulation

        //Name:DisplayProvinceCities
        //Description: Display the cities in the province
        //Parameters: Province
        //Return:   List of cities in the province          
        public void DisplayProvinceCities(string Province)
        {

            if (Province == "Quebec")
                Province = "Québec";
            //display the cities in the province
            Dictionary<string, List<CityInfo>> CityList = new Dictionary<string, List<CityInfo>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province)
                {
                    CityList.Add(entry.Key, entry.Value);
                }
            }
            if (CityList.Count > 0)
                foreach (var entry in CityList.Values)
                {
                    Console.WriteLine(entry.First().GetName());
                }
            else
                Console.WriteLine("Province's name is incorrect");
        }// End of DisplayProvinceCities

        //Name:RankProvincesByPopulation
        //Description: Display the provinces ranked by population
        //Parameters: None
        //Return:  List of provinces ranked by population
        public void RankProvincesByPopulation()
        {
            //rank the provinces by population
            //sort the provinces by population
            //display the provinces in order of population
            List<KeyValuePair<string, int>> ProvinceList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                ProvinceList.Add(new KeyValuePair<string, int>(entry.Value[0].GetProvince(), entry.Value[0].GetPopulation()));
            }
            ProvinceList.Sort((x, y) => y.Value.CompareTo(x.Value));
            foreach (KeyValuePair<string, int> entry in ProvinceList)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }

        }// End of RankProvincesByPopulation


        //Name:RankProvincesByCities
        //Description: Display the provinces ranked by number of cities
        //Parameters: None
        //Return: List of provinces ranked by number of cities
        public void RankProvincesByCities()
        {
            //rank the provinces by number of cities
            //sort the provinces by number of cities
            //display the provinces in order of number of cities
            List<KeyValuePair<string, int>> ProvinceList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                ProvinceList.Add(new KeyValuePair<string, int>(entry.Value[0].GetProvince(), entry.Value.Count));
            }
            ProvinceList.Sort((x, y) => y.Value.CompareTo(x.Value));
            foreach (KeyValuePair<string, int> entry in ProvinceList)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }

        }// End of RankProvincesByCities

        //Name:GetCapital
        //Description: Display the capital of the province
        //Parameters: Province
        //Return: String formated of the capital of the province
        public CityInfo GetCapital(string Province)
        {
            //get the capital of the province
            CityInfo capital = null;
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province)
                {
                    if (entry.Value[0].GetCapital() == "admin")
                    {
                        capital = entry.Value[0];
                    }
                }
            }
            return capital;
        }// End of GetCapital

        //Name: DistanceTo 
        //Description: Calculate the distance between two cities
        //Parameters: lat1, lon1, lat2, lon2, unit
        //Return: double distance
        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

    }//End of class
}//End of namespace
