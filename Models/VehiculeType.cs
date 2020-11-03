using System;

namespace CarManagement.Models
{
    public class VehiculeType
    {
        public int Id { get; set; }
        public Car Vehicule { get; set; }
        public string Type { get; set; }
    }
}
