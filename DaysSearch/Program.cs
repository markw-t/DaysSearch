using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DaysSearch.WeekDaysEnum;

namespace DaysSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new List<SearchInput>();

            inputs.AddRange(new[]
            {
                new SearchInput
                {
                    WeekDay = Monday,
                    Value = "Sunny"
                },
                new SearchInput
                {
                    WeekDay = Tuesday,
                    Value = "Rainy"
                }
            });

            var weeks = GetWeeks(inputs);

            Console.WriteLine($"Total weeks found: {weeks.Count()}");
        }

        static IEnumerable<WeekDays> GetWeeks(IEnumerable<SearchInput> inputs)
        {
            using var db = new DaysSearchContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.WeekDays.Add(new WeekDays { Id = Guid.NewGuid(), Monday = "Sunny", Tuesday = "Rainy" });
            db.WeekDays.Add(new WeekDays { Id = Guid.NewGuid(), Wednesday = "Cloudless" });
            db.WeekDays.Add(new WeekDays { Id = Guid.NewGuid(), Friday = "Rainy" });

            db.SaveChanges();

            var query = db.WeekDays.AsNoTracking();

            foreach (var input in inputs)
            {
                switch (input.WeekDay)
                {
                    case Monday:
                        query = query.Where(x => x.Monday.ToLower() == input.Value.ToLower());
                        break;
                    case Tuesday:
                        query = query.Where(x => x.Tuesday.ToLower() == input.Value.ToLower());
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
                        break;
                }
            }

            return query.ToList();
        }
    }

    class SearchInput
    {
        public WeekDaysEnum WeekDay { get; set; }
        public string Value { get; set; }
    }
}
