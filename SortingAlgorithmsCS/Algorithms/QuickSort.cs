using SortingAlgorithmsCS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithmsCS.Algorithms
{
    public class QuickSort<T> : SortingAlgorithm<SortableItem<T>, T> where T : class
    {
        public override void Sort(ref SortableItem<T>[] items)
        {
            List<SortableItem<T>> result = new List<SortableItem<T>>();
            result = items.OfType<SortableItem<T>>().ToList();
            result = QSort(result);
            items = result.ToArray();
        }

        public List<SortableItem<T>> QSort(List<SortableItem<T>> items)
        {
            // If array is unit length, then return.
            if(items.Count <= 1)
            {
                return items;
            }

            else
            {
                // Generate three sub-arrays.
                List<SortableItem<T>> lt = new List<SortableItem<T>>();
                List<SortableItem<T>> eq = new List<SortableItem<T>>();
                List<SortableItem<T>> gt = new List<SortableItem<T>>();

                // Get the pivot
                SortableItem<T> p = items[0];

                // Iterate through the array elements
                for(int i=0; i<items.Count; i++)
                {
                    // Element is less than pivot
                    if(items[i].Id < p.Id)
                    {
                        lt.Add(items[i]);
                    }

                    // Element is equal to pivot
                    else if(items[i].Id == p.Id)
                    {
                        eq.Add(items[i]);
                    }

                    // Element is greater than pivot
                    else
                    {
                        gt.Add(items[i]);
                    }
                }

                // Sort the partitions
                lt = QSort(lt);
                eq = QSort(eq);
                gt = QSort(gt);

                // Return the merged array
                lt.AddRange(eq);
                lt.AddRange(gt);
                return lt;
            }
        }
    }
}
