using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DoomModLoader2.Entity
{
    public class PathName
    {
        public string name { get; set; }
        public string path { get; set; }
        public int loadOrder { get; set; }
    }

    public static class PathNameUtils
    {
        public static List<PathName> OrderFile(this List<PathName> pathNames, order order) {

            switch (order)
            {
                case order.EXTENSION_ASCENDING:
                    pathNames = pathNames.OrderBy(P => Path.GetExtension(P.path)).ToList();
                    break;
                case order.EXTENSION_DESCENDING:
                    pathNames = pathNames.OrderByDescending(P => Path.GetExtension(P.path)).ToList();
                    break;
                case order.NAME_ASCENDING:
                    pathNames = pathNames.OrderBy(P => P.name).ToList();
                    break;
                case order.NAME_DESCENDING:
                    pathNames = pathNames.OrderByDescending(P => P.name).ToList();
                    break;
            }

            return pathNames;


        }

    }

}
