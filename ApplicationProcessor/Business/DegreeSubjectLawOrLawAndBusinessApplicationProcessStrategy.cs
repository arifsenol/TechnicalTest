namespace Ulaw.ApplicationProcessor.Business
{
    using System.Text;
    using ULaw.ApplicationProcessor;
    using ULaw.ApplicationProcessor.Models;
    public class DegreeSubjectLawOrLawAndBusinessApplicationProcessStrategy : ApplicationProcessStrategyBase
    {
        public override void BuildEmailBody(Application application)
        {
            // should be coming from config or 3rd party service
            decimal depositAmount = 350.00M;

            StringBuilder.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
            StringBuilder.AppendFormat("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", application.CourseCode, application.StartDate.ToLongDateString());
            StringBuilder.AppendFormat("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", application.DegreeSubject.ToDescription(), application.DegreeGrade.ToDescription());
            StringBuilder.AppendFormat("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString());
            StringBuilder.AppendFormat("<br/> We look forward to welcoming you to the University,");
            StringBuilder.AppendFormat("<br/> Yours sincerely,");
            StringBuilder.AppendFormat("<p/> The Admissions Team,");
        }
    }
}
