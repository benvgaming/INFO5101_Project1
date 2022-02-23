using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    public class CityOrderedByPopulation : IComparer<CityInfo>
    {
        public int Compare(CityInfo x, CityInfo y)
        {
            return x.GetPopulation().CompareTo(y.GetPopulation());
        }

    }
}
