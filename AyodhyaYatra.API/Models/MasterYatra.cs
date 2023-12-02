﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class MasterYatra : BaseModel
    {
        public string? HiName { get; set; }
        public string EnName { get; set; }
        public string? TaName { get; set; }
        public string? TeName { get; set; }
        public string EnDescription { get; set; }
        public string? HiDescription { get; set; }
        public string? TaDescription { get; set; }
        public string? TeDescription { get; set; }
        public int? ParentYatraId { get; set; }
        [ForeignKey("ParentYatraId")]
        public MasterYatra ParentYatra { get; set; }
        public List<Temple> Temples { get; set; }
        public List<ImageStore> Images { get; set; }
        public int DisplayOrder { get; set; }
    }
}