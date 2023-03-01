namespace FizzBuzz.Twisted.Test
{
    public class TwistedFizzBuzzTests
    {
        private ITwistedFizzBuzz twisted;

        [SetUp]
        public void Setup()
        {
            twisted = new TwistedFizzBuzz();
        }

        [Test]
        public void Solve_CalledWithAnUpperAndLowerBound_ReturnsStandardFizzBuzzForTheRange()
        {
            // Arrange
            // Act
            var result = twisted.Solve(1, 16);
            var resultLines = result.Split("\r\n");

            // Assert
            Assert.That(resultLines[1], Is.EqualTo("2"));
            Assert.That(resultLines[2], Is.EqualTo("Fizz"));
            Assert.That(resultLines[4], Is.EqualTo("Buzz"));
            Assert.That(resultLines[14], Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void Solve_CalledWithCustomTokensAndAnUpperAndLowerBound_ReturnsCorrectTokensForTheRange()
        {
            // Arrange
            var tokens = new Dictionary<int, string>
            {
                { 3, "Buzz" },
                { 5, "Fizz" }
            };

            // Act
            var result = twisted.Solve(tokens, 1, 16);
            var resultLines = result.Split("\r\n");

            // Assert
            Assert.That(resultLines[1], Is.EqualTo("2"));
            Assert.That(resultLines[2], Is.EqualTo("Buzz"));
            Assert.That(resultLines[4], Is.EqualTo("Fizz"));
            Assert.That(resultLines[14], Is.EqualTo("BuzzFizz"));
        }

        [Test]
        public void Solve_CalledWithCustomNonSequentialNumberSet_ReturnsStandardFizzBuzzForTheSet()
        {
            // Arrange
            var numberSet = new[]
            {
                -5, 
                6, 
                300, 
                12, 
                15
            };

            // Act
            var result = twisted.Solve(numberSet);
            var resultLines = result.Split("\r\n");

            // Assert
            Assert.That(resultLines[0], Is.EqualTo("Buzz"));
            Assert.That(resultLines[1], Is.EqualTo("Fizz"));
            Assert.That(resultLines[2], Is.EqualTo("FizzBuzz"));
            Assert.That(resultLines[3], Is.EqualTo("Fizz"));
            Assert.That(resultLines[4], Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void Solve_CalledWithCustomTokensAndCustomNonSequentialNumberSet_ReturnsCorrectTokensForTheProvidedNumberSet()
        {
            // Arrange
            var tokens = new Dictionary<int, string>
            {
                { 3, "Buzz" },
                { 5, "Fizz" }
            };

            var numberSet = new[]
            {
                -5,
                6,
                300,
                12,
                15
            };

            // Act
            var result = twisted.Solve(tokens, numberSet);
            var resultLines = result.Split("\r\n");

            // Assert
            Assert.That(resultLines[0], Is.EqualTo("Fizz"));
            Assert.That(resultLines[1], Is.EqualTo("Buzz"));
            Assert.That(resultLines[2], Is.EqualTo("BuzzFizz"));
            Assert.That(resultLines[3], Is.EqualTo("Buzz"));
            Assert.That(resultLines[4], Is.EqualTo("BuzzFizz"));
        }

        [Test]
        public void Solve_CalledWithJsonTokenAndUpperAndLowerBound_ReturnsCorrectOutputForGivenToken()
        {
            // Arrange
            var tokenJson = "{\"multiple\":5,\"word\":\"collection\"}";

            // Act
            var result = twisted.Solve(tokenJson, 1, 16);
            var resultLines = result.Split("\r\n");

            // Assert
            Assert.That(resultLines[0], Is.EqualTo("1"));
            Assert.That(resultLines[4], Is.EqualTo("collection"));
            Assert.That(resultLines[9], Is.EqualTo("collection"));
            Assert.That(resultLines[11], Is.EqualTo("12"));
            Assert.That(resultLines[14], Is.EqualTo("collection"));
        }
    }
}