using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace RentApp.Models.Entities
{
    public class BranchOffice
    {
        public BranchOffice()
        {
        }

        public BranchOffice(string imagePath, string address, double longtitue, double latitude, Service service) : this()
        {
            ImagePath = imagePath;
            Address = address;
            Longtitue = longtitue;
            Latitude = latitude;
            Service = service;
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public double Longtitue { get; set; }
        public double Latitude { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}