using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Csla;

namespace CslaDemo
{
    [Serializable]
    public class Job : BusinessBase<Job>
    {
        #region properties
        public static readonly PropertyInfo<int> JobIdProperty = RegisterProperty<int>(c => c.JobId);

        [Required]
        [RegularExpression(@"^[1-9]+$")]
        public int JobId
        {
            get { return GetProperty(JobIdProperty); }
            set { SetProperty(JobIdProperty, value); }
        }

        public static readonly PropertyInfo<string> VhtJobIdProperty = RegisterProperty<string>(c => c.VhtJobId);

        [Required]
        [RegularExpression(@"^[a-zA-Z]{3}-[0-9]{3}-[a-zA-Z0-9]{8}$", ErrorMessage = "3chars-3nums-8numchars")]
        public string VhtJobId
        {
            get { return GetProperty(VhtJobIdProperty); }
            set { SetProperty(VhtJobIdProperty, value); }
        }

        public static readonly PropertyInfo<Listing> ListingProperty = RegisterProperty<Listing>(c => c.Listing);
        [Required]
        public Listing Listing
        {
            get { return GetProperty(ListingProperty); }
            set { SetProperty(ListingProperty, value); }
        }
        #endregion properties

        #region factorymethods
        public static async Task<Job> NewJobAsync()
        {
            return await DataPortal.CreateAsync<Job>();
        }

        public static async Task<Job> GetJobAsync(int id)
        {
            return await DataPortal.FetchAsync<Job>(id);
        }

        public static void NewJob(EventHandler<DataPortalResult<Job>> callback)
        {
            DataPortal.BeginCreate<Job>(callback);
        }

        public static void GetJob(int id, EventHandler<DataPortalResult<Job>> callback)
        {
            DataPortal.BeginFetch<Job>(id, callback);
        }

#if !SILVERLIGHT
        public static Job NewJob()
        {
            return DataPortal.Create<Job>();
        }

        public static Job GetJob(int id)
        {
            return DataPortal.Fetch<Job>(id);
        }

        public static void DeleteJob(int id)
        {
            DataPortal.Delete<Job>(id);
        }
#endif
        #endregion factorymethods
    }
}
