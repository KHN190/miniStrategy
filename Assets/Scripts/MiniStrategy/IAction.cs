using System;
using UnityEngine;

namespace MiniStrategy
{
    public interface IAction
    {
        void Execute();
        void Undo();

        string ToJson();
    }

    /* Action has no stage */
    [Serializable]
    public abstract class ActionBase : IAction
    {
        public bool disableUndo = false;

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void Undo()
        {
            throw new NotImplementedException();
        }

        public virtual string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public static ActionBase Load(string saved)
        {
            return JsonUtility.FromJson<ActionBase>(saved);
        }
    }

    /* Action belongs to a stage */
    [Serializable]
    public abstract class StageAction : ActionBase
    {
        public Stage stage = null;
        public bool useMoveLimit = true;

        public override void Execute()
        {
            if (stage != null && useMoveLimit && stage.moveLimit > 0)
            {
                stage.moveLimit--;
            }
            /* other code here */
        }

        public override void Undo()
        {
            if (stage != null && useMoveLimit && stage.moveLimit < int.MaxValue)
            {
                stage.moveLimit++;
            }
            /* other code here */
        }
    }
}