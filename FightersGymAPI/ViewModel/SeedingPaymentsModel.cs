namespace FightersGymAPI.ViewModel
{
    public class SeedingPaymentsModel
    {
       public int PaymentID { get; set; }   
            public DateTime PaymentDate { get; set; }   
            public double? Amount { get; set; } 
            public int? MemberID { get; set; }
            public int? ProductID { get; set; }
            public double? AmountLeft { get; set; }
            public string? description { get; set; }
            public int? CreatedBy { get; set; }

public int? F_Membership {  get; set; } 
    }
}
