namespace MiniStrategy
{
    public class RealTimeSequence : ActionSequence
    {
        public override void Register(IAction action)
        {
            base.Register(action);

            NextAction();
        }
    }
}