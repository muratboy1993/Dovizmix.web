using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("City")]
    public partial class City : BaseEntity
    {
        public string Cities { get; set; }
    }
}
