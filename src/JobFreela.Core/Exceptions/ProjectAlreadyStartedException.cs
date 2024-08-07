namespace JobFreela.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException() : base ("PROJECT_ALREADY_IN_STARTED_STATUS")
    {
        
    }
}
