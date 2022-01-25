using ULaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Business
{
    public class ApplicationContext
    {
        private ApplicationProcessStrategyBase strategy;

        public ApplicationContext(ApplicationProcessStrategyBase strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(ApplicationProcessStrategyBase strategy)
        {
            this.strategy = strategy;
        }

        public string Process(Application application)
        {
            return strategy.Process(application);
        }
    }
}
