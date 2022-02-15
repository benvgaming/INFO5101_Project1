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
            CityCatalogue = DataModeler.ParseFile(fileName, type);
        }

        public CityInfo DisplayCityInformation(string CityName)
        {
            // we will need to do the logic if there is more than one in here.
            CityInfo city;
            CityCatalogue.TryGetValue(CityName, out city);
            return city;
        }

        public CityInfo DisplayLargestPopulationCity()
        {
            throw new NotImplementedException();
        }

        public CityInfo DisplaySmallestPopulationCity()
        {
            throw new NotImplementedException();
        }

        public void ShowCityOnMap(string CityName, string Province)
        {
            throw new NotImplementedException();
        }

        public void CalculateDistanceBetweenCities(string CityName1, string CityName2)
        {
            throw new NotImplementedException();
        }

        public void DisplayProvincePopulation(string Province)
        {
            throw new NotImplementedException();
        }

        public void DisplayProvinceCities(string Province)
        {
            throw new NotImplementedException();
        }
        public void RankProvincesByPopulation()
        {
            throw new NotImplementedException();
        }

        public void RankProvincesByCities()
        {
            throw new NotImplementedException();
        }

        public CityInfo GetCapital(string Province)
        {
            throw new NotImplementedException();
        }

    }
}
