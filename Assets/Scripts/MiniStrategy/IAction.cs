using System;
using UnityEngine;

namespace MiniStrategy
{
    public interface IAction
    {
        void Execute();
        void Undo();

        string Save();
    }

    [Serializable]
    public abstract class ActionBase : IAction
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void Undo()
        {
            throw new NotImplementedException();
        }

        public virtual string Save()
        {
            return JsonUtility.ToJson(this);
        }

        public static IAction Load(string saved)
        {
            return JsonUtility.FromJson<IAction>(saved);
        }
    }
}