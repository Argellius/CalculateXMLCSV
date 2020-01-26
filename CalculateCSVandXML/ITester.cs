using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCSVandXML
{
    interface ITester
    {

        void SetupWriteStart(TestType Type); // Test preparation (initializing a collections, stream writer, string writer ... for create file or create stringwriter)

        void SetupReadStart(TestType Type);// Test preparation (initializing a collections, stream reader, string reader ... for read file or read stringwriter)

        void SetupWriteEnd(TestType Type); // delete collection, close streamwriter,string writer

        void SetupReadEnd(TestType Type); // delete collection, close streamreader,string reader

        void TestWriteString(); // Methods for testing, create some content into stringwriter 
        void TestReadString();  // Methods for testing, read some content into strigwriter
                
        void TestWriteFile(); // Methods for testing, create some content into file
        void TestReadFile(); //// Methods for testing, read some content into file


    }
}
