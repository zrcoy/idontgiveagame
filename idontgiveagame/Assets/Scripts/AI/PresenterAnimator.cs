using UnityEngine;

namespace idgag.AI
{
    [RequireComponent(typeof(Animator))]
    public class PresenterAnimator : MonoBehaviour
    {
        private Animator presenterAnimator;
        private static readonly int IsTalking = Animator.StringToHash("IsTalking");

        private void Awake()
        {
            presenterAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            Present(false);
        }

        public void Present(bool presenting)
        {
            presenterAnimator.SetBool(IsTalking, presenting);
        }
    }
}
