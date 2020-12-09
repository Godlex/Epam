using System;
using System.Collections.Generic;

namespace Gift.lib.Gift
{
    public interface IGift 
    {
        void Add(Sweetness sweetness);
        void Remove(Sweetness sweetness);
        bool IsEmpty();
        int[] GetHeavistCandyIndex();
        IEnumerable<Sweetness> GetSorterSweetnessesBy<TProperty>(Func<Sweetness, TProperty> keySelectror);
        double TotalPrice { get; }
        double TotalWeight { get; }
    }
}