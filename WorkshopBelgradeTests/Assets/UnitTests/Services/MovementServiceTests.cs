using System;
using Assets.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;

namespace WorkshopBelgradeTests.Assets.UnitTests.Services
{
    [TestClass]
    public class MovementServiceTests
    {
        [TestMethod]
        public void GivenMovementService_WhenMovementInitializedWithOneMove_ThenPerformMoveMovesObjectToFinalPosition()
        {
            // Given
            var movementService = new MovementService();
            var startingPosition = new Vector3(0, 0, 0);
            var targetPosition = new Vector3(1, 1, 1);

            movementService.InitializeMovementTowardsPosition(startingPosition, 1, targetPosition);

            // When
            var position = movementService.PerformMove();

            // Then
            Assert.AreEqual(targetPosition, position);
        }

        [TestMethod]
        public void GivenMovementService_WhenMovementInitializedWithTwoMoves_ThenPerformMoveMovesObjectHalfAWay()
        {
            // Given
            var movementService = new MovementService();
            var startingPosition = new Vector3(0, 0, 0);
            var targetPosition = new Vector3(1, 1, 1);

            movementService.InitializeMovementTowardsPosition(startingPosition, 2, targetPosition);

            // When
            var position = movementService.PerformMove();

            // Then
            Assert.AreEqual(new Vector3(0.5f, 0.5f, 0.5f), position);
        }
    }
}