using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
    class GridTests
    {
        private static Player PlayerOne => new Player("Player One", "X");
        private static Player PlayerTwo => new Player("Player Two", "O");
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
        }

        [Test]
        public void Should_set_grid_postion_A()
        {
            _grid.SetNoughtOrCross("a", PlayerOne);

            Assert.That(_grid.GridLocations[0, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_B()
        {
            _grid.SetNoughtOrCross("b", PlayerTwo);

            Assert.That(_grid.GridLocations[0, 1], Is.EqualTo("O"));
        }

        [Test]
        public void Should_set_grid_postion_C()
        {
            _grid.SetNoughtOrCross("c", PlayerOne);

            Assert.That(_grid.GridLocations[0, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_D()
        {
            _grid.SetNoughtOrCross("d", PlayerOne);

            Assert.That(_grid.GridLocations[1, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_E()
        {
            _grid.SetNoughtOrCross("e", PlayerOne);

            Assert.That(_grid.GridLocations[1, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_F()
        {
            _grid.SetNoughtOrCross("f", PlayerOne);

            Assert.That(_grid.GridLocations[1, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_G()
        {
            _grid.SetNoughtOrCross("g", PlayerOne);

            Assert.That(_grid.GridLocations[2, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_H()
        {
            _grid.SetNoughtOrCross("h", PlayerOne);

            Assert.That(_grid.GridLocations[2, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_I()
        {
            _grid.SetNoughtOrCross("i", PlayerOne);

            Assert.That(_grid.GridLocations[2, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_is_full_without_a_win_condition()
        {
            _grid.SetNoughtOrCross("a", PlayerOne);
            _grid.SetNoughtOrCross("b", PlayerTwo);
            _grid.SetNoughtOrCross("c", PlayerOne);
            _grid.SetNoughtOrCross("d", PlayerTwo);
            _grid.SetNoughtOrCross("e", PlayerOne);
            _grid.SetNoughtOrCross("f", PlayerOne);
            _grid.SetNoughtOrCross("g", PlayerTwo);
            _grid.SetNoughtOrCross("h", PlayerOne);
            _grid.SetNoughtOrCross("i", PlayerTwo);

            Assert.That(_grid.IsFull ,Is.EqualTo(true));
        }

        [TestCase("a", "b", "c")]
        [TestCase("d", "e", "f")]
        [TestCase("g", "h", "i")]
        public void Should_be_win_condition_on_all_rows(string firstRowPosition, string secondRowPosition, string thirdRowPosition)
        {
            _grid.SetNoughtOrCross(firstRowPosition, PlayerOne);
            _grid.SetNoughtOrCross(secondRowPosition, PlayerOne);
            _grid.SetNoughtOrCross(thirdRowPosition, PlayerOne);

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("a", "d", "g")]
        [TestCase("b", "e", "h")]
        [TestCase("c", "f", "i")]
        public void Should_be_win_condition_on_all_columns(string firstColumnPosition, string secondColumnPosition, string thirdColumnPosition)
        {
            _grid.SetNoughtOrCross(firstColumnPosition, PlayerOne);
            _grid.SetNoughtOrCross(secondColumnPosition, PlayerOne);
            _grid.SetNoughtOrCross(thirdColumnPosition, PlayerOne);

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("a", "e", "i")]
        [TestCase("g", "e", "c")]
        public void Should_be_win_condition_on_all_diagonals(string firstDiagonalPosition, string secondDiagonalPosition, string thirdDiagonalPosition)
        {
            _grid.SetNoughtOrCross(firstDiagonalPosition, PlayerOne);
            _grid.SetNoughtOrCross(secondDiagonalPosition, PlayerOne);
            _grid.SetNoughtOrCross(thirdDiagonalPosition, PlayerOne);

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }
    }
}
