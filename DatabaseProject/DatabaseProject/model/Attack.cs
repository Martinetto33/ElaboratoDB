using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    internal class Attack(string id)
    {
        public string Id { get; set; } = id;
        public int? ObtainedPercentage { get; set; } = null;
        public int? ObtainedStars { get; set; } = null;
        public long? TimeTakenMS { get; set; } = null;
    }
}
