using System;
namespace Job.Logger.Services.Flags
{
    [Flags]
    public enum ProviderKind
    {
        None = 0,
        File = 1,
        Console = 2,
        Database = 4,
        All = 7
    }
}
