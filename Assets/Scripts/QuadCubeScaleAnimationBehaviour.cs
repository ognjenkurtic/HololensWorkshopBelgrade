using Assets.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeScaleAnimationBehaviour : QuadCubeAnimationBehaviour
    {
        private QuadCubeScaleController QuadCubeScaleController
        {
            get { return (QuadCubeScaleController) QuadCubeController; }
        }

        protected override void SetControllerProperties()
        {
            base.SetControllerProperties();
            QuadCubeScaleController.CurrentScale = gameObject.transform.localScale;
        }

        public override void Animate()
        {
            base.Animate();

            var newScale = MovementService.ChangeScale();

            if (newScale.HasValue)
            {
                gameObject.transform.localScale = newScale.Value;
            }
        }

        protected override void CreateController()
        {
            QuadCubeController = new QuadCubeScaleController(MovementService, MovementDirection);
        }
    }
}
