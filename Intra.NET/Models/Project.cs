using Intra.NET.Interfaces;
using System;

namespace Intra.NET.Models
{
    internal class Project : IEvent
    {
        #region Fields
        #pragma warning disable IDE1006 // Naming Styles because Intra API
        public string title { get; set; }
        public string title_link { get; set; }
        public DateTime timeline_start { get; set; }
        public DateTime timeline_end { get; set; }
        public double timeline_barre { get; set; }
        public DateTime date_inscription { get; set; }
        public short id_activity { get; set; }
        public string soutenance_name { get; set; }
        public string soutenance_link { get; set; }
        public DateTime soutenance_date { get; set; }
        public string soutenance_salle { get; set; }
        #pragma warning restore IDE1006 // Naming Styles because Intra API
        #endregion

        #region Constructors
        public Project() { }
        public Project(string title, string link, DateTime start, double completion, DateTime registration, DateTime end, short idActivity, string defenceName, string defenceLink, DateTime defenceDate, string defenceRoom)
        {
            title = title ?? throw new ArgumentNullException(nameof(title));
            title_link = link ?? throw new ArgumentNullException(nameof(link));
            timeline_start = start;
            timeline_barre = completion;
            date_inscription = registration;
            timeline_end = end;
            id_activity = idActivity;
            soutenance_name = defenceName ?? throw new ArgumentNullException(nameof(defenceName));
            soutenance_link = defenceLink ?? throw new ArgumentNullException(nameof(defenceLink));
            soutenance_date = defenceDate;
            soutenance_salle = defenceRoom ?? throw new ArgumentNullException(nameof(defenceRoom));
        }
        #endregion
    }
}
