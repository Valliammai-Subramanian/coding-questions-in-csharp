using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

class Result
{
    public static void incrStack(List<string> operations)
    {
        int TotalCount = operations.Count();
       
        LinkedList<int> numstack = new LinkedList<int>(); //LinkedList

        for (int i=0; i<TotalCount; i++)
        {
            string OperationItem = operations[i];           

            string[] Words = OperationItem.Split(' ');
                      
            if (Words[0] == "push"){
                numstack.AddLast(Convert.ToInt32(Words[1].Trim()));    
            }                
            else if (Words[0] == "pop"){
                numstack.RemoveLast();     
            }                
            else if (Words[0] == "inc"){
                LinkedListNode<int> node = numstack.First;
                for (int j=0; j<Convert.ToInt32(Words[1].Trim()); j++)
                {
                    node.Value += Convert.ToInt32(Words[2].Trim());
                    node= node.Next;             
                }
            }
            else{
                Console.WriteLine("WRONG COMMAND");
            }

            if(numstack.Count>0)
                Console.WriteLine(numstack.Last.Value);
            else
                Console.WriteLine("EMPTY");                        
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<string> operations = new List<string>() {"push 3","push 4","inc 2 1","pop","push 5","pop","pop"};

        Result.incrStack(operations);
    }
}