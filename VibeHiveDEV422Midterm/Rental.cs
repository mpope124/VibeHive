using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibeHiveDEV422Midterm
{
    public class Rental
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AlbumId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
