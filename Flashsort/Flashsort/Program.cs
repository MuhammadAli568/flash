using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlashSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // making object for generating random variable

            Random r = new Random();
            int[] MainArray;
            Console.WriteLine("Enter the length of an array : ");
            int len = int.Parse(Console.ReadLine());
            MainArray = new int[len];


            for (int i = 0; i < len; i++)
            {
                MainArray[i] = r.Next(0, 100);
            }
            Console.WriteLine("\n   **UNSORTED ARRAY**\n ");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Element {0} is : {1}", i+1, MainArray[i]);
            }
            //performing flash sort

            Program.FlashSort(MainArray,len);
        }
        public static void FlashSort(int[] Array,int Len)
        {

            int i = 0, j = 0, k = 0;    //loop variables
            int MinValue = Array[0];
            int MaxIndex = 0;
            int min = 0;
            int max = 0;
            int m = 1 + (int)(0.2 * Array.Length);  // m is consider as the length of class

            Console.WriteLine("\nLength of the class is  : " + m);

            // finding maxindex of an MainArray
            for (i = 1; i < Array.Length; i++)
            {
                if (Array[i] < MinValue) MinValue = Array[i];
                if (Array[i] > Array[MaxIndex]) MaxIndex = i;
            }
            

            // gaurd condition
            // and also finding the minimum and maximum value
            if (Len == 0)
            {
                return;
            }

            int maxIndex = 0;
            min = max = Array[0];

            maxIndex = 0;
            for (j = 0; j < Len - 1; j += 2)
            {

                int small;
                int big;
                int bigIndex;
                if (Array[j] < Array[j + 1])
                {
                    small = Array[j];
                    big = Array[j + 1];
                    bigIndex = j + 1;
                }
                else
                {
                    big = Array[j];
                    bigIndex = j;
                    small = Array[j + 1];
                }

                if (big > max)
                {
                    max = big;
                    maxIndex = bigIndex;
                }

                if (small < min)
                {
                    min = small;
                }
            }
            if (Array[Len - 1] < min)
            {
                min = Array[Len - 1];
            }
            else if (Array[Len - 1] > max)
            {
                max = Array[Len - 1];
                maxIndex = Len - 1;
            }


            if (max == min)
            {
                Console.WriteLine("\nAll elements are same");
                return;
            }

            Console.WriteLine("\nMinimum value is  = " + min);
            Console.WriteLine("Maximum value is  = " + max);

            int[] loc = new int[m + 1];                        //to locate the class varible 
            double Constant = ((double)m - 1) / (Array[MaxIndex] - MinValue);   // constant is consider for calculating the class
            
            // CLASSIFICATION
            for (i = 0; i < Array.Length; i++)
            {
                k = (int)(Constant * (Array[i] - MinValue));
                loc[k]++;
            }
            for (k = 1; k < m; k++)
            {
                loc[k] += loc[k - 1];
            }
            // PERMUTATION
            int temp = Array[MaxIndex];
            Array[MaxIndex] = Array[0];
            Array[0] = temp;
            int nmove = 0;
            int Flash;
            j = 0;
            k = m - 1;
            while (nmove < Array.Length - 1)   // loop for classfied the array according to values
            {
                while (j > (loc[k] - 1))
                {
                    j++;
                    k = (int)(Constant * (Array[j] - MinValue));
                }
                Flash = Array[j];
                while (!(j == loc[k]))      // puttong the values in the respective class
                {
                    k = (int)(Constant * (Flash - MinValue));
                    temp = Array[loc[k] - 1];
                    Array[loc[k] - 1] = Flash;
                    Flash = temp;
                    loc[k]--;
                    nmove++;
                }

            }
            // Define the number of classes
            int NumClass = 0;
            NumClass = Len / m;
            Console.WriteLine("Number of classes are  : " + NumClass);
            
            // STRAIGHT LINE INSERTION
            insertionSort(Array);
        }
        private static void insertionSort(int[] a)
        {
            int i, j, min;


            for (i = a.Length - 3; i >= 0; i--)
            {
                if (a[i + 1] < a[i])
                {
                    min = a[i];
                    j = i;


                    while (a[j + 1] < min)
                    {
                        a[j] = a[j + 1];
                        j++;
                    }


                    a[j] = min;
                }
            }

            //Printing sorted array
            Console.WriteLine("\n    **SORTED ARRAY**\n");
            printArray(a);
        }

        // PRINTING FUNCTION
        private static void printArray(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("Elements {0} is : {1} ", i+1, Array[i]);
            }


            Console.WriteLine();
        }


    }

}
