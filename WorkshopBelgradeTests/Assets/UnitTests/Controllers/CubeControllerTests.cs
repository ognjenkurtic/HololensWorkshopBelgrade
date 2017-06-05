using System;
using System.Linq;
using Assets;
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

            var cubeController = new CubeController(numberOfMoves, movementService, Enumerable.Empty<QuadCubeController>().ToArray());

            // When
            cubeController.MyGameObjectPosition = startingPosition;
            cubeController.AnchorGameObjectPosition = targetPosition;
            cubeController.Click();

            // Then
            movementServiceMock.Verify(x => x.InitializeMovementTowardsPosition(startingPosition, numberOfMoves, targetPosition));
        }

        [TestMethod]
        public void GivenCube_WhenClickedForTheSecondTime_ThenExplosionInitialized()
        {
            // Given
            var movementServiceMock = new Mock<IMovementService>();
            var movementService = movementServiceMock.Object;

            var startingPosition = new Vector3(0, 0, 0);
            var movementDirection = new Vector3(5, 5, 5);
            const float movementSpeed = 5f;

            var quadCubeController = new QuadCubeController(movementService, movementDirection);
            var quadCubeControllers = new[] { quadCubeController };

            var cubeController = new CubeController(100, movementService, quadCubeControllers);

            // When
            quadCubeController.MovementSpeed = movementSpeed;
            quadCubeController.MyGameObjectPosition = startingPosition;
            cubeController.Click();
            cubeController.Click();

            // Then
            movementServiceMock.Verify(x => x.InitializeMovementInGivenDirection(startingPosition, movementDirection, movementSpeed));
        }
    }
}
