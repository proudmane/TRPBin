using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPBin.Models
{
    public class RawTRPData
    {
        public Guid Id { get; set; }
        public string ExportString { get; set; } = "";
    }
}