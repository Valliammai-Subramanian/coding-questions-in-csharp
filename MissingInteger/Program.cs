using System;
using System.Collections.Generic;

class Solution 
{
    public static void Main(string[] args)
    {
        var myData = new List<int>[]
        {
            new List<int> { 1, 3, 6, 4, 1, 2 },
            new List<int> { 1, 2, 3 },
            new List<int> { -1, -3 },
        };

        foreach (List<int> A in myData)
        {
            Console.Write("InputArray"+"\t");
            A.ForEach(i => Console.Write("{0}\t", i));
            Console.Write("\n");
            Console.Write("Smallest positive integer that's not in the input array is" + " " + MissingInteger(A));
            Console.Write("\n");
        }
        
    }        
    public static int MissingInteger(List<int> A)
    {
        int[] B = A.ToArray();
        int[] C =  new int[100000];

        for (int i = 0; i < B.Length; i++)
        {
            if (B[i]>100000)
            {
                //ignore all values
            }
            else if (B[i]<1)
            {
                //ignore all values
            }
            else 
            {
               C[B[i]-1]=-1; 
            }
        }
            
        int maxvalue = 0;
            
        for(int j = 0; j<C.Length; j++)
        {
           if(C[j]==0) 
           {
                maxvalue=j+1;
                break;
           }
           else
           {
                continue;
           }
        }
        
        if (maxvalue == 0)
        {
            maxvalue = 100001;
        }
                
        return(maxvalue);        
    }
}