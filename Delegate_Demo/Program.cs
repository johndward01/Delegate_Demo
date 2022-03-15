using System;
using System.Collections.Generic;

namespace Delegate_Demo
{
    class Program
    {
        // Declaring the Delegates
        public delegate void Del1(string str);
        public delegate void Del2();        
        public delegate string Del3(string str1, string str2);        
        public delegate string[] Del4();   
        public delegate void Del5(List<int> list);
        public delegate void Del6(Dictionary<int, string> dict);

        static void Main(string[] args)
        {
            // Instantiating an object(delegate) of type Del1, Del2, Del3, etc...
            Del1 del1 = new Del1(ShowMessage);
            Del2 del2 = new Del2(DefaultMessage);
            Del3 del3 = new Del3(ConcatenateMessage);

            // Adding methods to the delegate object
            del2 += DetailedMessage;
            del2 += ErrorMessage;

            string message1 = "First sample message";
            string message2 = "Second sample message";

            // Invoking the delegates (like calling a method)
            del1(message1);
            del2();

            #region Predefined Delegates

            // Func(tion): Takes 0 -> 16 inputs and 1 output
            // public delegate TResult Func<in T, out TResult>(T arg);
            Func<string, string, string> myFunc = ConcatenateMessage;
            var concatenatedMessage = myFunc(message1, message2);
            Console.WriteLine(concatenatedMessage);

            // Action: Takes 0 -> 16 inputs and is void return type
            Action myAct1 = () => Console.WriteLine("0 args and void return type");
            myAct1.Invoke();

            Action<string> myAct2 = ShowMessage;
            myAct2(concatenatedMessage);

            // Predicate: Takes 0 -> 16 inputs and is bool return type
            Predicate<string> myPred = MessagePrinted;
            myPred(concatenatedMessage);

            #endregion
        }

        #region Methods 😎👍
        public static void ShowMessage(string msg)
        {
            Console.WriteLine($"The message is: {msg}");
            Console.WriteLine();
        }

        public static void DetailedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Detail 1: ...");
            Console.WriteLine("Detail 2: .........");
            Console.WriteLine("Detail 3: ....................");
            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine();
        }

        public static void DefaultMessage()
        {
            Console.WriteLine("This is the default message.");
            Console.WriteLine();
        }

        public static void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There was an error!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static string ConcatenateMessage(string firstMessage, string secondMessage)
        {
            return $"{firstMessage}.\n {secondMessage}.";
        }

        public static bool MessagePrinted(string status)
        {
            return bool.TryParse(status, out _);
        }
        #endregion
    }
}
