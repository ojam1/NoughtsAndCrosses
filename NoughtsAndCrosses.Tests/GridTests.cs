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

            Assert.That(_grid.GridLocations["a"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_B()
        {
            _grid.SetNoughtOrCross("b", PlayerTwo);

            Assert.That(_grid.GridLocations["b"], Is.EqualTo("O"));
        }

        [Test]
        public void Should_set_grid_postion_C()
        {
            _grid.SetNoughtOrCross("c", PlayerOne);

            Assert.That(_grid.GridLocations["c"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_D()
        {
            _grid.SetNoughtOrCross("d", PlayerOne);

            Assert.That(_grid.GridLocations["d"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_E()
        {
            _grid.SetNoughtOrCross("e", PlayerOne);

            Assert.That(_grid.GridLocations["e"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_F()
        {
            _grid.SetNoughtOrCross("f", PlayerOne);

            Assert.That(_grid.GridLocations["f"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_G()
        {
            _grid.SetNoughtOrCross("g", PlayerOne);

            Assert.That(_grid.GridLocations["g"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_H()
        {
            _grid.SetNoughtOrCross("h", PlayerOne);

            Assert.That(_grid.GridLocations["h"], Is.EqualTo("X"));
        }

        [Test]
        public void Should_set_grid_postion_I()
        {
            _grid.SetNoughtOrCross("i", PlayerOne);

            Assert.That(_grid.GridLocations["i"], Is.EqualTo("X"));
        }
    }
}
