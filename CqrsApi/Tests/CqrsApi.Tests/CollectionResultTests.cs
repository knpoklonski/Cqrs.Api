using System.Linq;
using CqrsApi.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CqrsApi.Tests
{
    [TestClass]
    public class CollectionResultTests
    {
        [TestMethod]
        public void CollectionResult_ShouldCreateCorrectPrevLink()
        {
            var baseLink = @"https://localhost:44322/api/Customers?skip=20&top=10";

            var result = new CollectionResult<object>(Enumerable.Empty<object>(), 20, 10, baseLink);

            Assert.AreEqual(@"https://localhost:44322/api/Customers?skip=10&top=10", result.PrevLink);
        }

        [TestMethod]
        public void CollectionResult_ShouldCreateCorrectNextLink()
        {
            var baseLink = @"https://localhost:44322/api/Customers?skip=20&top=10";

            var result = new CollectionResult<object>(Enumerable.Empty<object>(), 20, 10, baseLink);

            Assert.AreEqual(@"https://localhost:44322/api/Customers?skip=30&top=10", result.NextLink);
        }

        [TestMethod]
        public void CollectionResult_ShouldCreateCorrectPrevLink_IfSkipLessThenTop()
        {
            var baseLink = @"https://localhost:44322/api/Customers?skip=5&top=10";

            var result = new CollectionResult<object>(Enumerable.Empty<object>(), 5, 10, baseLink);

            Assert.AreEqual(@"https://localhost:44322/api/Customers?top=10", result.PrevLink);
        }

        [TestMethod]
        public void CollectionResult_ShouldCreateCorrectPrevLink_IfTopLessThenSkip()
        {
            var baseLink = @"https://localhost:44322/api/Customers?skip=10&top=5";

            var result = new CollectionResult<object>(Enumerable.Empty<object>(), 10, 5, baseLink);

            Assert.AreEqual(@"https://localhost:44322/api/Customers?skip=5&top=5", result.PrevLink);
        }

        [TestMethod]
        public void CollectionResult_ShouldCreateCorrectNextLink_IfTopLessThenSkip()
        {
            var baseLink = @"https://localhost:44322/api/Customers?skip=10&top=5";

            var result = new CollectionResult<object>(Enumerable.Empty<object>(), 10, 5, baseLink);

            Assert.AreEqual(@"https://localhost:44322/api/Customers?skip=15&top=5", result.NextLink);
        }
    }
}
