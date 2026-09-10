// Connect 4 solver - check board for any possible winners (6x7)
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
int GetConnect4Winner(int[][] board)
{
    var winner = 0;
    var tokenCount = 0;
    
    for (var row = 0; row < board.Length; row++)
    {
        for (var col = 0; col < board[row].Length; col++)
        {
            // the current token we're checking
            var startToken = board[row][col];
            if (startToken == 0) continue; // ignore empty spaces

            tokenCount = 1;
            
            // horizontal lookahead from current position
            for (var nextCol = col + 1; nextCol < board[row].Length; nextCol++)
            {
                if (tokenCount >= 4) break;
                
                var nextToken = board[row][nextCol];
                if (nextToken == startToken)
                {
                    tokenCount += 1;
                }
                else
                {
                    tokenCount = 1;
                    break; // at this point don't need to continue looking
                }
            }

            // vertical lookahead
            for (var nextRow = row + 1; nextRow < board.Length; nextRow++)
            {
                if (tokenCount >= 4) break;
                
                var nextToken = board[nextRow][col];
                if (nextToken == startToken)
                {
                    tokenCount += 1;
                }
                else
                {
                    tokenCount = 1;
                    break; // at this point don't need to continue looking
                }
            }
            
            if (tokenCount >= 4)
            {
                return startToken;
            }
        }
    }
    
    return winner;
}

// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// * * * * * * *
// 1 1 1 1 * * *
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

Console.WriteLine($"Board 1 winner was: {GetConnect4Winner(board1)} {GetConnect4Winner(board1) == 1}");
Console.WriteLine($"Board 2 winner was: {GetConnect4Winner(board2)} {GetConnect4Winner(board2) == 1}");
Console.WriteLine($"Board 3 winner was: {GetConnect4Winner(board3)} {GetConnect4Winner(board3) == 2}");