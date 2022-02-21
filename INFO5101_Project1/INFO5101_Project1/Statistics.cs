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

        public CityInfo DisplayCityInformation(string CityName)
        {
            // we will need to do the logic if there is more than one in here.
            return CityCatalogue[CityName].First();
            // CityInfo city;
            // CityCatalogue.TryGetValue(CityName, out city);
            // return city;
        }// End of DisplayCityInformation

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
                city = CityList.Values.Max();
            }
            return city.First();

            // //Search through the catalogue to find all the cities with the same province
            // foreach(KeyValuePair<string,CityInfo> entry in CityCatalogue)
            // {
            //     if (entry.Value.GetProvince() == province)
            //         CityList.Add(entry.Key,entry.Value);
            // }

            // //Find the city with the highest population
            // int tempPop = 0;

            // foreach(KeyValuePair<string,CityInfo> entry in CityList)
            // {
            //     if (entry.Value.GetPopulation() > tempPop)
            //     {
            //         city = entry.Value;
            //         tempPop = entry.Value.GetPopulation();
            //     }
            // }

            // return city;
        }// End of DisplayLargestPopulationCity

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
                city = CityList.Values.Min();
            }
            return city.First();


            //Search through the catalogue to find all the cities with the same province
            // foreach(KeyValuePair<string,CityInfo> entry in CityCatalogue)
            // {
            //     if (entry.Value.GetProvince() == province)
            //         CityList.Add(entry.Key,entry.Value);
            // }

            // //Find the city with the lowest population
            // int tempPop = CityList.First().Value.GetPopulation();
            // city = CityList.First().Value;
            // foreach(KeyValuePair<string,CityInfo> entry in CityList)
            // {
            //     if (entry.Value.GetPopulation() < tempPop)
            //     {
            //         city = entry.Value;
            //         tempPop = entry.Value.GetPopulation();
            //     }
            // }

            // return city;
        }// End of DisplaySmallestPopulationCity

        public void ShowCityOnMap(string CityName, string Province)
        {
            // search through the catalogue to find the longitude and latitude of the city

            double lng = 0.0;
            double lat = 0.0;
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province && entry.Key == CityName)
                {
                    Console.WriteLine("Longitude: " + entry.Value[0].GetLongitude());
                    
                    Console.WriteLine("Latitude: " + entry.Value[0].GetLatitude());
                    lng = entry.Value[0].GetLongitude();
                    lat = entry.Value[0].GetLatitude();
                }
            }

            //show the map in google maps with the longitude and latitude of the city
            //load the map with the longitude and latitude of the city
            // open google maps with location of the city from the catalogue using the longitude and latitude
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo { FileName = "https://maps.google.com/?q=" + lat +"," + lng, UseShellExecute = true });
            


            // throw new NotImplementedException();
        }// End of ShowCityOnMap

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
            // throw new NotImplementedException();
        }// End of CalculateDistanceBetweenCities

        public void DisplayProvincePopulation(string Province)
        {
            //display the population of the province
            int population = 0;
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province)
                {
                    population += entry.Value[0].GetPopulation();
                }
            }
            Console.WriteLine("The population of {0} is {1}", Province, population);
        }// End of DisplayProvincePopulation

        public void DisplayProvinceCities(string Province)
        {
            //display the cities in the province
            List<CityInfo> city = null;
            Dictionary<string, List<CityInfo>> CityList = new Dictionary<string, List<CityInfo>>();
            foreach (KeyValuePair<string, List<CityInfo>> entry in CityCatalogue)
            {
                if (entry.Value[0].GetProvince() == Province)
                {
                    CityList.Add(entry.Key, entry.Value);
                }
            }
            if (CityList.Count > 0)
            {
                city = CityList.Values.First();
            }
            foreach (CityInfo entry in city)
            {
                Console.WriteLine(entry.GetName());
            }
        }// End of DisplayProvinceCities
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
