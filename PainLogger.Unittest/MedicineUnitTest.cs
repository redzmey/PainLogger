using Xunit;
using PainLogger.Model.Repositories;

namespace PainLogger.Unittest
{

    public class MedicineUnitTest
    {
        [Fact]
        public void RepositoryShouldReturnSomething()
        {
            var repo = new MedicineRepository();

            Assert.NotNull(repo.GetAll());
        }
    }
}
