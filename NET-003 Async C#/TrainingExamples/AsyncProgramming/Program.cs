using System;
using System.Windows.Forms;
using AsyncProgramming.Demos;
using FluentAssertions;

namespace AsyncProgramming {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Start example...");


            new Demo5().Start();


/*
 *          example start point
 */
            
            // Demo5  syncAsync
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new SyncForm());

//                         Demo7  context
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Demo8SyncContext());

//            AwaitSample.RunSample();

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}