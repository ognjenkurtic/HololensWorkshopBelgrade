using UnityEngine;

namespace Assets.Controllers
{
    public class TextController
    {
        public Animator _textAnimator;

        public TextController(Animator AnimatorObject)
        {
            _textAnimator = AnimatorObject;
        }

        public void StartAnimation()
        {
            _textAnimator.enabled = true;
        }
    }
}
