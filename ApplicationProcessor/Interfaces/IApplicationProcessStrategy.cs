namespace Ulaw.ApplicationProcessor.Interfaces
{
    using ULaw.ApplicationProcessor.Models;

    public interface IApplicationProcessStrategy
    {
        void BuildEmailBody(Application application);
    }
}
