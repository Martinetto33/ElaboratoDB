using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.config
{
    public static class Configuration
    {
        public static readonly double UPGRADE_TIME_PER_LEVEL = 5.0; // the number of seconds per level to upgrade a building or troop

        public static readonly int MAX_LEVEL = 6; // the maximum level for a building or troop
    }
}
