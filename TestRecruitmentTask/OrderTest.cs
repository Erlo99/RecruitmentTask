using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestRecruitmentTask
{
    public class Tests
    {

        [Test]
        public async Task Post_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<I>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Test]
        public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new HomeController(mockRepo.Object);
            var newSession = new HomeController.NewSessionModel()
            {
                SessionName = "Test Name"
            };

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }
    }
}