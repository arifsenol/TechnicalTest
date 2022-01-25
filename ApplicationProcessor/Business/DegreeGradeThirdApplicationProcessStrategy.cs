namespace Ulaw.ApplicationProcessor.Business
{
    using System.Text;
    using ULaw.ApplicationProcessor.Models;

    public class DegreeGradeThirdApplicationProcessStrategy : ApplicationProcessStrategyBase
    {
        public override void BuildEmailBody(Application application)
        {
            StringBuilder.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
            StringBuilder.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
            StringBuilder.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            StringBuilder.Append("<br> Yours sincerely,");
            StringBuilder.Append("<p/> The Admissions Team,");
        }
    }
}
