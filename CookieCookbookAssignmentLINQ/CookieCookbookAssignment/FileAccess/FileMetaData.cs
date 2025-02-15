using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbookAssignment.FileAccess;

public class FileMetaData
{
    public string Name { get; }
    public FileType Type { get; }

    public FileMetaData(string name, FileType type)
    {
        Name = name;
        Type = type;
    }

    public string ToPath() => $"{Name}.{Type.AsFileExtension()}";
}
