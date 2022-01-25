namespace Ulaw.ApplicationProcessor.Business
{
    using System.Text;
    using ULaw.ApplicationProcessor.Models;

    public class DegreeGradeTwoTwoApplicationProcessStrategy : ApplicationProcessStrategyBase
    {
        public override void BuildEmailBody(Application application)
        {
            StringBuilder.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
            StringBuilder.AppendFormat("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", application.CourseCode, application.StartDate.ToLongDateString());
            StringBuilder.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            StringBuilder.Append("<br/> Yours sincerely,");
            StringBuilder.Append("<p/> The Admissions Team,");
        }
    }
}
