using System;

namespace Intra.NET.Interfaces
{
    internal interface IEvent
    {
        string Title { get; set; }
        string Link { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        double Completion { get; set; }
        DateTime Registration { get; set; }
    }
}
