namespace ULaw.ApplicationProcessor.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ulaw.ApplicationProcessor.Business;
    using ULaw.ApplicationProcessor.Enums;
    using ULaw.ApplicationProcessor.Models;

    [TestClass]
    public class StrategyTests
    {
        // to test single strategy results AKA unit testing of a single method
        private const string OfferEmailForTwoOneLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";

        //naming convention sample for test method names
        [TestMethod]
        public void DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy_Process_Should_Match()
        {
            DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy strategy = new DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy();
            Application thisSubmission = new Application("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);

            thisSubmission.DegreeGrade = DegreeGradeEnum.twoOne;
            thisSubmission.DegreeSubject = DegreeSubjectEnum.lawAndBusiness;

            string emailHtml = strategy.Process(thisSubmission);
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

    }
}
