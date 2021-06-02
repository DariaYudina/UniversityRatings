using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IIndicatorDao
    {
        List<Indicator> GetAllIndicators(int universitiid);
        bool UpdateIndicator(Indicator indicator);
    }
}
