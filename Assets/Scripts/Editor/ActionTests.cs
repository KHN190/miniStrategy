using NUnit.Framework;
using MiniStrategy;
using System;

namespace Tests
{
    [Serializable]
    public class Blackboard
    {
        public int number = 0;
    }

    public class Adder : ActionBase
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
            // action
            Adder adder = new Adder
            {
                blackboard = blackboard
            };
            // sequence
            for (int _ = 0; _ < 3; _++)
            {
                sequence.Register(adder);
            }

            sequence.RunUntilEnd();
            Assert.AreEqual(blackboard.number, 3);

            sequence.UndoUntilEnd();
            Assert.AreEqual(blackboard.number, 0);
        }

        [Test]
        public void TestDisableUndo()
        {
            Blackboard blackboard = new Blackboard();
            ActionSequence sequence = new ActionSequence();

            Adder adder = new Adder
            {
                blackboard = blackboard,
                disableUndo = true
            };
            sequence.Register(adder);

            sequence.NextAction();
            sequence.UndoAction();

            Assert.AreEqual(sequence.nWait, 0);
            Assert.AreEqual(sequence.nDone, 1);
        }
    }
}