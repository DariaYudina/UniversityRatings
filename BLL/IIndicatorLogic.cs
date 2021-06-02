using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IIndicatorLogic
    {
        List<Indicator> GetAllIndicators(int universityid);
        bool UpdateIndicator(Indicator indicator);
    }
}
