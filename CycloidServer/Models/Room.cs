using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CycloidServer.Models
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Temperature { get; set; }
        public Nullable<double> Humidity { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Device> Device { get; set; }
        public virtual User User { get; set; }
    }
}