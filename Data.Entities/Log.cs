﻿using Data.Entities.Abstract;
using System;

namespace Data.Entities
{
    public partial class Log : BaseEntity
    {
        public string Application { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string CallSite { get; set; }
        public string Exception { get; set; }
    }
}
