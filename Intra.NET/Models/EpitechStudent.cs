using System.Collections.Generic;
using System.ComponentModel;

namespace Intra.NET.Models
{
    class EpitechStudent
    {
        private static EpitechStudent student = null;
        private static readonly object padlock = new object();

        internal string UserName { get; set; }
        internal List<Module> Modules { get; set; }
        internal List<Project> Projects { get; set; }
        internal List<LastGrade> Grades { get; set; }
        internal List<Activity> Activities { get; set; }
        internal List<History> History { get; set; }
        internal ushort CurrentCredits { get; set; }

        public static EpitechStudent Instance
        {
            get
            {
                lock (padlock)
                {
                    if (student == null)
                    {
                        student = new EpitechStudent();
                    }
                    return student;
                }
            }
        }

        /// <summary>
        /// An EpitechStudent Instance. It encapsulates every single score and data about a student given its username.
        /// </summary>
        /// <param name="username"></param>
        public EpitechStudent() { }


    }
}
