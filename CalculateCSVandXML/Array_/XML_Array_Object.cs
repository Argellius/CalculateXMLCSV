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
    class XML_Array_Object : Tools, ITester
    {        
        private RecordOfEmployee[] ArrayObject;
        private int NumberOfElements;
        private XmlSerializer XMLSerializer;

        public XML_Array_Object(int Number)
        {
            ArrayObject = new RecordOfEmployee[this.NumberOfElements];
            this.NumberOfElements = Number;
            XMLSerializer = new XmlSerializer(ArrayObject.GetType());
        }
        private void Inicialize(bool Write)
        {
            if (Write)
            {
                ArrayObject = new RecordOfEmployee[this.NumberOfElements];

                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new RecordOfEmployee(true);
            }
            else
                ArrayObject = new RecordOfEmployee[this.NumberOfElements];

        }

        public void XML_Serialize_Array_Object_String()
        {
            XMLSerializer.Serialize(base.StringWriter, ArrayObject);
        }
        public void XML_Serialize_Array_Object_File()
        {
            XMLSerializer.Serialize(base.StreamWriter, ArrayObject);
        }

        public void XML_DeSerialize_Array_Object_String()
        {
            ArrayObject = (RecordOfEmployee[])XMLSerializer.Deserialize(base.StringReader);
        }

        public void XML_DeSerialize_Array_Object_File()
        {
            ArrayObject = (RecordOfEmployee[])XMLSerializer.Deserialize(base.StreamReader);
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
            this.XML_Serialize_Array_Object_String();
        }

        void ITester.TestReadString()
        {
            this.XML_DeSerialize_Array_Object_String();
        }

        void ITester.TestWriteFile()
        {
            this.XML_Serialize_Array_Object_File();
        }

        void ITester.TestReadFile()
        {
            this.XML_DeSerialize_Array_Object_File();
        }
    }

}



