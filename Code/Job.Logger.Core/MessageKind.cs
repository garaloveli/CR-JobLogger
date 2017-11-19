using System;
namespace Job.Logger.Core
{
    [Flags]
    public enum MessageKind
    {
        None = 0,
        Error = 1,
        Message = 2,
        Warning = 4,
        Success = 8,

        All = 15 //This number will change if the options change
    }
}
