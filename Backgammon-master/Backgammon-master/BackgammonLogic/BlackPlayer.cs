using System;
using System.Collections.Generic;

namespace BackgammonLogic
{
    public class BlackPlayer : Player
    {
        public BlackPlayer(string name, CheckerColor playerColor) : base(name, playerColor)
        {
        }

        public override IEnumerable<KeyValuePair<int, int>> GetAvailableMoves(Board gameBoard, Dice gameDice)
        {
            if (gameBoard.GameBar.NumOfBlackCheckers > 0)
            {
                return GetAvailableMovesFromBar(gameBoard, gameDice);
            }

            var availableMoves = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < gameBoard.Triangles.Count; i++)
            {
                if (!gameDice.RolledDouble)
                {
                    AddMoveIfValid(gameBoard, gameDice.FirstCube, availableMoves, i, i - gameDice.FirstCube);
                }

                AddMoveIfValid(gameBoard, gameDice.SecondCube, availableMoves, i, i - gameDice.SecondCube);
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
            if (gameBoard.GameBar.NumOfBlackCheckers > 0)
            {
                return GetAvailableMovesEatFromBar(gameBoard, gameDice);
            }

            var availableMovesEat = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < gameBoard.Triangles.Count; i++)
            {
                if (!gameDice.RolledDouble)
                {
                    AddEatMoveIfValid(gameBoard, gameDice.FirstCube, availableMovesEat, i, i - gameDice.FirstCube);
                }

                AddEatMoveIfValid(gameBoard, gameDice.SecondCube, availableMovesEat, i, i - gameDice.SecondCube);
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

            for (int i = 0; i <= 5; i++)
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
            return gameBoard.Triangles[index].CheckersColor == CheckerColor.Black && gameBoard.GameBar.NumOfBlackCheckers == 0;
        }

        public override bool IsLegalPlayerFinalMove(Board gameBoard, int fromIndex, int toIndex, int cubeNumber)
        {
            return fromIndex - toIndex == cubeNumber &&
                   (gameBoard.Triangles[toIndex].CheckersColor == null || gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Black);
        }

        public override bool IsLegalPlayerFinalMoveEat(Board gameBoard, int fromIndex, int toIndex, int cubeNumber)
        {
            return fromIndex - toIndex == cubeNumber &&
                   gameBoard.Triangles[toIndex].CheckersColor == CheckerColor.Red &&
                   gameBoard.Triangles[toIndex].NumOfCheckers == 1;
        }

        public override bool IsLegalPlayerBearOffMove(int fromIndex, int cubeNumber)
        {
            return fromIndex - cubeNumber <= -1;
        }

        public override bool CanBearOffCheckers(Board gameBoard)
        {
            int numOfCheckersOutsideHome = gameBoard.GameBar.NumOfBlackCheckers;

            for (int i = 6; i <= 23; i++)
            {
                if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Black)
                {
                    numOfCheckersOutsideHome += gameBoard.Triangles[i].NumOfCheckers;
                }
            }

            return numOfCheckersOutsideHome == 0;
        }

        public override void UpdateCheckersAtHome(Board gameBoard)
        {
            CheckersAtHome = 0;

            for (int i = 0; i <= 5; i++)
            {
                if (gameBoard.Triangles[i].CheckersColor == CheckerColor.Black)
                {
                    CheckersAtHome += gameBoard.Triangles[i].NumOfCheckers;
                }
            }
        }

        private void AddMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves, int fromIndex, int toIndex)
        {
            if (toIndex >= 0 && diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex) && IsLegalPlayerFinalMove(gameBoard, fromIndex, toIndex, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(fromIndex, toIndex));
            }
        }

        private void AddMoveFromBarIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves)
        {
            if (diceValue != 0 && IsLegalPlayerFinalMove(gameBoard, 24, 24 - diceValue, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(24, 24 - diceValue));
            }
        }

        private void AddEatMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMovesEat, int fromIndex, int toIndex)
        {
            if (toIndex >= 0 && diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex) && IsLegalPlayerFinalMoveEat(gameBoard, fromIndex, toIndex, diceValue))
            {
                availableMovesEat.Add(new KeyValuePair<int, int>(fromIndex, toIndex));
            }
        }

        private void AddEatMoveFromBarIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMovesEat)
        {
            if (diceValue != 0 && IsLegalPlayerFinalMoveEat(gameBoard, 24, 24 - diceValue, diceValue))
            {
                availableMovesEat.Add(new KeyValuePair<int, int>(24, 24 - diceValue));
            }
        }

        private void AddBearOffMoveIfValid(Board gameBoard, int diceValue, List<KeyValuePair<int, int>> availableMoves, int fromIndex)
        {
            if (diceValue != 0 && IsLegalPlayerInitialMove(gameBoard, fromIndex) && IsLegalPlayerBearOffMove(fromIndex, diceValue))
            {
                availableMoves.Add(new KeyValuePair<int, int>(fromIndex, diceValue));
            }
        }
    }
}