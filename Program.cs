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
            Console.WriteLine("***UNSORTED ARRAY*** ");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Element {0} is : {1}",i,MainArray[i]);
            }
                //performing flash sort

            Program.FlashSort(MainArray);
        }
        public static void FlashSort(int[] Array)
        {
            
            int i = 0, j = 0, k = 0;    //loop variables
            int MinValue = Array[0];
            int MaxIndex = 0;
            int m = 1 + (int)(0.1 * Array.Length);  // m is consider as the length of class
            Console.WriteLine("m is\t "+m);

            // finding minimum and maximum value of an MainArray
            for (i = 1; i < Array.Length; i++)
            {
                if (Array[i] < MinValue) MinValue = Array[i];
                if (Array[i] > Array[MaxIndex]) MaxIndex = i;
            }
            
            // gaurd condition
            if (MinValue == Array[MaxIndex])
            {
                Console.WriteLine("All elements are same");
                return;
            }

            int[] loc = new int[m + 1]; //to locate the class varible 
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
            while (nmove < Array.Length - 1)
            {
                while (j > (loc[k] - 1))
                {
                    j++;
                    k = (int)(Constant * (Array[j] - MinValue));
                }
                Flash = Array[j];
                while (!(j == loc[k]))
                {
                    k = (int)(Constant * (Flash - MinValue));
                    temp = Array[loc[k] - 1];
                    Array[loc[k] - 1] = Flash;
                    Flash = temp;
                    loc[k]--;
                    nmove++;
                }

            }
            
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
            Console.WriteLine("SORTED ARRAY");
            printArray(a);
        }

        // PRINTING FUNCTION
        private static void printArray(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("Elements {0} is : {1} ",i,Array[i]);
            }


            Console.WriteLine();
        }


    }

}
