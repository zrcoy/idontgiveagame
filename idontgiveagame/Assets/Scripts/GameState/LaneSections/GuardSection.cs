namespace idgag.GameState.LaneSections
{
    public class GuardSection : LaneSection
    {
        private GuardAnimator guardAnimator;
        public int capacity = 6;

        protected new void Awake()
        {
            base.Awake();

            guardAnimator = GetComponentInChildren<GuardAnimator>();
        }

        public override bool IsAllowedToPass()
        {
            return numAi > capacity;
        }

        protected override void OnAiCountChange()
        {
            guardAnimator.SetBlocking(numAi > 0);
        }
    }
}
