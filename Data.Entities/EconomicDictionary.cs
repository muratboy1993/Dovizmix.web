﻿using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("EconomicDictionary")]
    public class EconomicDictionary : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Seourl { get; set; }
        public string Content { get; set; }

        [ForeignKey("CategoryId")]
        public virtual AlphabeticCategories EconomicDictionaryCategories { get; set; }
    }
}