using System;

namespace Laboratorium1.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() => DateTime.Now;
    }
}