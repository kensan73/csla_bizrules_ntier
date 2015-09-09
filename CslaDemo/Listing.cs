using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Csla;

namespace CslaDemo
{
    [Serializable]
    public class Listing : BusinessBase<Listing>
    {
        public static readonly PropertyInfo<int> ListingIdProperty = RegisterProperty<int>(c => c.ListingId);

        [Required]
        [RegularExpression(@"^[1-9]+$")]
        public int ListingId
        {
            get { return GetProperty(ListingIdProperty); }
            set { SetProperty(ListingIdProperty, value); }
        }

        public static readonly PropertyInfo<string> CityProperty = RegisterProperty<string>(c => c.City);

        public string City
        {
            get { return GetProperty(CityProperty); }
            set { SetProperty(CityProperty, value); }
        }

        public static async Task<Listing> NewListingAsync()
        {
            return await DataPortal.CreateAsync<Listing>();
        }

        public static async Task<Listing> GetListingAsync(int id)
        {
            return await DataPortal.FetchAsync<Listing>(id);
        }

        public static void NewListing(EventHandler<DataPortalResult<Listing>> callback)
        {
            DataPortal.BeginCreate<Listing>(callback);
        }

        public static void GetListing(int id, EventHandler<DataPortalResult<Listing>> callback)
        {
            DataPortal.BeginFetch<Listing>(id, callback);
        }

#if !SILVERLIGHT
        public static Listing NewListing()
        {
            return DataPortal.Create<Listing>();
        }

        public static Listing GetListing(int id)
        {
            return DataPortal.Fetch<Listing>(id);
        }

        public static void DeleteListing(int id)
        {
            DataPortal.Delete<Listing>(id);
        }
#endif
        private void DataPortal_Fetch(int id)
        {
            using (BypassPropertyChecks)
            {
                ListingId = id;
                City = "Chicago " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
    }
}
