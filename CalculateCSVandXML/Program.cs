using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalculateCSVandXML
{

    class Program
    {

        static TimeSpan CalculateTime(Action method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            method();
            sw.Stop();
            return sw.Elapsed;

        }

        private static void PrintDict(string name, Dictionary<string, TimeSpan> dict)
        {
            Console.WriteLine($"\n\n================ {name} ==============\n\n");
            foreach (var entry in dict)
            {
                Console.WriteLine("Method: {0,-25}  {1}: Total time: {2,-15} || ms: {3,-15}", entry.Key, name, entry.Value, entry.Value.TotalMilliseconds);
            }
        }

        static void Main(string[] args)
        {
            TimeSpan Time; // Calculate time
            int NumberOfElements = 20;
            int NumberOfTests = 1;            
            Dictionary<string, TimeSpan> TimeTesting = new Dictionary<string, TimeSpan>(); // Dictionary for save results of calculate time
            List<ITester> LTesters = new List<ITester>();

            //********************


            //Adding a test class
            LTesters.AddRange(
                new ITester[]{
                    new Array_.XML_Array_Integer(NumberOfElements),
                    new Array_.CSV_Array_Integer(NumberOfElements),
                    new Array_.XML_Array_Object(NumberOfElements),
                    new Array_.CSV_Array_Object(NumberOfElements),                 

            });


            for (int i = 0; i < NumberOfTests; i++)

                LTesters.ForEach(t => //Testing....
                {

                    t.SetupWriteStart(TestType.String);
                    Time = CalculateTime(t.TestWriteString);
                    t.SetupWriteEnd(TestType.String);

                    TimeTesting.Add(i + ". " + t.GetType().Name + " Write String", Time);



                    t.SetupReadStart(TestType.String);
                    Time = CalculateTime(t.TestReadString);
                    t.SetupReadEnd(TestType.String);

                    TimeTesting.Add(i + ". " + t.GetType().Name + " Read String", Time);


                    t.SetupWriteStart(TestType.File);
                    Time = CalculateTime(t.TestWriteFile);
                    t.SetupWriteEnd(TestType.File);

                    TimeTesting.Add(i + ". " + t.GetType().Name + " Write Disk", Time);



                    t.SetupReadStart(TestType.File);
                    Time = CalculateTime(t.TestReadFile);
                    t.SetupReadEnd(TestType.File);

                    TimeTesting.Add(i + ". " + t.GetType().Name + " Read Disk", Time);
                });


            PrintDict(nameof(TimeTesting), TimeTesting);

        }
    }
}