using UnityEngine;

namespace Assets.Interfaces
{
    public interface IMovementService
    {
        void InitializeMovementTowardsPosition(Vector3 startingPosition, int numberOfMoves, Vector3 targetPosition);

        void InitializeMovementInGivenDirection(Vector3 startingPosition, Vector3 movementDirection, float movementSpeed);

        Vector3? PerformMove();

        Vector3? ChangeScale();

        void InitializeScaleChange(Vector3 startingScale);
    }
}
