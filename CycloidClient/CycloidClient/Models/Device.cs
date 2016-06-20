using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidClient.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<bool> State { get; set; }
        public int RoomId { get; set; }
        public Nullable<double> OnTemperature { get; set; }
        public Nullable<double> OffTemperature { get; set; }
        public bool IsAutomaticOnff { get; set; }
        public virtual Room Room { get; set; }
    }
}
