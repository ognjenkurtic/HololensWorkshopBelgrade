using Assets.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeAnimationBehaviour : MonoBehaviour
    {
        private IMovementService _movementService;
        protected bool ShouldMove;

        public Vector3 MovementDirection;

        void Awake()
        {
            _movementService = Registration.Resolve<IMovementService>();
        }

        public void StartMovement()
        {
            ShouldMove = true;
            _movementService.InitializeMovementInGivenDirection(gameObject.transform.position, MovementDirection, Time.deltaTime);
        }
	
        // Update is called once per frame
        void Update ()
        {
            Animate();
        }

        public virtual void Animate()
        {
            if (!ShouldMove)
            {
                return;
            }

            gameObject.transform.position = _movementService.PerformMove();
        }
    }
}
