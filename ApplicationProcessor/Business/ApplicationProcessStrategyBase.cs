namespace Ulaw.ApplicationProcessor.Business
{
    using System.Text;
    using Ulaw.ApplicationProcessor.Interfaces;
    using ULaw.ApplicationProcessor.Models;

    public abstract class ApplicationProcessStrategyBase : IApplicationProcessStrategy
    {
        protected StringBuilder StringBuilder { get; set; }

        public ApplicationProcessStrategyBase()
        {
            StringBuilder = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");
        }

        public abstract void BuildEmailBody(Application application);

        public string Process(Application application)
        {
            this.BuildEmailBody(application);
            StringBuilder.Append(string.Format("</body></html>"));
            return StringBuilder.ToString();
        }
    }
}
