using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXD.DTD
{
    public interface IXlsTDb
    {
        string FileToDb(DTDParameter parameter);
        string DbToFile(DTDParameter parameter);
    }
}
