Trying to get "Conway's Game of Life" working on the console.
Comments are a mix of:
	documentation ripped from the web,
	psuedo-code outlining,
	notes to myself,
	and some brainstorming 
Really just a spaghetti code mess. Needs loads of clean-up.

Found some stuff about using the mouse with the console, maybe we can get that working.
Until that is up and running, need to get some pre-gen seed patterns.
But before either of those happen, just get a random pattern working.
Until then, enumSeeds.cs and ConsoleListener.cs are unused.

Not working: compiles and runs without errors, no live cells show yet
current suspects:
	ranomizer in the constructor of GameBoard might not be doing its job
	draw method is not actually building strings right
	change list is really just a list of pointers to the same change object