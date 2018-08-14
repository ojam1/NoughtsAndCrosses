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
            writer.Received().WriteLine("Winner Matt!");
        }

        [Test]
        public void Player_two_wins()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt", "Olly", "c", "a", "g", "e", "b","i");

            new Game(writer).Start();

            writer.Received(18).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("+---+---+---+\n| a | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| a | b | X |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| O | b | X |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| O | b | X |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| X | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| O | b | X |\n+---+---+---+\n| d | O | f |\n+---+---+---+\n| X | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| O | X | X |\n+---+---+---+\n| d | O | f |\n+---+---+---+\n| X | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| O | X | X |\n+---+---+---+\n| d | O | f |\n+---+---+---+\n| X | h | O |\n+---+---+---+");
            writer.Received().WriteLine("Winner Olly!");
        }

        [Test]
        public void Players_input_incorrect_grid_positions()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt", "Olly", "zzzz", "a", "a", "d", "b", "e", "c");

            new Game(writer).Start();

            writer.Received(22).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("+---+---+---+\n| a | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("Not a valid location");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("Postion already taken");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | c |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | X | X |\n+---+---+---+\n| O | O | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Winner Matt!");
        }

        [Test]
        public void Game_with_no_winners()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt", "Olly", "a", "b", "c", "d", "e", "g", "f", "i", "h");

            new Game(writer).Start();

            writer.Received(24).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("+---+---+---+\n| a | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | b | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | c |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| d | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | e | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | X | f |\n+---+---+---+\n| g | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | X | f |\n+---+---+---+\n| O | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | X | X |\n+---+---+---+\n| O | h | i |\n+---+---+---+");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | X | X |\n+---+---+---+\n| O | h | O |\n+---+---+---+");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("+---+---+---+\n| X | O | X |\n+---+---+---+\n| O | X | X |\n+---+---+---+\n| O | X | O |\n+---+---+---+");
            writer.Received().WriteLine("No Winner");
        }
    }
}