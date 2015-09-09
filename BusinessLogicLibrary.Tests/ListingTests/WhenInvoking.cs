using CslaDemo;
using NUnit.Framework;

namespace BusinessLogicLibrary.Tests.ListingTests
{
    public partial class ListingTests
    {
        [TestFixture]
        
        public class WhenInvoking
        {
            [Test]
            public void cancreateandsave()
            {
                var listing = Listing.NewListing();
                listing.ListingId = 23;
                listing.Save();
            }

            [Test]
            public void canfetch()
            {
                var listing = Listing.GetListing(27);

                Assert.That(listing.City, Is.StringStarting("Chicago"));
            }
        }
    }
}
