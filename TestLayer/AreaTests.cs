using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace TestLayer
{
    public class AreaTests
    {
        private DimitarMatanskiDbContext _dbContext;
        private AreaRepository _areaRepository;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _dbContext = new DimitarMatanskiDbContext(builder.Options);
            _areaRepository = new AreaRepository(_dbContext);
        }

        [Test]
        public void CreateArea_ShouldReturnOk()
        {           
            Assert.DoesNotThrow(() => {
                var area = new Area { Name = "Joro" };
                _areaRepository.Create(area);
            });       
        }

        [Test]
        public void ReadArea_ShouldReturnOk()
        {
            var area = new Area { Name = "Joro" };
            _areaRepository.Create(area);

            area = _areaRepository.Read(1);
            Assert.IsNotNull(area);
        }

        [Test]
        public void ReadAllAreas_ShouldReturnOk()
        {
            var area = new Area { Name = "Joro" };
            _areaRepository.Create(area);

            var areas = _areaRepository.ReadAll();
            Assert.IsNotNull(areas);
        }

        [Test]
        public void UpdateArea_ShouldReturnOk()
        {
            var area = new Area { Name = "Joro" };
            _areaRepository.Create(area);

            area = _areaRepository.Read(1);
            area.Name = "Go6o";
            _areaRepository.Update(area);

            area = _areaRepository.Read(1);
            Assert.IsTrue(area.Name == "Go6o");
        }

        [Test]
        public void DeleteArea_ShouldReturnOk()
        {
            var area = new Area { Name = "Joro" };
            _areaRepository.Create(area);

            _areaRepository.Delete(1);
            area = _areaRepository.Read(1);

            Assert.IsNull(area);
        }
    }
}