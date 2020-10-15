using System;
using System.Collections.Generic;
using System.Threading;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using UnityEngine;

namespace MiniStrategy
{
    [Serializable]
    public class ActionSequence
    {
        protected readonly Queue<IAction> actionWait = new Queue<IAction>();
        protected readonly Queue<IAction> actionDone = new Queue<IAction>();
        protected bool executing;
        protected bool paused;

        [Range(0, 3000)]
        public int delayMS = 0;

        public virtual void Register(IAction action)
        {
            actionWait.Enqueue(action);
        }

        public void NextAction()
        {
            if (executing)
            {
                Debug.LogWarning("Action is executing, waiting.");
                return;
            }
            Thread.Sleep(delayMS);
            NextCoro();
        }

        public void UndoAction()
        {
            UndoCoro();
        }

        public void RunUntilEnd()
        {
            while (actionWait.Count != 0)
            {
                NextAction();
            }
        }

        public void UndoUntilEnd()
        {
            while (actionDone.Count != 0)
            {
                UndoAction();
            }
        }

        public void Pause()
        {
            paused = true;
        }

        public void Resume()
        {
            paused = false;
        }

        public virtual string Save()
        {
            throw new NotImplementedException();
        }

        public static ActionSequence Load(string saved)
        {
            throw new NotImplementedException();
        }

        protected virtual void NextCoro()
        {
            executing = true;

            while (paused)
            {
                Thread.Sleep(100);
            }

            if (actionWait.Count > 0)
            {
                IAction action = actionWait.Dequeue();
                action.Execute();
                actionDone.Enqueue(action);
            }
            else
            {
                Debug.LogWarning("No action can be executed.");
            }
            executing = false;
        }

        protected virtual void UndoCoro()
        {
            if (actionDone.Count > 0)
            {
                IAction action = actionDone.Dequeue();
                action.Undo();
            }
            else
            {
                Debug.LogWarning("No action can be undo.");
            }
        }

        public override string ToString()
        {
            return "ActionSequence, wait: " + actionWait.Count + ", done: " + actionDone.Count;
        }
    }
}