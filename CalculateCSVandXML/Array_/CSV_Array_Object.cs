using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCSVandXML.Array_
{
    class CSV_Array_Object : Tools, ITester
    {
        private RecordOfEmployee[] ArrayObject;
        private RecordOfEmployee EmployeeObj;
        private int NumberOfElements;


        public CSV_Array_Object(int Number)
        {
            ArrayObject = new RecordOfEmployee[NumberOfElements];
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool Write)
        {
            if (Write)
            {
                this.ArrayObject = new RecordOfEmployee[NumberOfElements];
                for (int i = 0; i < NumberOfElements; i++)
                    this.ArrayObject[i] = base._Zamestnanci_With_Data;
            }
            else
                this.ArrayObject = new RecordOfEmployee[NumberOfElements];
        }


        public void CSV_Write_Array_Object_String()
        {
            base.StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");

            for (int o = 0; o < this.NumberOfElements; o++)
            {
                base.StringBuilder.Append(ArrayObject[o].ID);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Money);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Age);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Children);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FirstName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FamilyName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].PIN);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Residence);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Ready);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].License);
                base.StringBuilder.Append(",");
                base.StringBuilder.AppendLine(ArrayObject[o].Indisposed.ToString());
            }

            base.StringWriter.Write(base.StringBuilder);

        }

        public void CSV_Write_Array_Object_File()
        {
            base.StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");

            for (int o = 0; o < this.NumberOfElements; o++)
            {
                base.StringBuilder.Append(ArrayObject[o].ID);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Money);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Age);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Children);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FirstName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FamilyName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].PIN);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Residence);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Ready);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].License);
                base.StringBuilder.Append(",");
                base.StringBuilder.AppendLine(ArrayObject[o].Indisposed.ToString());
            }

            StreamWriter.Write(base.StringBuilder);
        }

        public void CSV_Read_Array_Object_String()
        {
            //read header
            base.StringReader.ReadLine();
            int i = 0;

            //read records
            //try catch bool, int exc
            while (base.StringReader.Peek() > 0)
            {
                EmployeeObj = new RecordOfEmployee(false);
                var line = base.StringReader.ReadLine();
                var values = line.Split(',');
                EmployeeObj.ID = Convert.ToInt64(values[0]);
                EmployeeObj.Money = Convert.ToInt64(values[1]);
                EmployeeObj.Age = Convert.ToInt64(values[2]);
                EmployeeObj.Children = Convert.ToInt64(values[3]);
                EmployeeObj.FirstName = values[4];
                EmployeeObj.FamilyName = values[5];
                EmployeeObj.PIN = values[6];
                EmployeeObj.Residence = values[7];
                EmployeeObj.Ready = bool.Parse(values[8]);
                EmployeeObj.License = bool.Parse(values[9]);
                EmployeeObj.Indisposed = bool.Parse(values[10]);
                ArrayObject[i] = EmployeeObj;
                i++;
            }
        }

        public void CSV_Read_Array_Object_File()
        {
            //read header
            StreamReader.ReadLine();
            int i = 0;
            //read records
            //try catch bool, int exc
            while (base.StreamReader.Peek() > 0)
            {
                EmployeeObj = new RecordOfEmployee(false);
                var line = base.StreamReader.ReadLine();
                var values = line.Split(',');
                EmployeeObj.ID = Convert.ToInt64(values[0]);
                EmployeeObj.Money = Convert.ToInt64(values[1]);
                EmployeeObj.Age = Convert.ToInt64(values[2]);
                EmployeeObj.Children = Convert.ToInt64(values[3]);
                EmployeeObj.FirstName = values[4];
                EmployeeObj.FamilyName = values[5];
                EmployeeObj.PIN = values[6];
                EmployeeObj.Residence = values[7];
                EmployeeObj.Ready = bool.Parse(values[8]);
                EmployeeObj.License = bool.Parse(values[9]);
                EmployeeObj.Indisposed = bool.Parse(values[10]);
                ArrayObject[i] = EmployeeObj;
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
            this.CSV_Write_Array_Object_String();
        }

        void ITester.TestReadString()
        {
            this.CSV_Read_Array_Object_String();
        }

        void ITester.TestWriteFile()
        {
            this.CSV_Write_Array_Object_File();
        }

        void ITester.TestReadFile()
        {
            this.CSV_Read_Array_Object_File();
        }
    }
}
