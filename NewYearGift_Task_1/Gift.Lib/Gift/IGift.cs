using System.Collections.Generic;
using Gift.lib.Models;

namespace Gift.lib.Gift
{
    public interface IGift : IEnumerable<Sweetness>
    {
        Sweetness this[int index];

        void Add(Sweetness sweetness);
        void Remove(Sweetness sweetness);

        void Remove(int index);

        bool IsEmpty();
    

        double GetTotalWeight();

        int IndexHeavistCandy();

        void SortBy(); //OrderBy переделать 

        double GetTotalPrice(double PricForKG);

    }
}