using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParserAssignment.DataAccess
{
    public interface IFileReader
    {
        public string Read(string fileName);
    }
}
