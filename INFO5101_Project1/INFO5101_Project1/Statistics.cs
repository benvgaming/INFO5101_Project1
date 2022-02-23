/* Authors: Manh Cuong Nguyen, Devon Tully, James Thornton
 * Class: Statistics.cs
 * Purposes: Convert the data from files to statistics for user
 */

using System;
using System.Collections.Generic;

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
            if(cityInfo.Count > 0)
            {
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
            } else
            {
                Console.WriteLine("That city was not found in the list!");
            }
            //print our the city information
        }// End of DisplayCityInformation

        //Name:DisplayLargestPopulationCity
        //Description: Returns the city information for the largest population city
        //Parameters: province
        //Return: CityInfo
        public CityInfo DisplayLargestPopulationCity(string province)
        {
            CityInfo city = null;
            SortedSet<CityInfo> CityList = new SortedSet<CityInfo>(new CityOrderedByPopulation());
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                foreach (CityInfo cityItem in entry.Value)
                {
                    if (cityItem.GetProvince() == province)
                    {
                        CityList.Add(cityItem);
                    }
                }
            }
            if (CityList.Count > 0)
            {
                city = CityList.Max;

            }
            return city;
        }// End of DisplayLargestPopulationCity

        //Name:DisplaySmallestPopulationCity
        //Description: Returns the city information for the smallest population city
        //Parameters:province
        //Return: CityInfo
        public CityInfo DisplaySmallestPopulationCity(string province)
        {
            CityInfo city = null;
            SortedSet<CityInfo> CityList = new SortedSet<CityInfo>(new CityOrderedByPopulation());
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                foreach (CityInfo cityItem in entry.Value)
                {
                    if (cityItem.GetProvince() == province)
                    {
                        CityList.Add(cityItem);
                    }
                }
            }
            if (CityList.Count > 0)
            {
                city = CityList.Min;
            }
            return city;
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
            bool foundOne = false;
            bool foundTwo = false;
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetName() == CityName1)
                {
                    foundOne = true;
                    lat1 = entry.Value[0].GetLatitude();
                    lon1 = entry.Value[0].GetLongitude();
                }
                if (entry.Value[0].GetName() == CityName2)
                {
                    foundTwo = true;
                    lat2 = entry.Value[0].GetLatitude();
                    lon2 = entry.Value[0].GetLongitude();
                }
            }

            if(foundOne && foundTwo)
            {
                //calculate the distance between the two cities
                double distance = DistanceTo(lat1, lon1, lat2, lon2, 'K');
                //display the distance between the two cities
                Console.WriteLine("The distance between {0} and {1} is {2} km", CityName1, CityName2, distance);
            } else
            {
                string errorMsg = "Error: ";
                if (!foundOne) errorMsg += "City one not found. ";
                if (!foundTwo) errorMsg += "City two not found. ";
                Console.WriteLine(errorMsg);
            }

        }// End of CalculateDistanceBetweenCities

        //Name:DisplayProvincePopulation
        //Description: Display the population of the province
        //Parameters: Province
        //Return: String formated of the population of the province
        public void DisplayProvincePopulation(string Province)
        {
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
            //display the cities in the province
            List<CityInfo> CityList = new List<CityInfo>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                foreach(CityInfo city in entry.Value)
                {
                    if(city.GetProvince() == Province)
                    {
                        CityList.Add(city);
                    }
                }
            }
            if (CityList.Count > 0)
                foreach (CityInfo city in CityList)
                {
                    Console.WriteLine(city.GetName());
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
            Dictionary<string, long> Provinces = new Dictionary<string, long>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                foreach(CityInfo info in entry.Value)
                {
                    if (Provinces.ContainsKey(info.GetProvince()))
                    {
                        Provinces[info.GetProvince()] += info.GetPopulation();
                    } 
                    else
                    {
                        Provinces.Add(info.GetProvince(), info.GetPopulation());
                    }
                }
            }
            SortedSet<Tuple<string, long>> sortedList = new SortedSet<Tuple<string, long>>(new ProvinceOrderedByPopulation());
            foreach(KeyValuePair<string, long> province in Provinces)
            {
                sortedList.Add(new Tuple<string, long>(province.Key, province.Value));
            }
            
            foreach (Tuple<string, long> province in sortedList)
            {
                if (province.Item1 != "" && province.Item1 != "admin_name")
                    Console.WriteLine($"{province.Item1} Population: {province.Item2}");
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
            Dictionary<string, long> Provinces = new Dictionary<string, long>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                foreach (CityInfo info in entry.Value)
                {
                    if (Provinces.ContainsKey(info.GetProvince()))
                    {
                        Provinces[info.GetProvince()] += 1;
                    }
                    else
                    {
                        Provinces.Add(info.GetProvince(), 1);
                    }
                }
            }
            SortedSet<Tuple<string, long>> sortedList = new SortedSet<Tuple<string, long>>(new ProvinceOrderedByPopulation());
            foreach (KeyValuePair<string, long> province in Provinces)
            {
                sortedList.Add(new Tuple<string, long>(province.Key, province.Value));
            }

            foreach (Tuple<string, long> province in sortedList)
            {
                if (province.Item1 != "" && province.Item1 != "admin_name")
                    Console.WriteLine($"{province.Item1} Cities: {province.Item2}");
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
        }//End of DistanceTo

    }//End of class
}//End of namespace
