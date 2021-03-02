using System;
using System.Collections.Generic;

class Program 
{
    public static void Main()
    {
        List<string> strList = new List<string>();

        strList.Add("acb");
        strList.Add("hot");
        strList.Add("codility");
        strList.Add("aaaa");

        foreach(string S in strList)
        {
            Console.WriteLine("Input String is" + S);
            string result = solution(S);
            Console.WriteLine("Output String =" + "\t" + result);
            Console.Write("\n");
        }          
    }
    public static string solution(string S) 
    {                
        int len = S.Length;
        for(int i=0; i<len-1; i++)
        {
            if(S[i]>S[i+1])
            {
                string N = S.Substring(0,i)+S.Substring(i+1,len-i-1);
                return N;                
            }
        }
        string R = S.Substring(0,len-1);
        return R;
    }
}