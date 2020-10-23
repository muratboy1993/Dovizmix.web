using Data.Entities.Abstract;
using System;

namespace Data.Entities
{
    public class ExceptionLog : BaseEntity
    {

        public string Ip { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public string Method { get; set; }

        public string Source { get; set; }

        public string Path { get; set; }

    }
}
