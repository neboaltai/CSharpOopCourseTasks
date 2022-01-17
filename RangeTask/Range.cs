using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number - From >= 0 && To - number >= 0;
        }

        public Range GetIntersection(Range range)
        {
            if (range.From >= To || range.To <= From)
            {
                return null;
            }

            double from = range.From <= From ? From : range.From;
            double to = range.To <= To ? range.To : To;

            return new Range(from, to);
        }

        public Range[] GetUnion(Range range)
        {
            if (range.From > To || range.To < From)
            {
                return new Range[] { this, range };
            }

            double from = range.From <= From ? range.From : From;
            double to = range.To <= To ? To : range.To;

            return new Range[] { new Range(from, to) };
        }

        public Range[] GetDifference(Range range)
        {
            Range differenceRange1 = null;

            Range differenceRange2 = null;

            if (range.From < To && range.To > From)
            {
                if (From < range.From)
                {
                    differenceRange1 = new Range(From, range.From);
                }

                if (To > range.To)
                {
                    differenceRange2 = new Range(range.To, To);
                }
            }

            return new Range[] { differenceRange1, differenceRange2 };
        }
    }
}