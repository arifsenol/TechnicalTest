namespace Ulaw.ApplicationProcessor.Interfaces
{
    using ULaw.ApplicationProcessor.Models;

    public interface IApplicationService
    {
        string Process(Application application);
    }
}
