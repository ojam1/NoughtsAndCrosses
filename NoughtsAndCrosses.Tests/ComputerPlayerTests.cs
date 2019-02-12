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
        }

        [Test]
        public void Computer_player_goes_in_empty_space()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "Computer1", "Olly", "4", "5");

            new Game(writer).Start();

            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello ComputerPlayer1");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("ComputerPlayer1, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("ComputerPlayer1, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("ComputerPlayer1, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Winner ComputerPlayer1!");
        }
    }
}