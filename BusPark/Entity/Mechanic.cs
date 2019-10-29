using System;
using System.Collections.Generic;
using System.Text;

namespace BusPark.Entity
{
    public class Mechanic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
        public Guid BusId { get; set; }
        public bool IsWorking { get; set; }
    }
}
