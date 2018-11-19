using Intra.NET.Enums;
using System;

namespace Intra.NET.Models
{
    internal class History
    {
        #region Fields
        public string Title { get; set; }
        public Sender User { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public short Id { get; set; }
        public bool IsVisible { get; set; }
        public short IdActivity { get; set; }
        public Class ClassType { get; set; }
        #endregion

        #region Constructors
        public History() { }
        public History(string title, Sender user, string content, DateTime date, short id, bool isVisible, short idActivity, Class classType)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            User = user ?? throw new ArgumentNullException(nameof(user));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Date = date;
            Id = id;
            IsVisible = isVisible;
            IdActivity = idActivity;
            ClassType = classType;
        }
        #endregion

        #region Classes
        internal class Sender
        {
            public Uri Picture { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
        }
        #endregion
    }
}
