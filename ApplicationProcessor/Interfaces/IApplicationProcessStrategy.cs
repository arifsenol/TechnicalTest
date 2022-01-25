namespace Ulaw.ApplicationProcessor.Interfaces
{
    using ULaw.ApplicationProcessor.Models;

    public interface IApplicationProcessStrategy
    {
        void BuildEmailContent(Application application);
    }
}
