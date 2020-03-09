using System;
using System.Collections.Generic;
using idgag.AI;
using idgag.GameState.LaneSections;
using UnityEngine;

namespace idgag.GameState
{
    public class Lane : MonoBehaviour
    {
        [SerializeField] private LaneSection[] laneSections;

        private readonly List<AiController> aiControllers = new List<AiController>();
        public AiController[] AiControllers => aiControllers.ToArray();

        [Min(1)] [SerializeField] private int maxAiCount = 30;
        public bool MoreAiAllowed => aiControllers.Count < maxAiCount;

        public LaneSection[] LaneSections => laneSections;

        public float laneWidth = 5.0f;
        public float offset_horizontal = 1.5f;
        public float offset_vertical = 2.0f;
        public int Column_Max = 3;
        public Vector3 BusinessAppearLoc;
        public Vector3 EnvironmentalAppearLoc;

        private void Start()
        {
            BusinessAppearLoc = transform.position + new Vector3(-1.4f, 0, 0);
            EnvironmentalAppearLoc = BusinessAppearLoc + new Vector3(0, 0, -10);
        }

        public bool AddAiController(AiController newAiController, Vector3 spawnPos)
        {
            if (newAiController == null)
                return false;

            if (aiControllers.Count >= maxAiCount)
                return false;

            newAiController.lane = this;
            newAiController.gameObject.SetActive(true);

            newAiController.ResetController(spawnPos);
            newAiController.TryMoveToStart();

            aiControllers.Add(newAiController);

            return true;
        }

        public void RemoveAiController(AiController aiControllerToRemove)
        {
            if (aiControllerToRemove == null)
                return;

            aiControllers.Remove(aiControllerToRemove);
        }
    }
}
