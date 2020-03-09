using System;
using UnityEngine;

namespace idgag.GameState.LaneSections
{
    public class GuardAnimator : MonoBehaviour
    {
        private Animator[] guardAnimators;
        private static readonly int IsBlocking = Animator.StringToHash("IsBlocking");

        private void Awake()
        {
            guardAnimators = GetComponentsInChildren<Animator>();
        }

        private void Start()
        {
            SetBlocking(false);
        }

        public void SetBlocking(bool blocking)
        {
            foreach (Animator guardAnimator in guardAnimators)
            {
                guardAnimator.SetBool(IsBlocking, blocking);
            }
        }
    }
}
