using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyoeiSystem.Common
{
    public interface IData
    {
        string GetRootDirectoryPath();
    }


    abstract class BaseData: IData
    {
        protected virtual string rootPath { get; set; }
        protected string exePath { get; set; }

        public BaseData()
        {
            rootPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            exePath = System.Reflection.Assembly.GetEntryAssembly().Location;
        }

        public virtual string GetRootDirectoryPath()
        {
            return rootPath;
        }

        public string GetExeDirectoryPath()
        {
            return exePath;
        }
    }
}
