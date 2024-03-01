using System;

namespace SnappFood.Framework.Core.Abstractions;

public interface IEvent
{
    public DateTime? PublishedOn { get; set; }
}
