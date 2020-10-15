using NUnit.Framework;
using MiniStrategy;
using System;

namespace Tests
{
    [Serializable]
    class Blackboard
    {
        public int number = 0;
    }

    class IncreaseNumber : ActionBase
    {
        public Blackboard blackboard;

        public override void Execute()
        {
            blackboard.number += 1;
        }

        public override void Undo()
        {
            blackboard.number -= 1;
        }
    }

    public class ActionTests
    {
        [Test]
        public void TestTrue() { }

        [Test]
        public void TestExecuteActions()
        {
            Blackboard blackboard = new Blackboard();
            ActionSequence sequence = new ActionSequence();

            IncreaseNumber adder = new IncreaseNumber
            {
                blackboard = blackboard
            };

            for (int _ = 0; _ < 3; _++)
            {
                sequence.Register(adder);
            }

            sequence.RunUntilEnd();
            Assert.AreEqual(blackboard.number, 3);

            sequence.UndoUntilEnd();
            Assert.AreEqual(blackboard.number, 0);
        }
    }
}