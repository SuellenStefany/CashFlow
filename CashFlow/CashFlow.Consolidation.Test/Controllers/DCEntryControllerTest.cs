using Xunit;
using Moq;
using CashFlow.Consolidation.API.Controllers;
using CashFlow.Consolidation.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CashFlow.Consolidation.Application.Interfaces;

namespace CashFlow.Consolidation.Test.Controllers
{
    public class DCEntryControllerTest
    {
        private readonly Mock<IDCEntryService> _mockService;
        private readonly DCEntryController _controller;

        public DCEntryControllerTest()
        {
            _mockService = new Mock<IDCEntryService>();
            _controller = new DCEntryController(_mockService.Object);
        }

        [Fact]
        public void GetEntries_ShouldReturnOkResult_WhenDataExists()
        {
            var result = _controller.Get().Result;
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
