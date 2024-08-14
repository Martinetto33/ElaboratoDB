using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    public class BuilderBusyException(string message) : Exception(message) { }
    public class LaboratoryBusyException(string message) : Exception(message) { }
}
