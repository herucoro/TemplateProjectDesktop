using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyoeiSystem.Common
{
    public static class AssemblyInformation
    {
        public static readonly string assemblyTitle;
        public static readonly string assemblyProduct;
        public static readonly string fileVersion;

        static AssemblyInformation()
        {
            assemblyTitle = ((System.Reflection.AssemblyTitleAttribute)
                                Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(),
                                typeof(System.Reflection.AssemblyTitleAttribute))).Title;

            assemblyProduct = ((System.Reflection.AssemblyProductAttribute)
                                    Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(),
                                    typeof(System.Reflection.AssemblyProductAttribute))).Product;

            fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                            System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }
    }
}
