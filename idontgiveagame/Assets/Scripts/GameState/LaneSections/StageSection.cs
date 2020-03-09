namespace idgag.GameState.LaneSections
{
    public class StageSection : LaneSection
    {
        public override bool IsAllowedToPass()
        {
            return true;
        }

        protected override void OnAiCountChange()
        {
        }
    }
}
