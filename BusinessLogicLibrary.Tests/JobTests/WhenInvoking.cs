using CslaDemo;
using NUnit.Framework;

namespace BusinessLogicLibrary.Tests.JobTests
{
    public partial class JobTests
    {
        [TestFixture]
        public class WhenInvoking
        {
            [Test]
            public void CanCreate()
            {
                var myjob = Job.NewJob();
            }

            [Test]
            public void CanCreateThenSave()
            {
                var myjob = Job.NewJob();
                myjob.JobId = 12;
                myjob.VhtJobId = "aaA-513-a1b2c3d4";
                myjob.Listing = Listing.NewListing();
                myjob.Listing.ListingId = 27;
                myjob.Save();
            }
        }
    }
}
