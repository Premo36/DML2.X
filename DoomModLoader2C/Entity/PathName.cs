// Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
BSD 3-Clause License

Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DoomModLoader2.Entity
{
    public class PathName
    {
        public string name { get; set; }
        public string path { get; set; }
        public int loadOrder { get; set; }
        public string nameWithFolder { get {
                return Path.Combine(Path.GetFileName(Path.GetDirectoryName(path)),name).ToUpper();
            }
        }

        //public string nameWithFullPath
        //{
        //    get
        //    {
        //        return Path.Combine(Path.GetDirectoryName(path), name).ToUpper();
        //    }
        //}
    }

    public static class PathNameUtils
    {
        /// <summary>
        /// Order a given list of Pathname with the given order
        /// </summary>
        /// <param name="pathNames"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static List<PathName> OrderFile(this List<PathName> pathNames, order order)
        {

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
                case order.FOLDER_ASCENDING:
                    pathNames = pathNames.OrderBy(P => P.nameWithFolder).ToList();
                    break;
                case order.FOLDER_DESCENDING:
                    pathNames = pathNames.OrderByDescending(P => P.nameWithFolder).ToList();
                    break;
                case order.PATH_ASCENDING:
                    pathNames = pathNames.OrderBy(P => P.path).ToList();
                    break;
                case order.PATH_DESCENDING:
                    pathNames = pathNames.OrderByDescending(P => P.path).ToList();
                    break;
            }

            return pathNames;


        }



    }

}
