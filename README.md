## miniStrategy

[![Documentation Status](https://readthedocs.org/projects/ansicolortags/badge/?version=latest)](https://github.com/KHN190/miniStrategy/wiki)
[![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg)](https://github.com/KHN190/miniStrategy/blob/master/license)

Strategy framework that features:

* Redo / Undo for everything ☑️
	* that means every action changes a state, and the final state is procedurally built on a series of actions, thus given a fixed sequence of actions, the world can be rewinded to any state
* Three modes
	* turn based mode, traditional one ☑️
	* real time mode, every action is executed on the fly ☑️
	* mix mode, plan in a turn, act simultaneously
* Pause / Resume ☑️
* Execute with a delay ☑️
* Serialize / Deserialize actions and sequence

Read [wiki here](https://github.com/KHN190/miniStrategy/wiki).

## Related

* [miniHexMap](https://github.com/KHN190/miniHexMap), a hexagon map editor

## Plans

* Godot export
* Wiki

## Reference

* [Boardgame.io](https://boardgame.io/documentation/), a turn based framework supports multiplayer in JavaScript. It has useful concepts.
