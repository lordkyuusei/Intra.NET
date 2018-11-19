using Intra.NET.Interfaces;
using System;

namespace Intra.NET.Models
{
    class Module : IEvent
    {
        #region Fields
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Start { get; set; }
        public double Completion { get; set; }
        public DateTime Registration { get; set; }
        public DateTime End { get; set; }
        #endregion

        #region Constructors
        public Module() { }
        public Module(string title, string link, DateTime start, double completion, DateTime registration, DateTime end)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Start = start;
            Completion = completion;
            Registration = registration;
            End = end;
        }

        public String GetModuleCode()
        {
            return Link.Split(@"/")[2];
        }
        #endregion
    }
}
