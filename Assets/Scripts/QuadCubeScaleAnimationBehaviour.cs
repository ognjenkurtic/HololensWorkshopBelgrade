using UnityEngine;

namespace Assets.Scripts
{
    public class QuadCubeScaleAnimationBehaviour : QuadCubeAnimationBehaviour
    {
        public override void Animate()
        {
            base.Animate();
            
            var scale = gameObject.transform.localScale;

            scale -= new Vector3(0.005f, 0.005f, 0.005f);
            if (scale == Vector3.zero)
            {
                ShouldMove = false;
            }

            gameObject.transform.localScale = scale;
        }
    }
}
