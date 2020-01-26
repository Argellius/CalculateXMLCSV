using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalculateCSVandXML.Array_
{


    class CSV_Array_Integer : Tools, ITester
    {
        
        private System.Int32[] ArrayInteger;
        private int NumberOfElements;

        public CSV_Array_Integer(int Number)
        {
            ArrayInteger = new System.Int32[NumberOfElements];
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool write)
        {
            if (write)
            {
                ArrayInteger = new Int32[this.NumberOfElements];

                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
            }
            else
                ArrayInteger = new Int32[this.NumberOfElements];
        }

        public void CSV_Write_Array_Integer_String()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StringWriter.Write(StringBuilder);
        }
        public void CSV_Write_Array_Integer_File()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StreamWriter.Write(StringBuilder);
            
        }

        public void CSV_Read_Array_Integer_String()
        {
            //read header
            StringReader.ReadLine();
            int i = 0;
            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                var line = StringReader.ReadLine();
                ArrayInteger[i] = Convert.ToInt32(line);
                i++;
            }

        }

        public void CSV_Read_Array_Integer_File()
        {
            //read header
            var lolo = StreamReader.ReadLine();
            int i = 0;

            //read records
            //try catch bool, int exc
            while (!StreamReader.EndOfStream)
            {
                var line = StreamReader.ReadLine();
                ArrayInteger[i] = Convert.ToInt32(line);
                i++;
            }
        }


        void ITester.SetupWriteStart(TestType Typ)
        {

            if (Typ == TestType.File)
                base.ToolsInicializeStream(this.GetType(), true);
            else
                base.ToolsInicializeString(true, this.StringData);

            Inicialize(true);
        }

        void ITester.SetupReadStart(TestType Typ)
        {
            if (Typ == TestType.File)
                base.ToolsInicializeStream(this.GetType(), false);
            else
                base.ToolsInicializeString(false, this.StringData);

            Inicialize(false);
        }

        void ITester.SetupWriteEnd(TestType Type)
        {
            ToolsSetupWriteEnd(Type);
        }

        void ITester.SetupReadEnd(TestType Type)
        {
            base.ToolsSetupReadEnd(Type);
        }

        void ITester.TestWriteString()
        {
            this.CSV_Write_Array_Integer_String();
        }

        void ITester.TestReadString()
        {
            this.CSV_Read_Array_Integer_String();
        }

        void ITester.TestWriteFile()
        {
            this.CSV_Write_Array_Integer_File();
        }

        void ITester.TestReadFile()
        {
            this.CSV_Read_Array_Integer_File();
        }
    }

}