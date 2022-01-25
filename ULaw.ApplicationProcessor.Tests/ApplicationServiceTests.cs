namespace ULaw.ApplicationProcessor.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ulaw.ApplicationProcessor.Services;
    using ULaw.ApplicationProcessor.Models;
    using ULaw.ApplicationProcessor.Enums;
    using Ulaw.ApplicationProcessor.Business;
    using Ulaw.ApplicationProcessor.Interfaces;

    [TestClass]
    public class ApplicationServiceTests
    {
        // added mock sample for services

        Mock<DegreeGradeTwoTwoApplicationProcessStrategy> degreeGradeTwoTwoApplicationProcessStrategyMock;
        Mock<DegreeGradeThirdApplicationProcessStrategy> degreeGradeThirdApplicationProcessStrategyMock;
        IApplicationService applicationService;

        [TestInitialize]
        public void SetUp()
        {
            degreeGradeTwoTwoApplicationProcessStrategyMock = new Mock<DegreeGradeTwoTwoApplicationProcessStrategy>();
            degreeGradeThirdApplicationProcessStrategyMock = new Mock<DegreeGradeThirdApplicationProcessStrategy>();
            applicationService = new ApplicationService(degreeGradeTwoTwoApplicationProcessStrategyMock.Object,
                degreeGradeThirdApplicationProcessStrategyMock.Object,
                new DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy(),
                new DefaultApplicationProcessStrategy());
        }

        private const string FurtherInfoEmailResult = @"<html><body><h1>Your Recent Application from the University of Law</h1></body></html>";


        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegreeStrategyShouldBeVerified()
        {
            degreeGradeTwoTwoApplicationProcessStrategyMock.Setup(p => p.BuildEmailBody(It.IsAny<Application>())).Verifiable();

            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoTwo;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.English;

            string emailHtml = applicationService.Process(thisSubmission);
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
            degreeGradeTwoTwoApplicationProcessStrategyMock.Verify(p => p.BuildEmailBody(thisSubmission), Times.Once());
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegreeStrategyShouldBeVerified()
        {
            degreeGradeThirdApplicationProcessStrategyMock.Setup(p => p.BuildEmailBody(It.IsAny<Application>())).Verifiable();

            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.third;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.maths;

            string emailHtml = applicationService.Process(thisSubmission);
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
            degreeGradeThirdApplicationProcessStrategyMock.Verify(p => p.BuildEmailBody(thisSubmission), Times.Once());
        }

    }
}
