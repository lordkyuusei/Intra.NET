using System;

namespace Intra.NET.Models
{
    internal class LastGrade
    {
        #region Fields
        #pragma warning disable IDE1006 // Naming Styles
        public string title { get; set; }
        public string title_link { get; set; }
        public int note { get; set; }
        public string noteur { get; set; }    
        #pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Constructor
        public LastGrade() { }
        public LastGrade(string title, string link, int grade, string reviewer)
        {
            title = title ?? throw new ArgumentNullException(nameof(title));
            title_link = link ?? throw new ArgumentNullException(nameof(link));
            note = grade;
            noteur = reviewer ?? throw new ArgumentNullException(nameof(reviewer));
        }
        #endregion
    }
}
