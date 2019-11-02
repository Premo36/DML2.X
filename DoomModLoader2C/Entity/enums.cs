using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoomModLoader2.Entity
{

    public enum mode
    {
        SAVE,
        RESTORE,
        DELETE
    }

    public enum order
    {
        NAME_ASCENDING = 0,
        NAME_DESCENDING = 1,
        EXTENSION_ASCENDING = 2,
        EXTENSION_DESCENDING = 3,
    }
}


