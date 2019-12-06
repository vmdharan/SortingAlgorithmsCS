using SortingAlgorithmsCS.Classes;

namespace SortingAlgorithmsCS.Algorithms
{
    public class BubbleSort<T> : SortingAlgorithm<SortableItem<T>, T> where T : class
    {
        public override void Sort(ref SortableItem<T>[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (items[j + 1].Id < items[j].Id)
                    {
                        Swap(ref items[j + 1], ref items[j]);
                    }
                }
            }
        }
    }
}
