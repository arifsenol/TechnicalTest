namespace ULaw.ApplicationProcessor.Models
{
    using System;
    using System.Text;
    using ULaw.ApplicationProcessor.Enums;

    public class Application
    {
        public Application(string faculty, string courseCode, DateTime startDate, string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa)
        {
            ApplicationId = new Guid();
            Faculty = faculty;
            CourseCode = courseCode;
            StartDate = startDate;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            RequiresVisa = requiresVisa;
        }

        #region Public Properties
        
        public Guid ApplicationId { get; private set; }
        public string Faculty { get; private set; }
        public string CourseCode { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool RequiresVisa { get; private set; }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }

        #endregion       
    }
}

