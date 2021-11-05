using System;

namespace Delegate_Demo
{
    class Program
    {
        // Delegates
        public delegate void Del1(string str);
        public delegate void Del2();        

        static void Main(string[] args)
        {
            string message1 = "First sample message";
            string message2 = "Second sample message";

            Del1 del1 = new Del1(ShowMessage);
            Del2 del2 = new Del2(DefaultMessage);
            del2 += ErrorMessage;

            //del1(message1);
            //del2();


            // Func: Takes 0 -> 16 inputs and 1 output
            // public delegate TResult Func<in T, out TResult>(T arg);
            Func<string, string, string> myFunc = ConcatenateMessage;
            var concatenatedMessage = myFunc(message1, message2);

            // Action: Takes 0 -> 16 inputs and is void return type
            Action myAct1 = () => Console.WriteLine("0 args and void return type"); 
            myAct1.Invoke();

            Action<string> myAct2 = ShowMessage;
            myAct2(concatenatedMessage);

            // Predicate: Takes 0 -> 16 inputs and is bool return type
            Predicate<string> myPred = MessagePrinted;
            myPred(concatenatedMessage);
        }

        #region Methods
        public static void ShowMessage(string msg)
        {
            Console.WriteLine($"The message is: {msg}");
            Console.WriteLine();
        }

        public static void DefaultMessage()
        {

            Console.WriteLine("This is the default message.");
            Console.WriteLine();
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("There was an error!");
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
