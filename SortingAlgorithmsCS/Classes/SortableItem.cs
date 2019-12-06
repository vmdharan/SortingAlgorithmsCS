using SortingAlgorithmsCS.Interfaces;

namespace SortingAlgorithmsCS.Classes
{
    class SortableItem<T> : ISortable 
    {
        public int Id { get; set; }

        public T Val { get; set; }
    }
}
