using Intra.NET.Interfaces;
using System;

namespace Intra.NET.Models
{
    class Module : IEvent
    {
        #region Fields
        #pragma warning disable IDE1006 // Naming Styles because Intra API
        public string title { get; set; }
        public string title_link { get; set; }
        public DateTime timeline_start { get; set; }
        public DateTime timeline_end { get; set; }
        public double timeline_barre { get; set; }
        public DateTime date_inscription { get; set; }
        #pragma warning restore IDE1006 // Naming Styles because Intra API
        #endregion

        #region Constructors
        public Module() { }
        public Module(string title, string link, DateTime start, double completion, DateTime registration, DateTime end)
        {
            title = title ?? throw new ArgumentNullException(nameof(title));
            title_link = link ?? throw new ArgumentNullException(nameof(link));
            timeline_start = start;
            timeline_barre = completion;
            date_inscription = registration;
            timeline_end = end;
        }

        public String GetModuleCode()
        {
            return title_link.Split(@"/")[2];
        }
        #endregion
    }
}
