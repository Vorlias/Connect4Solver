namespace Connect4Solver;

public class RoughLookaheadSolver
{
    /// <summary>
    /// A rough lookahead solver using loops - quite inefficient and definitely can be improved.
    ///
    /// Version 1.
    /// </summary>
    /// <param name="board">The board to check</param>
    /// <returns>The number of the winning player or 0 if nobody won</returns>
    /// <exception cref="ArgumentException">If there's invalid sizes to the board</exception>
    public static int GetConnect4Winner(int[][] board)
    {
        const int rowCount = 7;
        const int columnCount = 6;
        const int requiredTokenCount = 4;
        
        var winner = 0;
        var tokenCount = 0;

        if (board.Length != rowCount) throw new ArgumentException($"Invalid row count, should be {rowCount} for outer array of {nameof(board)}.");
        
        for (var row = 0; row < board.Length; row++)
        {
            if (board[row].Length != columnCount) throw new ArgumentException($"Invalid col count, should be {columnCount} for inner array of {nameof(board)}.");
            
            // Less than 4 rows left = no vertical possible
            var canCheckVertical = row <= rowCount - requiredTokenCount;

            for (var col = 0; col < board[row].Length; col++)
            {
                // Less than 4 columns = no horizontal possible
                var canCheckHorizontal = col <= columnCount - requiredTokenCount;
                // If we have less than 4 rows and cols left, then diagonally no winners can happen
                var canCheckForwardDiagonal = canCheckVertical && canCheckHorizontal; // check \
                var canCheckBackDiagonal = canCheckVertical && col >= requiredTokenCount - 1; // check / - using -1 because zero-based index
                
                // the current token we're checking
                var startToken = board[row][col];
                if (startToken == 0) continue; // ignore empty spaces

                tokenCount = 1;

                if (canCheckHorizontal)
                {
                    // horizontal lookahead from current position
                    for (var nextCol = col + 1; nextCol < board[row].Length; nextCol++)
                    {
                        if (tokenCount >= requiredTokenCount) break;
                    
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
                }

                if (canCheckVertical) {
                    // vertical lookahead
                    for (var nextRow = row + 1; nextRow < board.Length; nextRow++)
                    {
                        if (tokenCount >= requiredTokenCount) break;
                        
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
                }
                
                // diagonal
                // now with diagonal, it can go from left to right, or right to left.
                // \
                // /
                // we're gonna start off greedy here, can optimise later to be more lazy based on knowledge like how far we are from start/end vs what directions are realistic
                if (canCheckForwardDiagonal)
                {
                    for (var (y, x) = (row + 1, col + 1); y < rowCount && x < columnCount; x++, y++)
                    {
                        if (tokenCount >= requiredTokenCount) break;
                        
                        var nextToken = board[y][x];
                        if (nextToken != startToken)
                        {
                            tokenCount = 1;
                            break;
                        }

                        tokenCount += 1;
                    }
                }

                if (canCheckBackDiagonal)
                {
                    for (var (y, x) = (row + 1, col - 1); y < rowCount && x >= 0; x--, y++)
                    {
                        if (tokenCount >= requiredTokenCount) break;
                        
                        var nextToken = board[y][x];
                        if (nextToken != startToken)
                        {
                            tokenCount = 1;
                            break;
                        }

                        tokenCount += 1;
                    }
                }
                
                if (tokenCount >= requiredTokenCount)
                {
                    return startToken;
                }
            }
        }
        
        return winner;
    }
}