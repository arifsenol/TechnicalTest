namespace Ulaw.ApplicationProcessor.Services
{
    using Ulaw.ApplicationProcessor.Business;
    using Ulaw.ApplicationProcessor.Interfaces;
    using ULaw.ApplicationProcessor.Enums;
    using ULaw.ApplicationProcessor.Models;

    public class ApplicationService : IApplicationService
    {
        // If we were to use an IOC framework (just like in .Net Core, Castle or Ninject) we have to setup them on the startup

        #region Fields
        private DegreeGradeTwoTwoApplicationProcessStrategy DegreeGradeTwoTwoApplicationProcessStrategy { get; set; }
        private DegreeGradeThirdApplicationProcessStrategy DegreeGradeThirdApplicationProcessStrategy { get; set; }
        private DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy { get; set; }
        private DefaultApplicationProcessStrategy DefaultApplicationProcessStrategy { get; set; }
        #endregion

        #region Constructor
        public ApplicationService(DegreeGradeTwoTwoApplicationProcessStrategy degreeGradeTwoTwoApplicationProcessStrategy,
            DegreeGradeThirdApplicationProcessStrategy degreeGradeThirdApplicationProcessStrategy,
            DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy degreeSubjectLawOrLawAndBusinessApplicationProcessStrategy,
            DefaultApplicationProcessStrategy defaultApplicationProcessStrategy)
        {
            DegreeGradeTwoTwoApplicationProcessStrategy = degreeGradeTwoTwoApplicationProcessStrategy;
            DegreeGradeThirdApplicationProcessStrategy = degreeGradeThirdApplicationProcessStrategy;
            DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy = degreeSubjectLawOrLawAndBusinessApplicationProcessStrategy;
            DefaultApplicationProcessStrategy = defaultApplicationProcessStrategy;
        }
        #endregion

        /*
         I know the logic is simple but I would like to show you how single responsibility principle can be implemented
         Strategy pattern used, because I wanted to have all logic separately implemented
         I have not spent more time on namings eg: classnames or method names
        */

        #region Explicit Interface Events
        /// <summary>
        /// Return email content
        /// </summary>
        /// <param name="application"></param>
        /// <returns>A string representing the compiled html email content</returns> 
        public string Process(Application application)
        {
            var applicationContext = new ApplicationContext(DefaultApplicationProcessStrategy);

            if (application.DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                applicationContext.SetStrategy(DegreeGradeTwoTwoApplicationProcessStrategy);
                return applicationContext.Process(application);
            }

            if (application.DegreeGrade == DegreeGradeEnum.third)
            {
                applicationContext.SetStrategy(DegreeGradeThirdApplicationProcessStrategy);
                return applicationContext.Process(application);
            }

            if (application.DegreeSubject == DegreeSubjectEnum.law || application.DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
            {
                applicationContext.SetStrategy(DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy);
                return applicationContext.Process(application);
            }

            return applicationContext.Process(application);
        }
        #endregion
    }
}
