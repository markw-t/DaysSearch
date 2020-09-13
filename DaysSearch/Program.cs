using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.DayOfWeek;

namespace DaysSearch
{
    class Program
    {
        static void Main()
        {
            var inputs = new[]
            {
                new SearchInput { WeekDay = Monday, Value = "Sunny" },
                new SearchInput { WeekDay = Tuesday, Value = "cloudless" }
            };

            var weeks = GetSunnyWeeks(inputs);

            Console.WriteLine($"Total of sunny weeks found: {weeks.Count()}");
            Console.ReadKey(true);
        }

        static IEnumerable<WeekDays> GetSunnyWeeks(IEnumerable<SearchInput> inputs)
        {
            using var db = new DaysSearchContext();

            db.Database.EnsureCreated();

            var query = db.WeekDays.AsNoTracking();

            foreach (var input in inputs)
            {
                switch (input.WeekDay)
                {
                    case Monday:
                        query = query.Where(x => EF.Functions.Like(x.Monday, $"%{input.Value}%"));
                        break;
                    case Tuesday:
                        query = query.Where(x => EF.Functions.Like(x.Tuesday, $"%{input.Value}%"));
                        break;
                    case Wednesday:
                        break;
                    case Thursday:
                        break;
                    case Friday:
                        break;
                    case Saturday:
                        break;
                    case Sunday:
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return query.ToList();
        }
    }
}
