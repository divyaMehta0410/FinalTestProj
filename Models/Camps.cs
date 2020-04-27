using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SharedProject.Models
{
    public class Camps
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsBooked { get; set; }

        public byte[] Image { get; set; }

    }
}