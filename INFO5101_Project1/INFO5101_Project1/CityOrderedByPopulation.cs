/* Authors: Manh Cuong Nguyen, Devon Tully, James Thornton
 * Class: CityOrderedByPopulation.cs
 * Purposes: Helper class to make CityInfo class comparable
 */

using System.Collections.Generic;

namespace INFO5101_Project1
{
    public class CityOrderedByPopulation : IComparer<CityInfo>
    {
        public int Compare(CityInfo x, CityInfo y)
        {
            return x.GetPopulation().CompareTo(y.GetPopulation());
        }//End of Compare
    }//End of class
}//End of Namespace
