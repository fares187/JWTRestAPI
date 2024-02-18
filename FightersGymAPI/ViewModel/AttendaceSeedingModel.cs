using FightersGymAPI.Models.added;
using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.ViewModel
{
    public class AttendaceSeedingModel
    {
        public int AttendanceID { get; set; }
       
        public string MemberID { get; set; }

        public DateTime AttendanceDate { get; set; }
        public int Barcode { get; set; }
    }
}
