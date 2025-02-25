namespace MeeshoClone.Models.Supplier
{
    public class Supplier
    {
        public long Id { get; set; }
        public long UserId { get; set; }  // Link to the logged-in user
        public string GSTIN { get; set; }  // GSTIN for tax purposes
        public string BusinessName { get; set; }  // Business Name
        public string? StoreName { get; set; }  // Name of the store
        public string? BusinessAddress { get; set; }  // Address of the business
        public string State { get; set; }  // State/Province
        public string Postcode { get; set; }  // Postal code
        public string Country { get; set; }  // Country
        public string PhoneNumber { get; set; }  // Business phone number
        public string Email { get; set; }  // Business email
        public string BankAccountNumber { get; set; }  // Bank account number for payments
        public string BankName { get; set; }  // Name of the bank
        public string IFSCCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
