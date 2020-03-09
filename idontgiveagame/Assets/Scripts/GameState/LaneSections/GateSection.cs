namespace idgag.GameState.LaneSections
{
    public class GateSection : LaneSection
    {
        public int capacity = 10;

        public override bool IsAllowedToPass()
        {
            return numAi > capacity;
        }

        protected override void OnAiCountChange()
        {
        }
    }
}
