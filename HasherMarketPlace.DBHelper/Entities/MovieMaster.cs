﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HasherMarketPlace.DBHelper.Entities
{
    [PrimaryKey("Id")]
    [Table("MovieMaster")]
    public class MovieMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //This will make sure it will be an identity column, so will be autogenerated
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Language { get; set; }
        public string? Description { get; set; }
        public int RunningMin { get; set; }

    }
}
