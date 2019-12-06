using SortingAlgorithmsCS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsCS.Classes
{
    public abstract class SortingAlgorithm<TSortableItem, TItemType>
        where TSortableItem : SortableItem<TItemType>
        where TItemType : class
    {
        public abstract void Sort(ref TSortableItem[] a);

        public virtual void Swap(ref TSortableItem a, ref TSortableItem b)
        {
            var c = a;
            a = b;
            b = c;
        }


    }
}
