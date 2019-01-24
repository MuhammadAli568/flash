# Flash
## FLASH SORT

Flashsort is a distributing sorting algorithm.
This is an implementation of the algorithm described in the Flash Sort Partition algorithm. When an element in the list is not in its correct class, it becomes the cycle leader. The cycle leader is moved to a position inside its correct class, evicting the element already there. That element is then classified and moved, evicting the next element, and so on, until the position the cycle leader was in is filled. Then we find the next element in the list that is out of place, and start again.

Three stages of flashsort algorithm
* CLASSIFICATION
* PREMUTATION
* STRAIGHT LINE INSERTION


## TIME COMPLEXITY 

  FOR BULLET LIST
Fashsort sort If the number **m** of classes is proportional to the input set size **n**, the running time of the final insertion sort is **m.O(1)=O(m)=O(n)**.
In worst case all the elements are in a few or one class, the complexity of the algorithm as a whole is limited by the performance of the final-step sorting method. For insertion sort, this is **O(n^2)**.
## CLASSIFICATION
Flashsort sorting the data by making individual class for little additional memory required.
Firstly it separates minimum and maximum value from the data.
The classification ensures that every element in a class is greater than any element in a lower class.
## INSERTION
Insertion sort in applied to the classified set.As long as the unformly data is distributed.
The only extra memory requirements are the auxiliary vector **L** for storing class bounds and the constant number of other variables used.
## COMPARE TO OTHER SORTING ALGORITHM
Memory-wise, flashsort avoids the overhead needed to store classes in the very similar bucketsort. For **m=0.1n** with uniform random data, flashsort is faster than *heapsort* for all n and faster than quicksort for **n>80**. It becomes about as twice as fast as *quicksort* at **n=10000**.
## PREMUTATION
Due to its premutation that flashsort performs in its classification process, flashsort is  not stable. If stability is required, it is possible to use a second, temporary, array so elements can be classified sequentially. However, in this case, the algorithm will require **O(n)** space.

Then the words LEADER and PERMUTE are executed in turn until the sorting is completed. In order to facilitate the discussion, we call the position *A(i)* “empty" if *A(i)* has not yet been replaced by some other element. At the beginning of the permutation, all positions *A(i)* are  empty, since no element has been moved.  If during the permutation an element A(i) has been replaced by some other  element  we call its position "occupied."
Each cycle starts with a cycle leader. If during the permutation cycle as descibed by the word PERMUTE, the position of  an element A(i) becomes occupied by some element *FLASH*, the corresponding class pointer *L(KEY(FLASH))* will be decremented and then will point to the next empty position of the class *KEY(FLASH)*. If the last empty position of that class which provides the cycle leader, becomes occupied, the current permutation cycle is complete.The completion of a cycle is flagged by the fact that the pointer *L(KEY(A(j)))* of the class providing the cycle leader points to one position below the lowest position of this class. Thus, if *A(j)*  is a cycle leader, the completion of the corresponding cycle is given by the condition 

## RESULT
I found that flash firstly make classes for sorting.

I found that larger classes lessen the total moves to partition the data.

It is simply used premutation concept easily then it insert the class uniformly. It is benefical for sorting program
 due to less complexity
 ## Group members 
17B-093-SE

17B-094-SE

17B-128-SE.
