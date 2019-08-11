using System;

namespace PriceCounting
{
    public class ProtocolModel
    {
        public string ProtocolNumber { get; set; }

        public DateTime ProtocolDate { get; set; }

        public string Owner { get; set; }

        public int Rate { get; set; }

        public string FilePath { get; set; }
    }
}
