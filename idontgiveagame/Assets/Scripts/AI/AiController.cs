using idgag.GameState;
using idgag.GameState.LaneSections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace idgag.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class AiController : MonoBehaviour
    {
        [SerializeField] protected float sectionAnimationDistance = 1.22474487f;
        protected float sectionAnimationDistanceSqr;

        protected NavMeshAgent navMeshAgent;

        public Lane lane;
        protected int laneSectionIndex = -1;

        public FuckBucketTarget fuckTarget;

        public float minFucksPercentThreshold = 0.5f;
        public float maxFucksPercentThreshold = 0.75f;
        protected float fucksPercentThreshold;

        protected bool walking;

        protected void Awake()
        {
            sectionAnimationDistanceSqr = sectionAnimationDistance * sectionAnimationDistance;
            fucksPercentThreshold = Random.Range(minFucksPercentThreshold, maxFucksPercentThreshold);

            navMeshAgent = GetComponent<NavMeshAgent>();
            Debug.Assert(navMeshAgent != null, $"{nameof(NavMeshAgent)} could not be found on the {nameof(GameObject)}");
        }

        protected abstract void AnimateRiot();
        protected abstract void AnimateWalk();

        private float Dist2D(Vector3 from, Vector3 to)
        {
            float xComponent = to.x - from.x;
            float yComponent = to.y - from.y;

            return (xComponent * xComponent) + (yComponent * yComponent);
        }

        protected void FixedUpdate()
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = navMeshAgent.destination;

            if (Dist2D(myPos, targetPos) <= sectionAnimationDistanceSqr)
            {
                if (!walking) return;

                walking = false; // Play riot animation
                AnimateRiot();
            }
            else
            {
                if (walking) return;

                walking = true; // Play walking animation
                AnimateWalk();
            }
        }

        public abstract void RunAiLogic();

        public bool TryMoveForward()
        {
            LaneSection[] laneSections = lane.LaneSections;

            if (laneSectionIndex < laneSections.Length - 1)
            {
                if (laneSectionIndex >= 0)
                {
                    LaneSection curSection = laneSections[laneSectionIndex];

                    if (!curSection.IsAllowedToPass())
                        return false;

                    curSection.RemoveAi();
                }

                laneSectionIndex++;
                LaneSection newSection = laneSections[laneSectionIndex];
                newSection.AddAi();

                Vector3 destPos = newSection.GetAiPosition();

                if (!SetDestination(destPos))
                    Warp(destPos);

                return true;
            }

            return false;
        }

        public bool TryMoveToStart()
        {
            laneSectionIndex = -1;
            return TryMoveForward();
        }

        public void ResetController(Vector3 newPosition)
        {
            Warp(newPosition);
            SetDestination(newPosition);

            laneSectionIndex = -1;
        }

        public void Warp(Vector3 newPosition)
        {
            navMeshAgent.Warp(newPosition);
        }

        public bool SetDestination(Vector3 newDestination)
        {
            return navMeshAgent.SetDestination(newDestination);
        }

        public void Remove()
        {
            gameObject.SetActive(false);

            if (lane == null) return;

            lane.RemoveAiController(this);

            if (laneSectionIndex < 0) return;

            LaneSection curSection = lane.LaneSections[laneSectionIndex];
            curSection.RemoveAi();
        }
    }
}
