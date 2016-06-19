using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CycloidServer.Models
{
    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public Nullable<bool> State { get; set; }
        public int RoomId { get; set; }
        public Nullable<double> OnTemperature { get; set; }
        public Nullable<double> OffTemperature { get; set; }
        public bool IsAutomaticOnff { get; set; }

        public virtual Room Room { get; set; }
    }
}