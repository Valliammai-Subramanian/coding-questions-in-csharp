
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;
class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 3, 13, 4, 11, 9 };

        int result = adding(numbers);

        Console.WriteLine(result);    
            
    }

    public static int adding(List<int> n)
    {
        int sum1 = 0;
        int sum2 = 0;

        int cnt = n.Count;
        if(cnt<=3)
        {
            return n.Sum();
        }

        int marker = cnt/2;

        Thread t1 = new Thread(() => { sum1 = adding(n.GetRange(0,marker)); } );
        Thread t2 = new Thread(() => { sum2 = adding(n.GetRange(marker,cnt-marker)); } );
                
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
               
        return sum1+sum2;            
    }  
}