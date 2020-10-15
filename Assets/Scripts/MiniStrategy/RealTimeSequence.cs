namespace MiniStrategy
{
    public class RealTimeSequence : ActionSequence
    {
        public override void Register(ActionBase action)
        {
            base.Register(action);

            NextAction();
        }
    }
}