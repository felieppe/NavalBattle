using NUnit.Framework;

namespace BattleShip.Tests
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void DisplayBoard_WhenCalled_PrintsBoard()
        {
            var boardSize = new BoardSize(5, 5);
            var gameLogic = new GameLogic(boardSize, 3);

            gameLogic.DisplayBoard();
        }

        [Test]
        public void VerifyAttack_WithShip_ReturnsTrue()
        {
            var boardSize = new BoardSize(5, 5);
            var gameLogic = new GameLogic(boardSize, 3);
            var row = 1;
            var column = 2;
            gameLogic.PlaceShip(row, column);

            var result = gameLogic.VerifyAttack(row, column);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyAttack_WithoutShip_ReturnsFalse()
        {
            var boardSize = new BoardSize(5, 5);
            var gameLogic = new GameLogic(boardSize, 3);
            var row = 1;
            var column = 2;

            var result = gameLogic.VerifyAttack(row, column);
            
            Assert.IsFalse(result);
        }
    }
}