using NUnit.Framework;
using NSubstitute;

namespace NoughtsAndCrosses.Tests
{
    public class NoughtsAndCrossesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Outputs_players_names()
        {
            var writer = Substitute.For<IWriter>();
            writer.ReadLine().Returns("Matt Olly");

            new Game(writer).Start();
            
            writer.Received(3).WriteLine(Arg.Any<string>());
            writer.Received().WriteLine("Enter players names with a space between them");
            writer.Received().WriteLine("Hello Matt");
            writer.Received().WriteLine("Hello Olly");
        }
    }
}