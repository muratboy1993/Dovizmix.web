using System;

namespace Common.Model.ExceptionLog.Dto
{
    public class DtoExceptionLog
    {

        public string Message { get; set; }

        public DateTime DateTime { get; set; }

        public string Ip { get; set; }

        public string Method { get; set; }

        public string Source { get; set; }

        public string Path { get; set; }

    }
}
