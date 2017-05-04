using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesIO
{
    public class Options
    {
        /// <summary> 
        /// The Extension of the Resource Files.
        /// Important! It has to with a dot!
        /// </summary>
        public static string Extension { get; set; }

        /// <summary>
        /// The PreName e.g. resource_ => resource_test.extension
        /// </summary>
        public static string NameAdditional { get; set; }
    }
}
