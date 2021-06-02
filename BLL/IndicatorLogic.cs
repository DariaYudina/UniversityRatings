using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class IndicatorLogic : IIndicatorLogic
    {
        private readonly IIndicatorDao indicatorDao;

        public IndicatorLogic(IIndicatorDao indicatorDao)
        {
            this.indicatorDao = indicatorDao;
        }

        public bool UpdateIndicator(Indicator indicator)
        {
            return indicatorDao.UpdateIndicator(indicator);
        }


        public List<Indicator> GetAllIndicators(int universityid)
        {
            return indicatorDao.GetAllIndicators(universityid);
        }
    }
}
