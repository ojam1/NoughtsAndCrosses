using NUnit.Framework;
using NSubstitute;

namespace NoughtsAndCrosses.Tests
{
    public class NoughtsAndCrossesTests
    {
        [Test]
        public void Player_one_wins()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "", "Matt", "Olly", "1", "4", "2", "5", "3");

            new Game(writer).Start();
            
            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Winner Matt!");
        }

        [Test]
        public void Player_two_wins()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "", "Matt", "Olly", "3", "1", "7", "5", "2","9");

            new Game(writer).Start();

            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  O ||  2 ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  O ||  2 ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  X ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  O ||  2 ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  X ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  X ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  X ||  8 ||  O |\n------------------");
            writer.Received().WriteLine("Winner Olly!");
        }

        [Test]
        public void Players_input_incorrect_grid_positions()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "", "Matt", "Olly", "zzzz", "1", "1", "4", "2", "5", "3");

            new Game(writer).Start();

            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("Not a valid location");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("Postion already taken");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  O ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Winner Matt!");
        }

        [Test]
        public void Game_with_no_winners()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("3", "", "Matt", "Olly", "1", "2", "3", "4", "5", "7", "6", "9", "8");

            new Game(writer).Start();

            writer.Received().WriteLine("Enter player one name");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Enter player two name");
            writer.Received().WriteLine("Hello Olly");
            writer.Received().WriteLine("------------------\n|  1 ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  2 ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  3 |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  4 ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  5 ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  7 ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  6 |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  8 ||  9 |\n------------------");
            writer.Received().WriteLine("Olly, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  8 ||  O |\n------------------");
            writer.Received().WriteLine("Matt, please enter your move");
            writer.Received().WriteLine("------------------\n|  X ||  O ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  X |\n------------------");
            writer.Received().WriteLine("------------------\n|  O ||  X ||  O |\n------------------");
            writer.Received().WriteLine("No Winner");
        }
    }
}