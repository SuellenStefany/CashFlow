using CashFlow.Transaction.API.Controllers;
using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CashFlow.Transaction.Test.Controllers
{
    public class DebitEntryControllerTest
    {
        private readonly IDebitEntryService _debitEntryService;
        private readonly Mock<IDebitEntryRepository> _mockRepository;
        private readonly DebitEntryController _debitEntryController;
        public DebitEntryControllerTest()
        {
            _mockRepository = new Mock<IDebitEntryRepository>();
            _debitEntryService = new DebitEntryService(_mockRepository.Object);
            _debitEntryController = new DebitEntryController(_debitEntryService);
        }
        [Fact]
        public async Task PostWithSuccessTest()
        {
            CreateDCEntryDto createDCEntry = new CreateDCEntryDto
            {
                Value = 10
            };
            var result = await _debitEntryController.Post(createDCEntry);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
