// -----------------------------------------------------------------------
// <copyright file="DateTimeProvider.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DayTimer
{
    using System;
    using System.Collections.Generic;

    //using System.Linq;
    using System.Text;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}