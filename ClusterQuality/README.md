# Computing Cluster Quality
## Instructions

When building a computing cluster consisting of several machines, two parameters are most important: *speed* and *reliability*. The *quality* of a computing cluster is the sum of its machine's speeds multiplied by the minimum reliability of its machines.

Given information about several available machines, select machines to create a cluster of less than or equal to a particular size. Determine the maximum quality of cluster that can be created.

**Example 
*n* = 5   
*speed* = [4, 3, 15, 5, 6]   
*reliability* = [7, 6, 1, 2, 8]  
*maxMachines* = 3**

The maximum number of machines to use is *maxMachines* = 3 chosen from *n* = 5 available machines. A *machine[i]'s* speed and reliability are *speed[i]* and *reliability[i]*.
Select the first, second and fifth machines. The quality of this cluster is:
   *(speed[0] + speed[1] + speed[4]) \* min(reliability[0], reliability[1], reliability[4]) = (4 + 3 + 6) \* min(7, 6, 8) = 13 \* 6 = 78.

This is the highest quality that can be achieved, so the answer is 78.

**Function Description**
Complete the function *maxClusterQuality*
