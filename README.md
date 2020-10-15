## miniStrategy

Strategy framework that features:

* Redo / Undo for everything ☑️
	* that means every action changes a state, and the final state is procedurally built on a series of actions, thus given a fixed sequence of actions, the world can be rewinded to any state
* Three modes
	* turn based mode, traditional one ☑️
	* real time mode, every action is executed on the fly ☑️
	* mix mode, plan in a turn, act simultaneously
* Execute with a delay ☑️
* Serialize / Deserialize actions and sequence

## Use

There are currently two modes to pick: `TurnBaseSequence` or `RealTimeSequence`.

```csharp
// e.g.
TurnBaseSequence sequence = new TurnBaseSequence();
sequence.Register(action);
// execute
sequence.NextAction();
// undo
sequence.UndoAction();
```

And `action` implements `IAction`. See [unit test](./Assets/Scripts/Editor/ActionTests.cs) for detailed examples.

## Related

* [miniHexMap](https://github.com/KHN190/miniHexMap), a hexagon map editor

## Plans

* Godot export
* Wiki
