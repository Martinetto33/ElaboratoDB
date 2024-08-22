namespace DatabaseProject.model.code
{
    public class BuilderBusyException(string message) : Exception(message) { }
    public class LaboratoryBusyException(string message) : Exception(message) { }
}
