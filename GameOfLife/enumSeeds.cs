enum Seeds
{
    Blank,
    Random,
    StillLife,
    Oscillator,
    Spaceship
}
/*
Examples of patterns

Many different types of patterns occur in the Game of Life, which are classified according to their behaviour.
Common pattern types include:
    still lifes, which do not change from one generation to the next;
    oscillators, which return to their initial state after a finite number of generations;
    and spaceships, which translate themselves across the grid.

The earliest interesting patterns in the Game of Life were discovered without the use of computers.
The simplest still lifes and oscillators were discovered while tracking the fates of various
small starting configurations using graph paper, blackboards, and physical game boards, such as those used in go.
During this early research, Conway discovered that the R-pentomino failed to stabilize in a small number of generations.
In fact, it takes 1103 generations to stabilize, by which time it has a population of 116
and has generated six escaping gliders; these were the first spaceships ever discovered.

Frequently occurring examples (in that they emerge frequently from a random starting configuration of cells)
of the three aforementioned pattern types are shown below, with live cells shown in black and dead cells in white.
Period refers to the number of ticks a pattern must iterate through before returning to its initial configuration.

The pulsar is the most common period 3 oscillator.
The great majority of naturally occurring oscillators are period 2, like the blinker and the toad,
but oscillators of many periods are known to exist, and oscillators of periods 4, 8, 14, 15, 30,
and a few others have been seen to arise from random initial conditions.
Patterns which evolve for long periods before stabilizing are called Methuselahs,
the first-discovered of which was the R-pentomino.
Diehard is a pattern that eventually disappears, rather than stabilizing, after 130 generations,
which is conjectured to be maximal for patterns with seven or fewer cells.
Acorn takes 5206 generations to generate 633 cells, including 13 escaped gliders.

The R-pentomino

Diehard

Acorn

Conway originally conjectured that no pattern can grow indefinitely—
i.e. that for any initial configuration with a finite number of living cells,
the population cannot grow beyond some finite upper limit.
In the game's original appearance in "Mathematical Games", Conway offered a prize of fifty dollars
to the first person who could prove or disprove the conjecture before the end of 1970.
The prize was won in November by a team from the Massachusetts Institute of Technology, led by Bill Gosper;
the "Gosper glider gun" produces its first glider on the 15th generation,
and another glider every 30th generation from then on.
For many years, this glider gun was the smallest one known.
In 2015, a gun called the "Simkin glider gun", which releases a glider every 120th generation,
was discovered that has fewer live cells but which is spread out across a larger bounding box at its extremities.

Gosper glider gun
Simkin glider gun

Smaller patterns were later found that also exhibit infinite growth.
All three of the patterns shown below grow indefinitely.
The first two create a single block-laying switch engine:
a configuration that leaves behind two-by-two still life blocks as its translates itself across the game's universe.
The third configuration creates two such patterns.
The first has only ten live cells, which has been proven to be minimal.
The second fits in a five-by-five square, and the third is only one cell high.

Game of life infinite1.svg     Game of life infinite2.svg

Game of life infinite3.svg

Later discoveries included other guns, which are stationary, and which produce gliders or other spaceships;
puffer trains, which move along leaving behind a trail of debris; and rakes, which move and emit spaceships.
Gosper also constructed the first pattern with an asymptotically optimal quadratic growth rate,
called a breeder or lobster, which worked by leaving behind a trail of guns.

It is possible for gliders to interact with other objects in interesting ways.
For example, if two gliders are shot at a block in a specific position,
the block will move closer to the source of the gliders.
If three gliders are shot in just the right way, the block will move farther away.
This sliding block memory can be used to simulate a counter.
It is possible to construct logic gates such as AND, OR, and NOT using gliders.
It is possible to build a pattern that acts like a finite-state machine connected to two counters.
This has the same computational power as a universal Turing machine,
so the Game of Life is theoretically as powerful as any computer with unlimited memory and no time constraints;
it is Turing complete.
In fact, several different programmable computer architectures have been implemented in the Game of Life,
including a pattern that simulates Tetris.

Furthermore, a pattern can contain a collection of guns that fire gliders in such a way as to construct new objects,
including copies of the original pattern.
A universal constructor can be built which contains a Turing complete computer,
and which can build many types of complex objects, including more copies of itself.

In 2018, the first truly elementary knightship, Sir Robin, was discovered by Adam P. Goucher.
A knightship is a spaceship that moves two squares left for every one square it moves down (like a knight in chess),
as opposed to moving orthogonally or along a 45° diagonal.
This is the first new spaceship movement pattern for an elementary spaceship found in forty-eight years.
"Elementary" means that it cannot be decomposed into smaller interacting patterns such as gliders and still lifes.

*/
