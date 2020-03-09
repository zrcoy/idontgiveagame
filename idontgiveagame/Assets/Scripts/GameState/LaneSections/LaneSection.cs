using UnityEngine;

namespace idgag.GameState.LaneSections
{
    public abstract class LaneSection : MonoBehaviour
    {
        [SerializeField] protected GameObject aiDestination;
        public int numAi;

        protected void Awake()
        {
            Debug.Assert(aiDestination != null, $"{nameof(aiDestination)} must be assigned");
        }

        public abstract bool IsAllowedToPass();

        public Vector3 GetAiPosition()
        {
            return aiDestination.transform.position;
        }

        protected abstract void OnAiCountChange();

        public void AddAi()
        {
            numAi++;
            OnAiCountChange();
        }

        public void RemoveAi()
        {
            numAi--;
            OnAiCountChange();
        }
    }
}
