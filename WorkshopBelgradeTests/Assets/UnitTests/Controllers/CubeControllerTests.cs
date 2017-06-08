using System.Security.Cryptography.X509Certificates;
using Assets.Controllers;
using Assets.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnityEngine;

namespace WorkshopBelgradeTests.Assets.UnitTests.Controllers
{
    [TestClass]
    public class CubeControllerTests
    {
        [TestMethod]
        public void GivenCube_WhenClicked_ThenMovementInitialized()
        {
            // Given
            var startingPosition = new Vector3(0, 0, 0);
            var targetPosition = new Vector3(1, 1, 1);
            var numberOfMoves = 100;

            var movementServiceMock = new Mock<IMovementService>();
            var movementService = movementServiceMock.Object;

            var cubeController = new CubeController(numberOfMoves, movementService, null, null);

            // When
            cubeController.MyGameObjectPosition = startingPosition;
            cubeController.AnchorGameObjectPosition = targetPosition;
            cubeController.Click();

            // Then
            movementServiceMock.Verify(x => x.InitializeMovementTowardsPosition(startingPosition, numberOfMoves, targetPosition));
        }

        [TestMethod]
        public void GivenCube_WhenClickedForTheSecondTime_ThenExplosionMovementInitialized()
        {
            // Given
            var movementServiceMock = new Mock<IMovementService>();
            var movementService = movementServiceMock.Object;

            var startingPosition = new Vector3(0, 0, 0);
            var movementDirection = new Vector3(5, 5, 5);
            const float movementSpeed = 5f;

            var quadCubeController = new QuadCubeController(movementService, movementDirection);

            var cubeController = new CubeController(100, movementService, null, null);

            // When
            cubeController.QuadCubeControllers = new[] { quadCubeController };
            quadCubeController.MovementSpeed = movementSpeed;
            quadCubeController.MyGameObjectPosition = startingPosition;
            cubeController.Click();
            cubeController.Click();

            // Then
            movementServiceMock.Verify(x => x.InitializeMovementInGivenDirection(startingPosition, movementDirection, movementSpeed));
        }

        [TestMethod]
        public void GivenCubeController_WhenClickedForTheSecondTime_ThenSoundPlayed()
        {
            // Given
            var soundServiceMock = new Mock<ISoundService>();
            var soundService = soundServiceMock.Object;

            var cubeController = new CubeController(100, null, soundService, null);

            // When
            cubeController.Click();
            cubeController.Click();

            // Then
            soundServiceMock.Verify(x => x.PlaySound());
        }
    }
}
