using UnityEngine;

namespace Assets.Controllers
{
    public class TextController
    {
        private readonly Animator _textAnimator;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider _textColider;

        public TextController(Animator animatorObject, AudioSource audioSource, BoxCollider textCollider)
        {
            _textAnimator = animatorObject;
            _audioSource = audioSource;
            _textColider = textCollider;
        }

        public void StartAnimation()
        {
            _textAnimator.enabled = true;
        }

        public void OnMouseOver()
        {
            _audioSource.Play();
        }

        public void ResizeColider()
        {
            _textColider.size = new Vector3(5, 5, 5);
        }
    }
}
