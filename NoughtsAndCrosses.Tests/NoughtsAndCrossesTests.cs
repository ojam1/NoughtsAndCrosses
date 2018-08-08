using NUnit.Framework;
using NSubstitute;

namespace NoughtsAndCrosses.Tests
{
    public class NoughtsAndCrossesTests
    {
        [Test]
        public void Outputs_quick_game()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt", "Olly", "a", "d", "b", "e", "c");

            new Game(writer).Start();
            
            writer.Received(16).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("+---+---+---+\n| a | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | X |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine($"Winner {_playerOne}!");
        }
    }
}