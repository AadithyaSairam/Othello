# Othello

A console implementation of Othello (Reversi) in C#, for two human players on
one keyboard.

```bash
dotnet run
```

The board is an 8x8 `string[,]`. A move is legal only if it brackets at least
one run of the opponent's pieces between the new piece and an existing one of
your own, in any of the eight directions, that bracketing check
(`validMove`) is most of the game's logic, since it also determines which
pieces flip. Play ends when neither player has a legal move, which is why
`gameContinue` scans the whole board for both colours rather than just the
player to move.

An early project, kept for the record. Archived.
