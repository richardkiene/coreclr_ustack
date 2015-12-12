using System;

namespace coreclr_ustack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (;;)
                ; //System.Console.WriteLine(System.Environment.StackTrace);
            return;
        }
    }
}
