using Microsoft.EntityFrameworkCore;
using PhoneBookManager.Domain;
using PhoneBookManager.Domain.Model;
using PhoneBookManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PhoneBookManager.Tests
{
    public class PhoneBookServiceTests
    {
        private readonly PhoneBookDbContext _dbContext;
        public Entry _dbEntity;
        public PhoneBookServiceTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookDbContext>();
            optionsBuilder.UseInMemoryDatabase("PhoneBook");
            _dbContext = new PhoneBookDbContext(optionsBuilder.Options);
            _dbContext.Database.EnsureDeleted();
            _dbEntity = new Entry { Id = 1, PhoneBookId = 1, Name = "Demo", PhoneNumber = "0841555585" };

        }



        [Fact]
        public void PhoneBookService_GetEntries()
        {
            // Arrange
            var classRepo = new PhoneBookService(_dbContext);

            classRepo.CreatePhoneBookEntry(_dbEntity);


            //Assert
            var result = classRepo.GetEntries();
            var totalRecords = result.Count;
            Assert.NotNull(result);
            Assert.Equal(1, totalRecords);

        }


        [Fact]
        public void PhoneBookService_Create()
        {
            // Arrange
            var classRepo = new PhoneBookService(_dbContext);

            var expectedData = _dbEntity;

            classRepo.CreatePhoneBookEntry(_dbEntity);

            //Assert
            var result = _dbContext.Entries.Find(_dbEntity.Id);
            Assert.NotNull(result);
            Assert.Equal(expectedData.Id, result.Id);
            Assert.Equal(expectedData.Name, result.Name);
            Assert.Equal(expectedData.PhoneNumber, result.PhoneNumber);
        }


        [Fact]
        public void PhoneBookService_Delete()
        {
            // Arrange
            var classRepo = new PhoneBookService(_dbContext);

            int entryId = classRepo.CreatePhoneBookEntry(_dbEntity);

            //Act
            classRepo.DeletePhoneBookEntry(entryId);

            //Assert
            var result = _dbContext.Entries.Find(entryId);
            Assert.Null(result);
        }
    }
}
