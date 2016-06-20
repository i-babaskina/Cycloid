using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidClient.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Temperature { get; set; }
        public Nullable<double> Humidity { get; set; }
        public int UserId { get; set; }
        public ICollection<Device> Device { get; set; }
    }
}
