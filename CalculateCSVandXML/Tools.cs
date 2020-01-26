using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCSVandXML
{
    public enum TestType { String, File };

    abstract class Tools
    {
        protected string StringData;

        protected string path = @"..\..\..\FilesXMLCSV\";
        protected RecordOfEmployee _Zamestnanci_With_Data;

        //Tools for string's test
        protected StringBuilder StringBuilder;

        protected StringWriter StringWriter;
        protected StringReader StringReader;

        //Tools for file's test
        protected StreamWriter StreamWriter;
        protected StreamReader StreamReader;

        public Tools()
        {
            StringBuilder = new StringBuilder();
            _Zamestnanci_With_Data = new RecordOfEmployee(true);
        }


        protected void ToolsInicializeStream(Type obj, bool Write)
        {
            StringBuilder.Clear();
            string ClassName = obj.Name;
            if (Write)
            {
                if (ClassName.Substring(0, 3).ToLower() == "csv")
                    this.StreamWriter = new StreamWriter(this.path + ClassName + ".csv");
                else
                    this.StreamWriter = new StreamWriter(this.path + ClassName + ".xml");
            }
            else
            {
                if (ClassName.Substring(0, 3).ToLower() == "csv")
                    this.StreamReader = new StreamReader(this.path + ClassName + ".csv");
                else
                    this.StreamReader = new StreamReader(this.path + ClassName + ".xml");

            }
        }

        protected void ToolsInicializeString(bool Write, string data)
        {
            
            if (Write)
                this.StringWriter = new StringWriter();
            else
                this.StringReader = new StringReader(data);
        }

        protected void ToolsSetupReadEnd(TestType Type)
        {
            if (Type == TestType.File)
                this.StreamReader.Close();
            else
                this.StringData = string.Empty;
        }

        protected void ToolsSetupWriteEnd(TestType Type)
        {
            if (Type == TestType.File)
            {
                StreamWriter.Flush();
                StreamWriter.Close();
            }
            else
            {
                this.StringData = StringWriter.ToString();
                StringBuilder.Clear();
                StringWriter.Close();
            }
        }

    }

}

