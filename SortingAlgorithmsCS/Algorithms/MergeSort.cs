using SortingAlgorithmsCS.Classes;
using System;

namespace SortingAlgorithmsCS.Algorithms
{
    public class MergeSort<T> : SortingAlgorithm<SortableItem<T>, T> where T : class
    {
        public override void Sort(ref SortableItem<T>[] items)
        {
            int arrLength = items.Length;

            if (items.Length > 1)
            {
                var B = CopyData(items, 0, (int)Math.Floor(arrLength / 2.0d));
                var C = CopyData(items, (int)Math.Floor(arrLength /2.0d), arrLength);

                Sort(ref B);
                Sort(ref C);
                Merge(ref B, ref C, ref items);
            }
        }

        private SortableItem<T>[] CopyData(SortableItem<T>[] src, int start, int end)
        {
            SortableItem<T>[] result = new SortableItem<T>[end-start];
            int j = 0;
            for (int i = start; i < end; i++)
            {
                result[j] = src[i];
                j++;
            }

            return result;
        }

        private void CopyIntoArray(ref SortableItem<T>[] src, int srcIndex, int destIndex, ref SortableItem<T>[] dest)
        {
            int j = srcIndex;
            for(int i = destIndex; destIndex < dest.Length; i++)
            {
                if(j >= src.Length)
                {
                    break;
                }
                dest[i] = src[j];
                j++;
            }
        }

        private void Merge(ref SortableItem<T>[] B, ref SortableItem<T>[] C, ref SortableItem<T>[] A)
        {
            int p = B.Length;
            int q = C.Length;

            int i = 0;
            int j = 0;
            int k = 0;

            while ((i < p) && (j < q))
            {
                if (B[i].Id <= C[j].Id)
                {
                    A[k] = B[i];
                    i = i + 1;
                }
                else
                {
                    A[k] = C[j];
                    j = j + 1;
                }

                k = k + 1;
            }

            if (i == p)
            {
                CopyIntoArray(ref C, j, k, ref A);
            }
            else
            {
                CopyIntoArray(ref B, i, k, ref A);
            }
        }
    }
}