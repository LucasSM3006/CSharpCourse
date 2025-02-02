using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbookAssignment.FileAccess;

public static class FileTypeExtensions
{
    public static string AsFileExtension(this FileType fileFormat) =>
        fileFormat == FileType.Json ? "json" : "txt";
}
