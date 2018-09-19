using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
    class GridTests
    {
        private Grid _grid;
        private readonly IWriter _iWriter;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(_iWriter, 3);
        }

        [Test]
        public void Should_set_grid_postion_1()
        {
            _grid.SetNoughtOrCross("1", "X");

            Assert.That(_grid.GridLocationsArray[0, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_2()
        {
            _grid.SetNoughtOrCross("2", "O");

            Assert.That(_grid.GridLocationsArray[0, 1], Is.EqualTo("O"));
        }

        [Test]
        public void Should_set_grid_postion_3()
        {
            _grid.SetNoughtOrCross("3", "X");

            Assert.That(_grid.GridLocationsArray[0, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_4()
        {
            _grid.SetNoughtOrCross("4", "X");

            Assert.That(_grid.GridLocationsArray[1, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_5()
        {
            _grid.SetNoughtOrCross("5", "X");

            Assert.That(_grid.GridLocationsArray[1, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_6()
        {
            _grid.SetNoughtOrCross("6", "X");

            Assert.That(_grid.GridLocationsArray[1, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_7()
        {
            _grid.SetNoughtOrCross("7", "X");

            Assert.That(_grid.GridLocationsArray[2, 0], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_8()
        {
            _grid.SetNoughtOrCross("8", "X");

            Assert.That(_grid.GridLocationsArray[2, 1], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_9()
        {
            _grid.SetNoughtOrCross("9", "X");

            Assert.That(_grid.GridLocationsArray[2, 2], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_is_full_without_a_win_condition()
        {
            _grid.SetNoughtOrCross("1", "X");
            _grid.SetNoughtOrCross("2", "O");
            _grid.SetNoughtOrCross("3", "X");
            _grid.SetNoughtOrCross("4", "O");
            _grid.SetNoughtOrCross("5", "X");
            _grid.SetNoughtOrCross("6", "X");
            _grid.SetNoughtOrCross("7", "O");   
            _grid.SetNoughtOrCross("8", "X");
            _grid.SetNoughtOrCross("9", "O");

            Assert.That(_grid.IsFull ,Is.EqualTo(true));
        }

        [TestCase("1", "2", "3")]
        [TestCase("4", "5", "6")]
        [TestCase("7", "8", "9")]
        public void Should_be_win_condition_on_all_rows(string firstRowPosition, string secondRowPosition, string thirdRowPosition)
        {
            _grid.SetNoughtOrCross(firstRowPosition, "X");
            _grid.SetNoughtOrCross(secondRowPosition, "X");
            _grid.SetNoughtOrCross(thirdRowPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("1", "4", "7")]
        [TestCase("2", "5", "8")]
        [TestCase("3", "6", "9")]
        public void Should_be_win_condition_on_all_columns(string firstColumnPosition, string secondColumnPosition, string thirdColumnPosition)
        {
            _grid.SetNoughtOrCross(firstColumnPosition, "X");
            _grid.SetNoughtOrCross(secondColumnPosition, "X");
            _grid.SetNoughtOrCross(thirdColumnPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }

        [TestCase("1", "5", "9")]
        [TestCase("7", "5", "3")]
        public void Should_be_win_condition_on_all_diagonals(string firstDiagonalPosition, string secondDiagonalPosition, string thirdDiagonalPosition)
        {
            _grid.SetNoughtOrCross(firstDiagonalPosition, "X");
            _grid.SetNoughtOrCross(secondDiagonalPosition, "X");
            _grid.SetNoughtOrCross(thirdDiagonalPosition, "X");

            Assert.That(_grid.WinCondition, Is.EqualTo(true));
        }
    }
}
