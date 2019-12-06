using SortingAlgorithmsCS.Interfaces;

namespace SortingAlgorithmsCS.Classes
{
    public class SortableItem<T> : ISortable 
    {
        public int Id { get; set; }

        public T Val { get; set; }
    }
}
