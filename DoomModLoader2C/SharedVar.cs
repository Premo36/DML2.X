using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoomModLoader2
{
    public static class SharedVar
    {
        public static string LOCAL_VERSION { get; } = "2.2 Beta #5";
        public static bool CHECK_FOR_UPDATE { get; set; }
        public  static  string UrlVersion { get; } = @"https://drive.google.com/uc?export=download&id=1lXEz8sXjJGma0Q34Bj-mpjTtVW8RK-W4";

        //Alert preferences
        public static bool SHOW_END_MESSAGE { get; set; } = true;
        public static bool SHOW_OVERWRITE_MESSAGE { get; set; } = true;
        public static bool SHOW_SUCCESS_MESSAGE { get; set; } = true;
        public static bool SHOW_DELETE_MESSAGE { get; set; } = true;
        public static bool USE_ADVANCED_SELECTION_MODE { get; set; } = false;
    }
}
