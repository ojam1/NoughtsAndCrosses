using Moq;
using NUnit.Framework;
using NSubstitute;
using NoughtsAndCrosses;

namespace NoughtsAndCrosses.Tests
{
    public class NoughtsAndCrossesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Outputs_player_one_name()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt");

            new Game(writer).Start();
            
            writer.Received(2).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter player 1 name:");
            writer.Received().WriteLine("Hello Matt");
        }
    }
}