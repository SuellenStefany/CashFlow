using CashFlow.Consolidation.Application.DTOs;
using CashFlow.Consolidation.Application.Interfaces;
using CashFlow.Consolidation.Application.Services;
using Moq;
using Xunit;

namespace CashFlow.Consolidation.Test.Services
{
    public class DCEntryServiceTest
    {
        private readonly Mock<IDCEntryRepository> _mockRepository;
        private readonly DCEntryService _dCEntryService;

        public DCEntryServiceTest()
        {
            _mockRepository = new Mock<IDCEntryRepository>();
            _dCEntryService = new DCEntryService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetEntriesShouldReturnOkResultWhenDataExists()
        {
            var result = await _dCEntryService.GetDailyConsolidated();
            Assert.IsType<DCEntryDto>(result);
        }
    }
}
