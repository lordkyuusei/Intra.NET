using System;
using Intra.NET.Interfaces;

namespace Intra.NET.Models
{
    internal class Activity : IEvent
    {
        #region Fields
        #pragma warning disable IDE1006 // Naming Styles because Intra API
        public string title { get; set; }
        public string title_link { get; set; }
        public DateTime timeline_start { get; set; }
        public DateTime timeline_end { get; set; }
        public double timeline_barre { get; set; }
        public DateTime date_inscription { get; set; }

        public string salle { get; set; }
        public string intervenant { get; set; }
        public string token { get; set; }
        public Uri token_link { get; set; }
        public Uri register_link { get; set; }
        #pragma warning restore IDE1006 // Naming Styles because Intra API

        public Module Module { get; set; }
        #endregion

        #region Constructors
        public Activity() { }
        public Activity(string title, string link, DateTime start, DateTime end, double completion, DateTime registration, string room, string speaker, string token, Uri tokenLink, Uri registerLink, Module module)
        {
            title = title ?? throw new ArgumentNullException(nameof(title));
            title_link = link ?? throw new ArgumentNullException(nameof(link));
            timeline_start = start;
            timeline_end = end;
            timeline_barre = completion;
            date_inscription = registration;
            salle = room ?? throw new ArgumentNullException(nameof(room));
            intervenant = speaker ?? throw new ArgumentNullException(nameof(speaker));
            token = token ?? throw new ArgumentNullException(nameof(token));
            token_link = tokenLink ?? throw new ArgumentNullException(nameof(tokenLink));
            register_link = registerLink ?? throw new ArgumentNullException(nameof(registerLink));
            Module = module ?? throw new ArgumentNullException(nameof(module));
        }
        #endregion
    }
}
