using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gift
{
    public class Gift : IGift
    {
        private IList<Sweetness> sweetnesses ; //Enumerable
        public Gift()
        {
            sweetnesses = new List<Sweetness>();
        }
        public IEnumerator<Sweetness> GetEnumerator()
        {
            throw new System.NotImplementedException();
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
            if(index>0) sweetnesses.RemoveAt(index);
        }
        public bool IsEmpty()
        {
            return sweetnesses.Count == 0;
        }

        public double Weight()
        {
            return sweetnesses.Sum(s => s.Weight);
        }

        public int IndexHeavistCandy()
        {
            double control_weight=0;
            int count = -1;
            for (int i=0;i<sweetnesses.Count;i++)
            {
                if (sweetnesses[i] is Candy)
                {
                    if (control_weight < sweetnesses[i].Weight)
                    {
                        count = i;
                    }
                }
            }
            return count;
        }

        public IList<Sweetness> FindBySugarRange(double min, double max)
        {
            return sweetnesses.Where(sweetnesses => sweetnesses.Sugar > min && sweetnesses.Sugar < max).ToList();
        }

        public void SortBy() //OrderBy переделать 
        {
        }

        public double Price() 
        {
            return sweetnesses.Sum(s=>s.Price);
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