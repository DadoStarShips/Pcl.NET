using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{
    public abstract class ExtractIndices<PointT> : Filter<PointT> where PointT : unmanaged
    {
        /// <summary>
        /// Set whether the output point cloud should be organized or not. If set to true, the output will have the same structure as the input point cloud with filtered points having the value (NaN,NaN,NaN)
        /// </summary>
        public abstract bool KeepOrganized { get; set; }
        /// <summary>
        /// Set whether the regular conditions for points filtering should apply, or the inverted conditions
        /// </summary>
        public abstract bool IsNegative { get; set; }
    }
}
