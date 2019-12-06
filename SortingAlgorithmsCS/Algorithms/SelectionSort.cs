using SortingAlgorithmsCS.Classes;

namespace SortingAlgorithmsCS.Algorithms
{
    public class SelectionSort<T> : SortingAlgorithm<SortableItem<T>, T> where T : class
    {
        public override void Sort(ref SortableItem<T>[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[j].Id < items[min].Id)
                    {
                        min = j;
                    }
                }

                Swap(ref items[min], ref items[i]);
            }
        }
    }
}
