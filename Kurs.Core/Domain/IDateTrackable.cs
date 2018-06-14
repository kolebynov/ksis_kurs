using System;

namespace Kurs.Core.Domain
{
    public interface IDateTrackable
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}