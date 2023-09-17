using System;

namespace Rabo_Test_FunctionApp.Model
{
    public interface IHasModificationTime
    {
        DateTime? LastModificationTime { get; set; }
    }
}
