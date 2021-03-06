using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace HostingTest{

    internal struct LangSetup {

        internal string[] Names{get;private set;}
        internal string[] Extensions { get; private set; }
        internal string DisplayName { get; private set; }
        internal string TypeName { get; private set; }
        internal string AssemblyString { get; private set; }

        public override string ToString() {
            return string.Format("<language names=\"{0}\" extensions=\"{1}\" displayName=\"{2}\" type=\"{3}, {4}\"/>",
                        GetAsString(Names), GetAsString(Extensions), DisplayName, TypeName, AssemblyString);
        }

        private string GetAsString(string[] items) {
            if (items == null) return "";

            StringBuilder retString = new StringBuilder();
            foreach (var item in items) {
                if (item != null) {
                    if (retString.Length != 0)
                        retString.Append(',');
                    retString.Append(item);
                }
            }

            return retString.ToString();
        }

        internal LangSetup(string[] names, string[] exts, string displayName, string typeName, string assemblyString):this() {
            Names = names; Extensions = exts; DisplayName = displayName; TypeName = typeName;
            AssemblyString = assemblyString;
        }

        static LangSetup() {
            Python = new LangSetup( new[] { "IronPython","Python","py" },new[] { ".py" }, "IronPython 3.0",
                "IronPython.Runtime.PythonContext", "IronPython, Version=2.9.0.0, Culture=neutral"
            );
        }

        internal static LangSetup Python, Ruby;
    }
}
