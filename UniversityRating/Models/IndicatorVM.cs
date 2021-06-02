using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityRating.Models
{
    public class IndicatorVM
    {
        public int IndicatorId { get; set; }
        public int UniversityId { get; set; }
        public string IndicatorName { get; set; }
        public int Value { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UniversityName { get; set; }
    }
}
