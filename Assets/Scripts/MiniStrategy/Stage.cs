using System.Collections.Generic;

namespace MiniStrategy
{
    public abstract class Stage
    {
        protected readonly List<ActionBase> availableActions = new List<ActionBase>();

        public Stage NextStage;
        public string name;
        public int moveLimit = int.MaxValue;

        public void Register(StageAction action)
        {
            action.stage = this;
            availableActions.Add(action);
        }

        public ActionBase GetAction(int index)
        {
            if (index < 0 || index >= availableActions.Count)
            {
                return null;
            }
            return availableActions[index];
        }
    }
}