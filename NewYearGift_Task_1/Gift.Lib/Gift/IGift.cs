using System.Collections.Generic;

namespace Gift
{
    public interface IGift : IEnumerable<Sweetness>
    {
        void Add(Sweetness sweetness);
        void Remove(Sweetness sweetness);
        bool IsEmpty();
        double GetTotalWeight();

        int IndexHeavistCandy();

        void SortBy(); //OrderBy переделать 

        double GetTotalPrice(double PricForKG);

    }
}