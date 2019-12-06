using SortingAlgorithmsCS.Classes;

namespace SortingAlgorithmsCS.Algorithms
{
    public class InsertionSort<T> : SortingAlgorithm<SortableItem<T>, T> where T : class
    {
        public override void Sort(ref SortableItem<T>[] items)
        {
            for(int i=1; i<items.Length; i++)
            {
                var v = items[i];
                int j = i - 1;

                while((j >= 0) && (items[j].Id > v.Id))
                {
                    items[j + 1] = items[j];
                    j = j - 1;
                }
                items[j + 1] = v;
            }
        }
    }
}
