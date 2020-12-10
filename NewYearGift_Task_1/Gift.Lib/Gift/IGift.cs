using System;
using System.Collections.Generic;

namespace Gift.lib.Gift
{
    public interface IGift 
    {
        void Add(Sweetness sweetness);
        void Remove(Sweetness sweetness);
        void Remove(int index);
        bool IsEmpty();
        int[] GetHeavistCandyIndex();
        IEnumerable<Sweetness> FindBySugarRange(double leftRangeWeight, double rightRangeWeight);
        double TotalPrice { get; }
        double TotalWeight { get; }
        IEnumerable<Sweetness> GetSorterSweetnessesBy<TProperty>(Func<Sweetness, TProperty> keySelectror);
    }
}