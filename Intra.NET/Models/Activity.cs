using System;
using Intra.NET.Interfaces;

namespace Intra.NET.Models
{
    internal class Activity : IEvent
    {
        #region Fields
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Completion { get; set; }
        public DateTime Registration { get; set; }
        public string Room { get; set; }
        public string Speaker { get; set; }
        public string Token { get; set; }
        public Uri TokenLink { get; set; }
        public Uri RegisterLink { get; set; }

        public Module Module { get; set; }
        #endregion

        #region Constructors
        public Activity() { }
        public Activity(string title, string link, DateTime start, DateTime end, double completion, DateTime registration, string room, string speaker, string token, Uri tokenLink, Uri registerLink, Module module)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Start = start;
            End = end;
            Completion = completion;
            Registration = registration;
            Room = room ?? throw new ArgumentNullException(nameof(room));
            Speaker = speaker ?? throw new ArgumentNullException(nameof(speaker));
            Token = token ?? throw new ArgumentNullException(nameof(token));
            TokenLink = tokenLink ?? throw new ArgumentNullException(nameof(tokenLink));
            RegisterLink = registerLink ?? throw new ArgumentNullException(nameof(registerLink));
            Module = module ?? throw new ArgumentNullException(nameof(module));
        }
        #endregion
    }
}
