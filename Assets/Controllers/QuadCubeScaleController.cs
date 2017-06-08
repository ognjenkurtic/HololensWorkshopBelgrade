using Assets.Interfaces;
using UnityEngine;

namespace Assets.Controllers
{
    public class QuadCubeScaleController : QuadCubeController
    {
        public Vector3 CurrentScale { set; private get; }

        public QuadCubeScaleController(IMovementService movementService, Vector3 movementDirection) : base(movementService, movementDirection)
        {
        }

        public override void StartMovement()
        {
            base.StartMovement();
            MovementService.InitializeScaleChange(CurrentScale);
        }
    }
}