using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderCodeingExercise
{
    class Program
    {
        public class CodeElement
        {
            public string PropertyType { get; set; }
            public string PropertyValue { get; set; }
            public List<CodeElement> Elements = new List<CodeElement>();
            private const int indentsize = 2;

            public CodeElement() { }

            public CodeElement(string name, string value)
            {
                this.PropertyType = name;
                this.PropertyValue = value;
            }

            private string ToStringImpl(int indent)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"public class {PropertyType}");
                sb.AppendLine("{");
                AddStringProps(sb);
                sb.AppendLine("}");
                return sb.ToString();

            }

            private StringBuilder AddStringProps(StringBuilder sb)
            {
                foreach (var e in Elements)
                {
                    sb.AppendLine($"  public {e.PropertyValue} {e.PropertyType};");
                }
                return sb;
            }

            public override string ToString()
            {
                return ToStringImpl(0);
            }
        }

        public class CodeBuilder
        {
            private readonly string ClassName;
            CodeElement root = new CodeElement();

            public CodeBuilder(string classname)
            {
                this.ClassName = classname;
                root.PropertyType = ClassName;
            }

            public CodeBuilder AddField(string childtype, string childvalue)
            {
                var e = new CodeElement(childtype, childvalue);
                root.Elements.Add(e);
                return this;
            }

            public override string ToString()
            {
                return root.ToString();
            }
        }


        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb.ToString());
        }
    }
}
