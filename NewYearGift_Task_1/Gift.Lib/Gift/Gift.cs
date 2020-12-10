using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Gift.lib.Gift
{
    public class Gift : IGift, IEnumerable<Sweetness>
    {
        private IList<Sweetness> sweetnesses;

        public Gift()
        {
            sweetnesses = new List<Sweetness>();
        }

        public IEnumerator<Sweetness> GetEnumerator()
        {
            return sweetnesses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Sweetness sweetness)
        {
            sweetnesses.Add(sweetness);
        }

        public void Remove(Sweetness sweetness)
        {
            sweetnesses.Remove(sweetness);
        }

        public void Remove(int index)
        {
            if (index < 0) throw new ArgumentException("Index is not correct");
            sweetnesses.RemoveAt(index);
        }

        public bool IsEmpty()
        {
            return sweetnesses.Count == 0;
        }

        public List<int> GetHeavistCandyIndex()
        {
            sweetnesses.Max(s => s.Weight);
            List<int> index = new List<int>();
            int i = 0;
            foreach (Sweetness item in sweetnesses)
            {
                if (item.Weight >= sweetnesses[0].Weight && item is Candy)
                {
                    index.Add(i);
                }
                i++;
            }

            return index;
        }

        public IEnumerable<Sweetness> FindBySugarRange(double leftRangeWeight, double rightRangeWeight)
        {
            return sweetnesses.Where(sweetnesses =>
                sweetnesses.SugarWeight > leftRangeWeight && sweetnesses.SugarWeight < rightRangeWeight);
        }

        public double TotalPrice
        {
            get { return sweetnesses.Sum(s => s.Price); }
        }

        public double TotalWeight
        {
            get { return sweetnesses.Sum(s => s.Weight); }
        }

        public IEnumerable<Sweetness> GetSorterSweetnessesBy<TProperty>(Func<Sweetness, TProperty> keySelectror)
        {
            return sweetnesses.OrderBy(keySelectror);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Gift: \n");
            foreach (var Item in sweetnesses)
            {
                stringBuilder.Append($"{Item}\n");
            }

            return stringBuilder.ToString();
        }
    }
}