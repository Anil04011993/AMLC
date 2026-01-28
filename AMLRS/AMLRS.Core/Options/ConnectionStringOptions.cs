using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string DevCS { get; set; } = null!;
        //public string UatCS { get; set; } = null!;
        //public string ProdCS { get; set; } = null!;
    }
}
