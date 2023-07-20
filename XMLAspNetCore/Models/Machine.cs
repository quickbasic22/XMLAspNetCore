using System.Xml.Serialization;

namespace XMLAspNetCore.Models
{
    public class Machine
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Machines
        {

            private MachinesMachine[] machineField;

            private string currentField;

            private string managerField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Machine")]
            public MachinesMachine[] Machine
            {
                get
                {
                    return this.machineField;
                }
                set
                {
                    this.machineField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "current")]
            public string Current
            {
                get
                {
                    return this.currentField;
                }
                set
                {
                    this.currentField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "manager")]
            public string Manager
            {
                get
                {
                    return this.managerField;
                }
                set
                {
                    this.managerField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MachinesMachine
        {

            private string nameField;

            private string ipField;

            private string gUIDField;

            private MachinesMachineInformation informationField;

            private MachinesMachineCodeSegment codeSegmentField;

            private uint testField;

            /// <remarks/>
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string IP
            {
                get
                {
                    return this.ipField;
                }
                set
                {
                    this.ipField = value;
                }
            }

            /// <remarks/>
            public string GUID
            {
                get
                {
                    return this.gUIDField;
                }
                set
                {
                    this.gUIDField = value;
                }
            }

            /// <remarks/>
            public MachinesMachineInformation Information
            {
                get
                {
                    return this.informationField;
                }
                set
                {
                    this.informationField = value;
                }
            }

            /// <remarks/>
            public MachinesMachineCodeSegment CodeSegment
            {
                get
                {
                    return this.codeSegmentField;
                }
                set
                {
                    this.codeSegmentField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "test")]
            public uint Test
            {
                get
                {
                    return this.testField;
                }
                set
                {
                    this.testField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MachinesMachineInformation
        {

            private string info1Field;

            private string info2Field;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Info1
            {
                get
                {
                    return this.info1Field;
                }
                set
                {
                    this.info1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute("info2")]
            public string Info2
            {
                get
                {
                    return this.info2Field;
                }
                set
                {
                    this.info2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MachinesMachineCodeSegment
        {

            private string info3Field;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Info3
            {
                get
                {
                    return this.info3Field;
                }
                set
                {
                    this.info3Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }


    }
}
