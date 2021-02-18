// Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)
// All rights reserved.
using DoomModLoader2.Entity;
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

namespace DoomModLoader2
{
    /// <summary>
    /// Global variables used across the whole application
    /// </summary>
    public static class SharedVar
    {
        public static string LOCAL_VERSION { get; } = "2.4 [Beta #7 | RC #2]";
        public static bool CHECK_FOR_UPDATE { get; set; }
        public static string UrlVersion { get; } = @"https://p36software.net/downloads/download_page.php?id=DML2&toJSON";

        //Alert preferences
        public static bool SHOW_END_MESSAGE { get; set; } = true;
        public static bool SHOW_OVERWRITE_MESSAGE { get; set; } = true;
        public static bool SHOW_SUCCESS_MESSAGE { get; set; } = true;
        public static bool SHOW_DELETE_MESSAGE { get; set; } = true;
        public static bool USE_ADVANCED_SELECTION_MODE { get; set; } = false;
        public static fileViewMode FILE_VIEW_MODE { get; set; } = fileViewMode.ONLY_FILE_NAME;
    }
}
