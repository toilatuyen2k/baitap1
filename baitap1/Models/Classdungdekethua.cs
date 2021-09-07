using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitap1.Models
{
    public class GiaiPhuongTrinh
    {
        public double Timx(double a, double b)
        {
            double gtx = 0;
            gtx = -b / a;
            return gtx;
        }
    }
}