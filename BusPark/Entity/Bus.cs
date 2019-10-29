using System;
using System.Collections.Generic;
using System.Text;

namespace BusPark.Entity
{
    public class Bus
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid MechanicId { get; set; }
        public bool IsMechanicWorking { get; set; }
        public Guid ServiceId { get; set; }
    }
}
