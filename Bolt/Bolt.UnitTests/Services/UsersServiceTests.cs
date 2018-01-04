namespace Bolt.UnitTests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using FluentAssertions;

    using DTOs.Users;
    using Core.Data.Repositories;
    using Data.Contexts.Bolt.Core;
    using Bolt.Services.Implementations;

    public class UsersServiceTests
    {
        [Fact]
        public async Task GetUserByUsernameAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const string username = "username";

            var service = new UsersService(unitOfWorkMock);

            Action result = async () => await service.GetUserByUsernameAsync(username);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task EditUserAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const string username = "username";
            var userDto = new UserDTO();

            var service = new UsersService(unitOfWorkMock);

            Action result = async () => await service.EditUserAsync(username, userDto);

            result.Should().NotThrow();
        }

        [Fact]
        public async Task GetUserIdByUsernameAsync_GivenAValidScenario_ShouldNotThrowAnException()
        {
            IUnitOfWork<IBoltDbContext> unitOfWorkMock = new Mock<IUnitOfWork<IBoltDbContext>>().Object;

            const string username = "username";

            var service = new UsersService(unitOfWorkMock);

            Action result = async () => await service.GetUserIdByUsernameAsync(username);

            result.Should().NotThrow();
        }
    }
}
