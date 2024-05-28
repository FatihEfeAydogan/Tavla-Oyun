using System;
using System.Collections.Generic;

namespace BackgammonLogic
{
    public class RedPlayer : Player
    {
        public RedPlayer(string name, CheckerColor playerColor) : base(name, playerColor)
        {
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Board gameBoard, Dice gameDice)
        {
            if (gameBoard.GameBar.NumOfRedCheckers > 0)
            {
                return GetAvailableMovesFromBar(gameBoard, gameDice);
            }

            var availableMoves = new List<KeyValuePair<int, int>>();

            for (int i = gameBoard.Triangles.Count - 1; i >= 0; i--)
            {
                if (!gameDice.RolledDouble)
                {
                    AddMoveIfValid(gameBoard, gameDice.FirstCube, availableMoves, i, i + gameDice.FirstCube);
                }

                AddMoveIfValid(gameBoard, gameDice.SecondCube, availableMoves, i, i + gameDice.SecondCube);
            }

            return availableMoves;
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesFromBar(Board gameBoard, Dice gameDice)
        {
            var availableMoves = new List<KeyValuePair<int, int>>();

            AddMoveFromBarIfValid(gameBoard, gameDice.FirstCube, availableMoves);
            AddMoveFromBarIfValid(gameBoard, gameDice.SecondCube, availableMoves);

            return availableMoves;
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEat(Board gameBoard, Dice gameDice)
        {
            if (gameBoard.GameBar.NumOfRedCheckers > 0)
            {
                return GetAvailableMovesEatFromBar(gameBoard, gameDice);
            }

            var availableMovesEat = new List<KeyValuePair<int, int>>();

            for (int i = gameBoard.Triangles.Count - 1; i >= 0; i--)
            {
                if (!gameDice.RolledDouble)
                {
                    AddEatMoveIfValid(gameBoard, gameDice.FirstCube, availableMovesEat, i, i + gameDice.FirstCube);
                }

                AddEatMoveIfValid(gameBoard, gameDice.SecondCube, availableMovesEat, i, i + gameDice.SecondCube);
            }

            return availableMovesEat;
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMovesEatFromBar(Board gameBoard, Dice gameDice)
        {
            var availableMoves = new List<KeyValuePair<int, int>>();

            AddEatMoveFromBarIfValid(gameBoard, gameDice.FirstCube, availableMoves);
            AddEatMoveFromBarIfValid(gameBoard, gameDice.SecondCube, availableMoves);

            return availableMoves;
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableBearOffMoves(Board gameBoard, Dice gameDice)
        {
            var availableMoves = new List<KeyValuePair<int, int>>();

            for (int i = gameBoard.Triangles.Count - 1; i >= 18; i--)
            {
                if (!gameDice.RolledDouble)
                {
                    AddBearOffMoveIfValid(gameBoard, gameDice.FirstCube, availableMoves, i);
                }

                AddBearOffMoveIfValid(gameBoard, gameDice.SecondCube, availableMoves, i);
            }

            return availableMoves;
        }

        public override bool IsLegalPlayerInitialMove(Board gameBoard, int index)
        {
            return gameBoard.Triangles[index].CheckersColor == CheckerColor.Red && gameBoard.GameBar.NumOfRedCheckers == 0;
        }

        public override bool IsLegalPlayerFinalMove(Board gameBoard, int fromIndex, int toIndex, int cubeNumber)
        {
            return toIndex < gameBoard.Triangles.Count && // Check if the 'toIndex' is within the bounds of the board
                   toIndex - fromIndex == cubeNumber && // Check if the move is consistent with the cubeNumber
                   (gameBoard.Triangles[toIndex].CheckersColor == null || gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Red); // Check if the destination is empty or occupied by the player's own checker
        }


        public override bool IsLegalPlayerFinalMoveEat(Board gameBoard, int fromIndex, int toIndex, int cubeNumber)
        {
            return toIndex < gameBoard.Triangles.Count && // Check if the 'toIndex' is within the bounds of the board
                   toIndex - fromIndex == cubeNumber && // Check if the move is consistent with the cubeNumber
                   gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Black && // Check if the destination is occupied by black checkers
                   gameBoard.Triangles[toIndex].NumOfCheckers == 1; // Check if there's only one black checker at the destination
        }

        public override bool IsLegalPlayerBearOffMove(int fromIndex, int cubeNumber)
        {
            return fromIndex + cubeNumber >= 24;
        }

        public override bool CanBearOffCheckers(Board gameBoard)
        {
            int numOfCheckersOutsideHome = gameBoard.GameBar.NumOfRedCheckers;

            for (int i = 0; i <= 17; i++)
            {
                if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Red)
                {
                    numOfCheckersOutsideHome += gameBoard.Triangles[i].NumOfCheckers;
                }
            }

            return numOfCheckersOutsideHome == 0;
        }

        public override void UpdateCheckersAtHome(Board gameBoard)
        {
            CheckersAtHome = 0;

            for (int i = 18; i <= 23; i++)
            {
                if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Red)
                {
                    CheckersAtHome += gameBoard.Triangles[i].NumOfCheckers;
                }
            }
        }

        private void AddMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves, int fromIndex, int toIndex)
        {
            if (toIndex < gameBoard.Triangles.Count && diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex) && IsLegalPlayerFinalMove(gameBoard, fromIndex, toIndex, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(fromIndex, toIndex));
            }
        }


        private void AddMoveFromBarIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves)
        {
            if (diceValue != 0 && IsLegalPlayerFinalMove(gameBoard, 24, 24 + diceValue, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(24, 24 + diceValue));
            }
        }

        private void AddEatMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMovesEat, int fromIndex, int toIndex)
        {
            if (toIndex >= 0 && diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex))
            {
                // Check if the move is valid without considering eating
                bool isValidMove = IsLegalPlayerFinalMove(gameBoard, fromIndex, toIndex, diceValue);

                // Check if the destination is occupied by a single opponent checker
                if (isValidMove && gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Red && gameBoard.Triangles[toIndex].NumOfCheckers == 1)
                {
                    // If so, add the move and indicate eating
                    availableMovesEat.Add(new KeyValuePair<int, int>(fromIndex, toIndex));
                }
            }
        }

        private void AddEatMoveFromBarIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMovesEat)
        {
            // Calculate the destination index for a move from the bar
            int toIndex = 24 - diceValue;

            if (diceValue != 0 && toIndex >= 0 && toIndex < gameBoard.Triangles.Count)
            {
                // Check if the move is valid without considering eating
                bool isValidMove = IsLegalPlayerFinalMove(gameBoard, 24, toIndex, diceValue);

                // Check if the destination is occupied by a single opponent checker
                if (isValidMove && gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Red && gameBoard.Triangles[toIndex].NumOfCheckers == 1)
                {
                    // If so, add the move and indicate eating
                    availableMovesEat.Add(new KeyValuePair<int, int>(24, toIndex));
                }
            }
        }


        private void AddBearOffMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves, int fromIndex)
        {
            if (diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex) && IsLegalPlayerBearOffMove(fromIndex, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(fromIndex, 24));
            }
        }
    }
}