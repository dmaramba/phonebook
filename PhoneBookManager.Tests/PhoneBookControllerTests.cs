using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PhoneBookManager.Controllers;
using PhoneBookManager.Domain.Model;
using PhoneBookManager.Domain.Services;
using PhoneBookManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PhoneBookManager.Tests
{
   public class PhoneBookControllerTests
    {
        private readonly Mock<ILogger<PhoneBookController>> _logger;
        private readonly Mock<IPhoneBookService> _phoneBookService;

        public PhoneBookControllerTests()
        {
            _logger = new Mock<ILogger<PhoneBookController>>();
            _phoneBookService = new Mock<IPhoneBookService>();
        }


        [Fact]
        public void PhoneBook_Controller_GetContacts()
        {
            // Arrange
            var entries = new List<Entry>()
            {
                new Entry
                {
                    Id = 1,
                    Name = "Dumisani Maramba",
                    PhoneNumber = "0784864667"
                }
            };

            _phoneBookService.Setup(x => x.GetEntries()).Returns(entries);

            var controller = new PhoneBookController(_logger.Object, _phoneBookService.Object);

            // Act
            var response = controller.GetContacts();
 
            // assert
            Assert.NotNull(response);
            Assert.IsType<JsonResult>(response);
        }



        [Fact]
        public void PhoneBook_Controller_CreatePhoneBookEntry()
        {
            var entryModel = new EntryViewModel
            {
                Id = 1,
                Name = "Dumisani Maramba",
                PhoneNumber = "0784864667"
            };

            // Arrange
            _phoneBookService.Setup(x => x.CreatePhoneBookEntry(It.IsAny<Entry>())).Returns(entryModel.Id);

            var controller = new PhoneBookController(_logger.Object, _phoneBookService.Object);

            // Act
            var response = controller.CreatePhoneBookEntry(entryModel);

            // assert
            Assert.NotNull(response);
            Assert.IsType<JsonResult>(response);
        }



        [Fact]
        public void PhoneBook_Controller_DeletePhoneBookEntry()
        {
            bool result = true;
            // Arrange
            _phoneBookService.Setup(x => x.DeletePhoneBookEntry(It.IsAny<int>())).Returns(result);

            var controller = new PhoneBookController(_logger.Object, _phoneBookService.Object);

            // Act
            var response = controller.DeletePhoneBookEntry(It.IsAny<EntryViewModel>());

            // assert
            Assert.NotNull(response);
            Assert.IsType<JsonResult>(response);
        }
    }
}
