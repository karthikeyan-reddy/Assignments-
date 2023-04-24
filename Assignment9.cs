using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{ 
    class Assignment9
    {
        public static string reverseByWords(string sentence)
        {
            string[] splitSentenceArray = sentence.Split(' ');
            string ReverseSentense = "";
            for (int i = splitSentenceArray.Length-1; i >= 0; i--)
            {
                if (i==0)
                {
                    ReverseSentense = ReverseSentense + splitSentenceArray[i];
                }
                else
                {
                    ReverseSentense = ReverseSentense + splitSentenceArray[i] + " ";
                }
            }
            
            return ReverseSentense;
        }
        static void Main(string[] args)
        {
            START:
            string EnteredSentence = UIConsole.GetString("Enter the Senetence");
            string result = reverseByWords(EnteredSentence);
            UIConsole.ReadKey(result + "\nPress any key to clear Screen");
            goto START;
            
        }
    }
}
