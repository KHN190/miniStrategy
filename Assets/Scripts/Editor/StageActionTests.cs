using NUnit.Framework;
using MiniStrategy;

namespace Tests
{
    class StageActionForTest : StageAction
    {
        public override void Execute()
        {
            base.Execute();
        }

        public override void Undo()
        {
            base.Undo();
        }
    }

	class StageForTest : Stage {}

    public class StageActionTests
    {
		[Test]
		public void TestExecuteActions()
		{
			ActionSequence sequence = new ActionSequence();

            // stage
			StageForTest stage = new StageForTest()
			{
				moveLimit = 1
			};
			// action
			StageActionForTest action = new StageActionForTest();
			stage.Register(action);
            // sequence
			for (int i = 0; i < 2; i++)
			{
				sequence.Register(action);
            }
			Assert.AreEqual(stage.moveLimit, 1);

			// should execute
			sequence.NextAction();
			Assert.AreEqual(stage.moveLimit, 0);

			// should not
			sequence.NextAction();
            sequence.UndoAction();
            Assert.AreEqual(stage.moveLimit, 1);
        }
    }
}
