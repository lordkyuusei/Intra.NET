using System;

namespace Intra.NET.Models
{
    internal class LastGrade
    {
        #region Fields
        public string Title { get; set; }
        public string Link { get; set; }
        public int Note { get; set; }
        public string Reviewer { get; set; }    
        #endregion

        #region Constructor
        public LastGrade() { }
        public LastGrade(string title, string link, int note, string reviewer)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Note = note;
            Reviewer = reviewer ?? throw new ArgumentNullException(nameof(reviewer));
        }
        #endregion
    }
}
