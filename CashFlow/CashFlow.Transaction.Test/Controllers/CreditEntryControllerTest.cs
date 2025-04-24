using CashFlow.Transaction.API.Controllers;
using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CashFlow.Transaction.Test.Controllers
{
    public class CreditEntryControllerTest
    {
        private readonly ICreditEntryService _creditEntryService;
        private readonly Mock<ICreditEntryRepository> _mockRepository;
        private readonly CreditEntryController _creditEntryController;
        public CreditEntryControllerTest()
        {
            _mockRepository = new Mock<ICreditEntryRepository>();
            _creditEntryService = new CreditEntryService(_mockRepository.Object);
            _creditEntryController = new CreditEntryController(_creditEntryService);
        }
        [Fact]
        public async Task PostWithSuccessTest()
        {
            CreateDCEntryDto createDCEntry = new CreateDCEntryDto
            {
                Value = 10
            };
            var result = await _creditEntryController.Post(createDCEntry);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
