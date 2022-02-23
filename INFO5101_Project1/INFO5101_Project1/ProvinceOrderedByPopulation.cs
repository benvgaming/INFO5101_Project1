/* Authors: Manh Cuong Nguyen, Devon Tully, James Thornton
 * Class: ProvinceOrderedByPopulation.cs
 * Purposes: Helper class to make Tuple comparable
 */

using System;
using System.Collections.Generic;

namespace INFO5101_Project1
{
    public class ProvinceOrderedByPopulation : IComparer<Tuple<string, long>>
    {
        public int Compare(Tuple<string, long> x, Tuple<string, long> y)
        {
            return y.Item2.CompareTo(x.Item2);
        }//End of Compare
    }//End of class
}//End of namespace
