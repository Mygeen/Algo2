using System;

namespace MergeSort
{

    public class Sorter
    {

        public int[] MergeSort(int[] input)
        {
            MergeSort(input, 0, input.Length - 1);
            return input;
        }

        public int[] Merge(int[] input, int left, int middle, int right)
        {
            if (left >= right || middle >= right)
            {
                var nameOfParameter = left >= right ? nameof(left) : nameof(middle);
                throw new ArgumentException("Parameter must be small than Right", nameOfParameter);
            }

            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }

            return input;
        }

        public int[] MergeSort(int[] input, int left, int right)
        {
            if (left < right && left >= 0)
            {
                int middle = (left + right) / 2;

                var result = MergeSort(input, left, middle);
                result = MergeSort(result, middle + 1, right);

                return Merge(result, left, middle, right);
            }
            else if (left < 0)
            {
                throw new ArgumentException("Parameter must not be smaller than zero", nameof(left));
            }

            return input;
        }
    }
}
