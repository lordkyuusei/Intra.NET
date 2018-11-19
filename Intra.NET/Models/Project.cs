using Intra.NET.Interfaces;
using System;

namespace Intra.NET.Models
{
    internal class Project : IEvent
    {
        #region Fields
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Start { get; set; }
        public double Completion { get; set; }
        public DateTime Registration { get; set; }
        public DateTime End { get; set; }
        public short IdActivity { get; set; }
        public string DefenceName { get; set; }
        public string DefenceLink { get; set; }
        public DateTime DefenceDate { get; set; }
        public string DefenceRoom { get; set; }
        #endregion

        #region Constructors
        public Project() { }
        public Project(string title, string link, DateTime start, double completion, DateTime registration, DateTime end, short idActivity, string defenceName, string defenceLink, DateTime defenceDate, string defenceRoom)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Start = start;
            Completion = completion;
            Registration = registration;
            End = end;
            IdActivity = idActivity;
            DefenceName = defenceName ?? throw new ArgumentNullException(nameof(defenceName));
            DefenceLink = defenceLink ?? throw new ArgumentNullException(nameof(defenceLink));
            DefenceDate = defenceDate;
            DefenceRoom = defenceRoom ?? throw new ArgumentNullException(nameof(defenceRoom));
        }
        #endregion
    }
}
