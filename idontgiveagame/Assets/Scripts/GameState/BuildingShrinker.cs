using System;
using System.Collections.Generic;
using idgag.AI;
using idgag.GameState.LaneSections;
using UnityEngine;

namespace idgag.GameState
{
    public class BuildingShrinker : MonoBehaviour
    {
        private Vector3 initialPosition;
        public float amountToSink = 190;

        public float percentPerTime = 0.001f;

        public float curPercent = 1;
        public float targetPercent = 1;

        private void Awake()
        {
            initialPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (targetPercent == curPercent)
                return;

            float distToPercent = targetPercent - curPercent;

            if (distToPercent <= percentPerTime)
            {
                curPercent = targetPercent;
                DirectSinkByPercent(targetPercent);
            }
            else
            {
                curPercent += distToPercent < 0 ? -percentPerTime : percentPerTime;
                DirectSinkByPercent(curPercent);
            }
        }

        public void DirectSinkByPercent(float percent)
        {
            transform.position = initialPosition - new Vector3(0, amountToSink * percent, 0);
        }

        public void SinkByPercent(float percent)
        {
            targetPercent = percent;
        }

        public void ResetPosition()
        {
            curPercent = 1;
            targetPercent = 1;
            transform.position = initialPosition;
        }
    }
}
