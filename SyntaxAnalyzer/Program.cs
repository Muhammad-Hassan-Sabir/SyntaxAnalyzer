using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SyntaxAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> ts = new List<string[]>();



            var tokens = File.ReadAllLines("C:\\Users\\ADMIN\\Desktop\\tokenset.txt");


            
         

            foreach (var item in tokens)
            {

                ts.Add(item.Split(' '));
            }

            string[] s = { "$", "_", "_" };
            ts.Add(s);
            //foreach (var item in ts)
            //{
            //    Console.WriteLine(item[1]);
            //}



            SyntaxChecking syntaxChecking = new SyntaxChecking();

            Console.WriteLine( syntaxChecking.SyntexAnalyzer(ts));
           



































            


        }
    }
}
