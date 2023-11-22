namespace DevFreela.Core.Exceptions;
public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException() : base("Projet is already started")
    {

    }
}
