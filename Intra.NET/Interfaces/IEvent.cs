using System;

#pragma warning disable IDE1006 // Naming Styles because Intra API
namespace Intra.NET.Interfaces
{
    internal interface IEvent
    {
        string title { get; set; }
        string title_link { get; set; }
        DateTime timeline_start { get; set; }
        DateTime timeline_end { get; set; }
        double timeline_barre { get; set; }
        DateTime date_inscription { get; set; }
    }
}
#pragma warning restore IDE1006 // Naming Styles because Intra API
