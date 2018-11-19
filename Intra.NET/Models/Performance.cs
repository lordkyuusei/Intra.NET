using System;
using Intra.NET.Enums;

namespace Intra.NET.Models
{
    internal class Performance
    {
        #region Fields

        #endregion
        public int MinCredits { get; set; }
        public int MaxCredits { get; set; }
        public int ObjCredits { get; set; }
        public int Credits { get; set; }
        public Grade Grade { get; set; }
        public Scope Scope { get; set; }
        public string ModuleCode { get; set; }

        #region Constructors
        public Performance(int minCredits, int maxCredits, int objCredits, int credits, Grade grade, Scope scope, string moduleCode)
        {
            MinCredits = minCredits;
            MaxCredits = maxCredits;
            ObjCredits = objCredits;
            Credits = credits;
            Grade = grade;
            Scope = scope;
            ModuleCode = moduleCode ?? throw new ArgumentNullException(nameof(moduleCode));
        }
        #endregion

    }
}
