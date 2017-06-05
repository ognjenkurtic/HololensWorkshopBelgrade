using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeScaleAnimationBehaviour : QuadCubeAnimationBehaviour
    {
        private bool _shouldMove;

        public override void StartMovement()
        {
            base.StartMovement();

            _shouldMove = true;
        }

        public override void Animate()
        {
            if (_shouldMove)
            { 
                base.Animate();

            var scale = gameObject.transform.localScale;

            scale -= new Vector3(0.005f, 0.005f, 0.005f);
            if (scale == Vector3.zero)
            {
                _shouldMove = false;
            }

            gameObject.transform.localScale = scale;
                }
        }
    }
}
