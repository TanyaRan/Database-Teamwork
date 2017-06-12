using ToysShop.Models.SQLModels.Enums;
using ToysShop.Services.ServiceModels;

namespace ToysShop.Web.Models
{
    public class CityViewModel
    {
        public CityViewModel()
        {
        }

        public CityViewModel(CityModel city)
        {
            if (city != null)
            {
                this.Id = city.Id;
                this.Name = city.Name;
                this.Region = city.Region;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }
    }
}