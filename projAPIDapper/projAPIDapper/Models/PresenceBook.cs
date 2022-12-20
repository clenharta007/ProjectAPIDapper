using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projAPIDapper.Models
{
    public class PresenceBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Provinsi { get; set; }
        public string Kota { get; set; }
        public string Kecamatan { get; set; }
        public string Kelurahan { get; set; }
        public string Kodepos { get; set; }
        public string DateAdded { get; set; }

    }
}
