using NUnit.Framework;
using NSubstitute;

namespace NoughtsAndCrosses.Tests
{
    public class NoughtsAndCrossesTests
    {
        private string _playerOne = "Player One";
        private string _playerTwo = "Player Two";

        [Test]
        public void Outputs_quick_game()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns(_playerOne, _playerTwo, "a", "d", "b", "e", "c");

            new Game(writer).Start();
            
            writer.Received(16).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine($"Hello {_playerOne}");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine($"Hello {_playerTwo}");
            writer.Received().WriteLine("+---+---+---+\n| a | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"{_playerOne}, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"{_playerTwo}, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"{_playerOne}, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"{_playerTwo}, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"{_playerOne}, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | X |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"Winner {_playerOne}!");
        }
    }
}