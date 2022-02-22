using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    class SortPopByValue : IComparer<CityInfo>
    {
        public int Compare(CityInfo x, CityInfo y)
        {
            return y.GetPopulation().CompareTo(x.GetPopulation());
        }
    }
}
