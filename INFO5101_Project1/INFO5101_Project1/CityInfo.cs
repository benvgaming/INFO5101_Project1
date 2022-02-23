/* Authors: Manh Cuong Nguyen, Devon Tully, James Thornton
 * Class: CityInfo.cs
 * Purposes: to store city's information
 */


using System;

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
        private string Capital;

        public CityInfo(int CityId, string CityName, string CityAscii, int Population, string Province, double latitude, double longitude, string capital)
        {
            this.CityId = CityId;
            this.CityName = CityName;
            this.CityAscii = CityAscii;
            this.Population = Population;
            this.Province = Province;
            this.latitude = latitude;
            this.longitude = longitude;
            this.Capital = capital;
        }//End of CityInfo

        public string GetProvince()
        {
            return Province;
        }//End of GetProvince

        public int GetPopulation()
        {
            return Population;
        }//End of GetPopulation

        public string GetCapital()
        {
            return Capital;
        }//End of GetCapital
        public Tuple<double, double> GetLocation()
        {
            return new Tuple<double, double>(latitude, longitude);
        }//End of GetLocation
        public double GetLatitude()
        {
            return latitude;
        }//End of GetLatitude
        public double GetLongitude()
        {
            return longitude;
        }//End of GetLongitude

        public string GetName()
        {
            return CityName;
        }//End of GetName
    }//End of class
}//End of namespace
