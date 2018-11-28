using NSubstitute;
using NUnit.Framework;

namespace NoughtsAndCrosses.Tests
{
    public class ComputerPlayerTests
    {
        [Test]
        public void Computer_player_initiated()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "Computer1", "Olly", "1", "4", "2", "5", "3");

            new Game(writer).Start();

            writer.Received().WriteLine("Enter 'Computer1' for computer player one if required");
            writer.Received().WriteLine("Hello ComputerPlayer1");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");

            Assert.That(true);
        }
    }
}