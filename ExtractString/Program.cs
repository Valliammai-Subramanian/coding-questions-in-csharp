using System.Collections.Generic;
using System;

class ExtractString
{   
    
    Stack<int> braces = new Stack<int>();
    List<char> letters = new List<char>(); 
    int ind = 0;
    
    public void run(char c)
    {       
        if (c == '(')
        {                
            braces.Push(ind);
        }
        else if (c == ')')
        {
            int begin = braces.Pop();
            foreach (char letter in letters.GetRange(begin,ind-begin))
            {
                Console.Write(letter);
            }
            Console.Write("\n");
        }
        else 
        {
            letters.Add(c);
            ind = ind+1;
        }        

    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<string> strList = new List<string>();
        strList.Add("(abc(d(e)f))");
        strList.Add("abc(def(gh(i)j)kl)");
        strList.Add("((a)(b)cd(e)fg(h))ijk");       
            
        var extract = new ExtractString();        
        foreach (string str in strList)
        {
            Console.WriteLine("Input String = " + str);
            foreach (char c in str)
            {               
                extract.run(c);
            }
            Console.Write("\n");
        }
    }
}