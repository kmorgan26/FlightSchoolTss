using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Tests.Repositories
{
    public class GenericRepositoryTests
    {
        private readonly FstssDataContext _context;
        private readonly IGenericRepository<Maintainer> _repository;

        public GenericRepositoryTests()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<FstssDataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new FstssDataContext(options);

            _repository = new GenericRepository<Maintainer>(_context);
        }

        [Fact]
        public async Task AddAsync_AddsEntityToDatabase()
        {
            // Arrange
            var entity = new Maintainer {Id = 1, Name = "First" };

            // Act
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Contains(entity, _context.Set<Maintainer>());
        }

        [Fact]
        public async Task DeleteAsync_DeletesExistingEntityFromDatabase()
        {
            // Arrange
            var entity = new Maintainer { Id = 2, Name = "Second" };
            _context.Set<Maintainer>().Add(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.DeleteAsync(entity.Id);
            await _context.SaveChangesAsync();

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(entity, _context.Set<Maintainer>());
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalseForNonExistingEntity()
        {
            // Arrange
            var nonExistingEntityId = 999;

            // Act
            var result = await _repository.DeleteAsync(nonExistingEntityId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetAsync_ReturnsEntityById()
        {
            // Arrange
            var entity = new Maintainer {Id = 22, Name = "TwentySecond" };
            _context.Set<Maintainer>().Add(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAsync(entity.Id);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task GetAsync_ReturnsNullForNonExistingEntity()
        {
            // Arrange
            var nonExistingEntityId = 999;

            // Act
            var result = await _repository.GetAsync(nonExistingEntityId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllEntities()
        {
            // Arrange
            foreach(var entity in _context.Maintainers)
            {
                _context.Remove(entity);
            }
            await _context.SaveChangesAsync();
            var entities = new List<Maintainer>
            {
                new Maintainer { Id = 3, Name = "Third" },
                new Maintainer { Id = 4, Name = "Forth" },
                new Maintainer { Id = 5, Name = "Fifth" }
            };
            _context.Set<Maintainer>().AddRange(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();
            IEnumerable<Maintainer> sorted = result.OrderBy(i => i.Id);
            result = sorted.ToList();

            // Assert
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesExistingEntity()
        {
            // Arrange
            var entity = new Maintainer { Id = 6, Name = "Sixth" };
            _context.Set<Maintainer>().Add(entity);
            await _context.SaveChangesAsync();

            var updatedEntity = new Maintainer { Id = 6, Name = "Sixth" };

            // Act
            await _repository.UpdateAsync(updatedEntity.Id);
            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal(updatedEntity.Name, entity.Name);
        }

        [Fact]
        public async Task UpdateAsync_DoesNotModifyEntityForNonExistingId()
        {
            // Arrange
            var nonExistingEntityId = 999;
            var originalEntities = _context.Set<Maintainer>().ToList();

            // Act
            await _repository.UpdateAsync(nonExistingEntityId);
            await _context.SaveChangesAsync();

            // Assert
            var currentEntities = _context.Set<Maintainer>().ToList();
            Assert.Equal(originalEntities, currentEntities);
        }

        [Fact]
        public async Task Exists_ReturnsTrueForExistingEntityId()
        {
            // Arrange
            var entity = new Maintainer { Id = 13, Name = "Thirteenth" };
            _context.Set<Maintainer>().Add(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Exists(entity.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Exists_ReturnsFalseForNonExistingEntityId()
        {
            // Arrange
            var nonExistingEntityId = 999;

            // Act
            var result = await _repository.Exists(nonExistingEntityId);

            // Assert
            Assert.False(result);
        }

        // Add more unit tests for other scenarios

        // Remember to test edge cases, error conditions, and any other relevant scenarios.

    }
}
