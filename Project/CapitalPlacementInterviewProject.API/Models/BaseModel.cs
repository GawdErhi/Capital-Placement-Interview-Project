﻿using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementInterviewProject.API.Models
{
    public class BaseModel
    {
        [Key]
        public virtual string Id { get; set; }

        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual DateTime LastUpdatedAt { get; set; } = DateTime.Now;
    }
}
