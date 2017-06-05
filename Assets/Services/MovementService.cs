using System;
using Assets.Interfaces;
using UnityEngine;

namespace Assets.Services
{
    public enum MovementType
    {
        TowardsPosition,
        WithGivenDirection
    }

    public class MovementService : IMovementService
    {
        private Vector3 _currentPosition;
        private Vector3 _targetPosition;
        private bool _movementInitialized;

        private int _movesLeft;
        private Vector3 _movementDirection;
        private int _numberOfMoves;

        private MovementType _movementType;

        public void InitializeMovementTowardsPosition(Vector3 startingPosition, int numberOfMoves, Vector3 targetPosition)
        {
            _currentPosition = startingPosition;
            _numberOfMoves = numberOfMoves;
            _targetPosition = targetPosition;
            
            var dx = (_targetPosition.x - _currentPosition.x) / _numberOfMoves;
            var dy = (_targetPosition.y - _currentPosition.y) / _numberOfMoves;
            var dz = (_targetPosition.z - _currentPosition.z) / _numberOfMoves;
            _movementDirection = new Vector3(dx, dy, dz);

            _movesLeft = numberOfMoves;

            _movementType = MovementType.TowardsPosition;
            _movementInitialized = true;
        }

        public void InitializeMovementInGivenDirection(Vector3 startingPosition, Vector3 movementDirection, float movementSpeed)
        {
            _currentPosition = startingPosition;
            _movementDirection = movementDirection * movementSpeed;

            _movementType = MovementType.WithGivenDirection;
            _movementInitialized = true;
        }

        public Vector3? PerformMove()
        {
            if (ShouldMove)
            {
                _currentPosition += _movementDirection;
                if (_movementType == MovementType.TowardsPosition)
                {
                    _movesLeft--;
                }

                return _currentPosition;
            }

            return null;
        }

        private bool ShouldMove
        {
            get { return _movementInitialized && (_movementType == MovementType.WithGivenDirection || _movesLeft > 0); }
        }
    }
}
