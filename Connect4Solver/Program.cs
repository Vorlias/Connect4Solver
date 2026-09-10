// Connect 4 solver - check board for any possible winners (6x7)
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *


// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// 1 1 1 1 * * *

using Connect4Solver;

int[][] board1 = [
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [1, 1, 1, 1, 0, 0],
];

// * * * * * * *
// * * * * * * *
// 1 * * * * * *
// 1 * * * * * *
// 1 * * * * * *
// 1 * * * * * *
int[][] board2 = [
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0],
    [1, 0, 0, 0, 0, 0],
];

// * * * * * * *
// * * * * * * *
// * * * 1 * * *
// * * 1 2 * * *
// * 1 2 1 * * *
// 1 2 1 1 * * *
int[][] board3 = [
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 2, 0, 0],
    [0, 0, 2, 1, 0, 0],
    [0, 2, 1, 2, 0, 0],
    [2, 1, 2, 2, 0, 0],
];

// * * * * * * *
// * * * * * * *
// 2 * 1 * * * *
// 1 2 2 1 * * *
// 1 1 2 2 * * *
// 1 1 1 2 * * *
int[][] board4 = [
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [2, 0, 1, 0, 0, 0],
    [1, 2, 2, 1, 0, 0],
    [1, 1, 2, 2, 0, 0],
    [1, 1, 1, 2, 0, 0],
];

/*
    Board 1 winner was: 1 True
    Board 2 winner was: 1 True
    Board 3 winner was: 2 True
    Board 4 winner was: 2 True
 */
Console.WriteLine($"Board 1 winner was: {RoughLookaheadSolver.GetConnect4Winner(board1)} {RoughLookaheadSolver.GetConnect4Winner(board1) == 1}");
Console.WriteLine($"Board 2 winner was: {RoughLookaheadSolver.GetConnect4Winner(board2)} {RoughLookaheadSolver.GetConnect4Winner(board2) == 1}");
Console.WriteLine($"Board 3 winner was: {RoughLookaheadSolver.GetConnect4Winner(board3)} {RoughLookaheadSolver.GetConnect4Winner(board3) == 2}");
Console.WriteLine($"Board 4 winner was: {RoughLookaheadSolver.GetConnect4Winner(board4)} {RoughLookaheadSolver.GetConnect4Winner(board4) == 2}");