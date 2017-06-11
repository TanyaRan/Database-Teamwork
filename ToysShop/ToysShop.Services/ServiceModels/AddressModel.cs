using System;
using System.Linq.Expressions;
using ToysShop.Models.SQLModels;

namespace ToysShop.Services.ServiceModels
{
    public class AddressModel
    {
        public AddressModel()
        {
        }

        public AddressModel(Address address)
        {
            if (address != null)
            {
                this.Id = address.Id;
                this.FullAddress = address.FullAddress;
                this.CityId = address.City.Id;
                if (address.CustomerId != null)
                {
                    this.CustomerId = address.CustomerId;
                }
                else if (address.VendorId != null)
                {
                    this.VendorId = address.VendorId;
                }
            }
        }

        public int Id { get; set; }

        public int CityId { get; set; }

        public CityModel City { get; set; }

        public string FullAddress { get; set; }

        public int? CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public int? VendorId { get; set; }

        public VendorModel Vendor { get; set; }

        public static Expression<Func<Address, AddressModel>> Create
        {
            get
            {
                return a => new AddressModel()
                {
                    Id = a.Id,
                    FullAddress = a.FullAddress
                };
            }
        }
    }
}
