using System.Collections;
using System.Collections.Generic;
using Gift.lib.Models;

namespace Gift.lib.Gift
{
    public class Gift : IGift
    {
        private IList<Sweetness> sweetnesses = new List<Sweetness>(); //Enumerable
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
        public Sweetness this[int index]
        {
            get { return sweetnesses[index]; }
            set {sweetnesses[index] = value; }
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

        public double GetTotalWeight()
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
        
        

        public void SortBy() //OrderBy переделать 
        {
            List<Sweetness> sweetItem = sweetnesses;
            for (int i = 0; i < sweetItem.Count-1; i++)
            {
                for (int j = i + 1; j < sweetItem.Count; j++)
                {
                    if (sweetItem[i].Weight < sweetItem[j].Weight )
                    {
                        Sweetness temp = sweetItem[i];
                        sweetItem[i] = sweetItem[j];
                        sweetItem[j] = temp;
                    }
                }
            }
        }

        public double GetTotalPrice(double PricForKG) 
        {
            return sweetnesses.Sum(s=>s.Price);
        }

        public override string ToString()
        {
        }
    }
}