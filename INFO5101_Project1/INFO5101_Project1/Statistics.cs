using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    public class Statistics
    {
        public Dictionary<string, CityInfo> CityCatalogue;

        public Statistics(string fileName, string type)
        {
            //CityCatalogue = DataModeler.ParseFile(fileName, type);
        } //End of c'tor

        public CityInfo DisplayCityInformation(string CityName)
        {
            // we will need to do the logic if there is more than one in here.
            CityInfo city;
            CityCatalogue.TryGetValue(CityName, out city);
            return city;
        }// End of DisplayCityInformation

        public CityInfo DisplayLargestPopulationCity(string province)
        {
            CityInfo city = null;
            Dictionary<string, CityInfo> CityList = new Dictionary<string, CityInfo>();

            //Search through the catalogue to find all the cities with the same province
            foreach(KeyValuePair<string,CityInfo> entry in CityCatalogue)
            {
                if (entry.Value.GetProvince() == province)
                    CityList.Add(entry.Key,entry.Value);
            }

            //Find the city with the highest population
            int tempPop = 0;

            foreach(KeyValuePair<string,CityInfo> entry in CityList)
            {
                if (entry.Value.GetPopulation() > tempPop)
                {
                    city = entry.Value;
                    tempPop = entry.Value.GetPopulation();
                }
            }

            return city;
        }// End of DisplayLargestPopulationCity

        public CityInfo DisplaySmallestPopulationCity(string province)
        {
            CityInfo city = null;
            Dictionary<string, CityInfo> CityList = new Dictionary<string, CityInfo>();

            //Search through the catalogue to find all the cities with the same province
            foreach(KeyValuePair<string,CityInfo> entry in CityCatalogue)
            {
                if (entry.Value.GetProvince() == province)
                    CityList.Add(entry.Key,entry.Value);
            }

            //Find the city with the lowest population
            int tempPop = CityList.First().Value.GetPopulation();
            city = CityList.First().Value;
            foreach(KeyValuePair<string,CityInfo> entry in CityList)
            {
                if (entry.Value.GetPopulation() < tempPop)
                {
                    city = entry.Value;
                    tempPop = entry.Value.GetPopulation();
                }
            }

            return city;
        }// End of DisplaySmallestPopulationCity

        public void ShowCityOnMap(string CityName, string Province)
        {
            throw new NotImplementedException();
        }// End of ShowCityOnMap

        public void CalculateDistanceBetweenCities(string CityName1, string CityName2)
        {
            throw new NotImplementedException();
        }// End of CalculateDistanceBetweenCities

        public void DisplayProvincePopulation(string Province)
        {
            throw new NotImplementedException();
        }// End of DisplayProvincePopulation

        public void DisplayProvinceCities(string Province)
        {
            throw new NotImplementedException();
        }// End of DisplayProvinceCities
        public void RankProvincesByPopulation()
        {
            throw new NotImplementedException();
        }// End of RankProvincesByPopulation

        public void RankProvincesByCities()
        {
            throw new NotImplementedException();
        }// End of RankProvinceByCities

        public CityInfo GetCapital(string Province)
        {
            throw new NotImplementedException();
        }// End of GetCapital

    }//End of class
}//End of namespace
