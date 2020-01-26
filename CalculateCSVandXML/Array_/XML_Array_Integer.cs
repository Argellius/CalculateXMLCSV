using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalculateCSVandXML.Array_
{
    class XML_Array_Integer: Tools, ITester
    {
        private System.Int32[] ArrayInteger;
        private int NumberOfElements;
        private XmlSerializer XmlSerializer;

        public XML_Array_Integer(int Pocet_Prvku)
        {
            ArrayInteger = new System.Int32[NumberOfElements];            
            this.NumberOfElements = Pocet_Prvku;                        
            XmlSerializer = new XmlSerializer(ArrayInteger.GetType());
        }
        
        private void Inicialize(bool Write)
        {
            if (Write)
            {
                ArrayInteger = new Int32[this.NumberOfElements];

                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
            }
            else
                ArrayInteger = new Int32[this.NumberOfElements];
        }

        public void XML_Serialize_Array_Integer_String()
        {
            XmlSerializer.Serialize(base.StringWriter, ArrayInteger);
        }
        public void XML_Serialize_Array_Integer_File()
        {
            XmlSerializer.Serialize(base.StreamWriter, ArrayInteger);
        }

        public void XML_DeSerialize_Array_Integer_String()
        {
            ArrayInteger = (System.Int32[])XmlSerializer.Deserialize(base.StringReader);
        }

        public void XML_DeSerialize_Array_Integer_File()
        {
            ArrayInteger = (System.Int32[])XmlSerializer.Deserialize(base.StreamReader);
        }

        void ITester.SetupWriteStart(TestType Type)
        {

            if (Type == TestType.File)
                base.ToolsInicializeStream(this.GetType(), true);
            else
                base.ToolsInicializeString(true, this.StringData);

            Inicialize(true);
        }

        void ITester.SetupReadStart(TestType Type)
        {
            if (Type == TestType.File)
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
            this.XML_Serialize_Array_Integer_String();
        }

        void ITester.TestReadString()
        {
            this.XML_DeSerialize_Array_Integer_String();
        }

        void ITester.TestWriteFile()
        {
            this.XML_Serialize_Array_Integer_File();
        }

        void ITester.TestReadFile()
        {
            this.XML_DeSerialize_Array_Integer_File();
        }

    }
}
