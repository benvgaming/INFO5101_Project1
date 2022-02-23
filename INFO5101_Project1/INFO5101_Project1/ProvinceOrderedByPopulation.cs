using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO5101_Project1
{
    public class ProvinceOrderedByPopulation : IComparer<Tuple<string, long>>
    {
        public int Compare(Tuple<string, long> x, Tuple<string, long> y)
        {
            return y.Item2.CompareTo(x.Item2);
        }
    }
}
