using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestStore.Web.Models.ShipAddress
{
    public class AddressCreationModel
    {
        public BestStore.Models.ShipAddress ShipAddress { get; set; }
        public string ProvinceListName { get; set; }
        public List<SelectListItem> Provinces { get; set; }
        public string CityListName { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
