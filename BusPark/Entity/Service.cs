using System;
using System.Collections.Generic;
using System.Text;

namespace BusPark.Entity
{
    public class Service
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid BusId { get; set; }
        public bool IsActual { get; set; }
    }
}
