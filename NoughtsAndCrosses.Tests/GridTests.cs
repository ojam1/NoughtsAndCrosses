using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
    class GridTests
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
        }

        [Test]
        public void Should_set_grid_postion_A()
        {
            _grid.SetNoughtOrCross("a", "X");

            Assert.That(_grid.GridLocations[0, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_B()
        {
            _grid.SetNoughtOrCross("b", "O");

            Assert.That(_grid.GridLocations[0, 1], Is.EqualTo("O"));
        }

        [Test]
        public void Should_set_grid_postion_C()
        {
            _grid.SetNoughtOrCross("c", "X");

            Assert.That(_grid.GridLocations[0, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_D()
        {
            _grid.SetNoughtOrCross("d", "X");

            Assert.That(_grid.GridLocations[1, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_E()
        {
            _grid.SetNoughtOrCross("e", "X");

            Assert.That(_grid.GridLocations[1, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_F()
        {
            _grid.SetNoughtOrCross("f", "X");

            Assert.That(_grid.GridLocations[1, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_G()
        {
            _grid.SetNoughtOrCross("g", "X");

            Assert.That(_grid.GridLocations[2, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_H()
        {
            _grid.SetNoughtOrCross("h", "X");

            Assert.That(_grid.GridLocations[2, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_I()
        {
            _grid.SetNoughtOrCross("i", "X");

            Assert.That(_grid.GridLocations[2, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_is_full_without_a_win_condition()
        {
            _grid.SetNoughtOrCross("a", "X");
            _grid.SetNoughtOrCross("b", "O");
            _grid.SetNoughtOrCross("c", "X");
            _grid.SetNoughtOrCross("d", "O");
            _grid.SetNoughtOrCross("e", "X");
            _grid.SetNoughtOrCross("f", "X");
            _grid.SetNoughtOrCross("g", "O");
            _grid.SetNoughtOrCross("h", "X");
            _grid.SetNoughtOrCross("i", "O");

            Assert.That(_grid.IsFull ,Is.EqualTo(true));
        }

        [TestCase("a", "b", "c")]
        [TestCase("d", "e", "f")]
        [TestCase("g", "h", "i")]
        public void Should_be_win_condition_on_all_rows(string firstRowPosition, string secondRowPosition, string thirdRowPosition)
        {
            _grid.SetNoughtOrCross(firstRowPosition, "X");
            _grid.SetNoughtOrCross(secondRowPosition, "X");
            _grid.SetNoughtOrCross(thirdRowPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("a", "d", "g")]
        [TestCase("b", "e", "h")]
        [TestCase("c", "f", "i")]
        public void Should_be_win_condition_on_all_columns(string firstColumnPosition, string secondColumnPosition, string thirdColumnPosition)
        {
            _grid.SetNoughtOrCross(firstColumnPosition, "X");
            _grid.SetNoughtOrCross(secondColumnPosition, "X");
            _grid.SetNoughtOrCross(thirdColumnPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("a", "e", "i")]
        [TestCase("g", "e", "c")]
        public void Should_be_win_condition_on_all_diagonals(string firstDiagonalPosition, string secondDiagonalPosition, string thirdDiagonalPosition)
        {
            _grid.SetNoughtOrCross(firstDiagonalPosition, "X");
            _grid.SetNoughtOrCross(secondDiagonalPosition, "X");
            _grid.SetNoughtOrCross(thirdDiagonalPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }
    }
}
