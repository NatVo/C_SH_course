using System;
using System.Collections.Generic;
using System.Globalization;
using Lesson.Libs.Common.Types;

namespace LessonDebugExceptions
{
    public class DateRangePackage
    {
        public List<DateRange> DateRanges { get; set; }

        public DateRangePackage( List<DateRange> dateRanges )
        {
            // присвоение переменной DateRanges значение параметра dateRanges в конструкторе, иначе её значение будет NULL, что приводит к ошибке
            DateRanges = dateRanges;
        }

        public override string ToString()
        {
            return "["
                + String.Join(
                    ", ",
                    DateRanges.ConvertAll(
                        dateRange => $"[{dateRange.StartDate.ToString( "yyyy-MM-dd", CultureInfo.InvariantCulture )},"
                            + $" {dateRange.EndDate.ToString( "yyyy-MM-dd", CultureInfo.InvariantCulture )}]" ) )
                + "]";
        }
    }
}
