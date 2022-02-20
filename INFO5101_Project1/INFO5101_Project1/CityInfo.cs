using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    public class CityInfo
    {
        private int CityId;
        private string CityName;
        private string CityAscii;
        private int Population;
        private string Province;
        private double latitude;
        private double longitude;
        private bool IsCapital = false; //not included in the pdf

        public CityInfo(int CityId, string CityName, string CityAscii, int Population, string Province, double latitude, double longitude)
        {
            this.CityId = CityId;
            this.CityName = CityName;
            this.CityAscii = CityAscii;
            this.Population = Population;
            this.Province = Province;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string GetProvince()
        {
            return Province;
        }

        public int GetPopulation()
        {
            return Population;
        }

        public Tuple<double, double> GetLocation()
        {
            return new Tuple<double, double>(latitude, longitude);
        }

        public string GetName()
        {
            return CityName;
        }
        
    }//End of class
}//End of namespace
