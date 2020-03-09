using System;
using UnityEngine;

namespace idgag.AI
{
    public class EnvironmentalistAi : AiController
    {
        private Animator animator;
        private static readonly int IsIdle = Animator.StringToHash("IsIdle");
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        protected new void Awake()
        {
            base.Awake();

            animator = GetComponentInChildren<Animator>();
        }

        protected void Start()
        {
            animator.SetBool(IsIdle, false);
            animator.SetBool(IsWalking, true);
        }

        protected override void AnimateRiot()
        {
            animator.SetBool(IsWalking, false);
        }

        protected override void AnimateWalk()
        {
            animator.SetBool(IsWalking, true);
        }

        public override void RunAiLogic()
        {
            if (!GameState.GameState.Singleton.fuckBucketPercentages.TryGetValue(fuckTarget, out float fuckBucketPercent))
                return;

            if (fuckBucketPercent < fucksPercentThreshold)
            {
                TryMoveForward();
            }
            else
            {
                Remove();
            }
        }
    }
}
