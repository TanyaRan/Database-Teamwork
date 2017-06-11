namespace ToysShop.Models.SQLModels
{
    public class Address
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string FullAddress { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int? VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
