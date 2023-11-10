using AutoMapper;
using Moq;
using ValuationApp.DataAccess.Repository.Contracts;
using ValuationApp.Entities;
using ValuationApp.Mappings;
using ValuationApp.Services;
using ValuationApp.Services.Contract;
using ValuationApp.ValuationDto;

namespace ValuationApp.UnitTests.Services
{
    public class VesselServiceTests
    {
        [Fact]
        public async void Create_ValidVessel_Ok()
        {
            //Arrange
            var vesselId = 1;
            var vesselToAdd = new VesselDto()
            {
                Description = "Description",
                Imo = "123123",
                Name = "Name",
            };
            var vesselRepositoryMock = new Mock<IVesselRepository>();

            vesselRepositoryMock.Setup(x => x.GetByImo(vesselToAdd.Imo)).Returns(Task.FromResult((Vessel)null));
            vesselRepositoryMock.Setup(x => x.Create(It.IsAny<Vessel>())).ReturnsAsync(vesselId);

            var vesselService = GetService(vesselRepositoryMock.Object);

            //Act
            var result = await vesselService.Create(vesselToAdd);

            //Assert
            Assert.Equal(vesselId, result);

            vesselRepositoryMock.Verify(x => x.Create(It.IsAny<Vessel>()));
        }

        [Fact]
        public async void Create_VesselExist_ThrowException()
        {
            //Arrange
            var vesselToAdd = new VesselDto()
            {
                Description = "Description",
                Imo = "123123",
                Name = "Name",
            };

            var existedVessel = new Vessel()
            {
                Description = "Description",
                Imo = "123123",
                Name = "Name",
            };
            var vesselRepositoryMock = new Mock<IVesselRepository>();

            vesselRepositoryMock.Setup(x => x.GetByImo(vesselToAdd.Imo)).ReturnsAsync(existedVessel);

            var vesselService = GetService(vesselRepositoryMock.Object);

            //Act
            //Assert
            await Assert.ThrowsAsync<Exception>(() => vesselService.Create(vesselToAdd));
        }


        private IVesselService GetService(IVesselRepository vesselRepository)
        {
            var assemblies = new[]
            {
                typeof(VesselProfile).Assembly,
            };
            var mapConfig = new MapperConfiguration(config => config.AddMaps(assemblies));
            var mapper = mapConfig.CreateMapper();

            return new VesselService(vesselRepository, mapper);
        }
    }
}