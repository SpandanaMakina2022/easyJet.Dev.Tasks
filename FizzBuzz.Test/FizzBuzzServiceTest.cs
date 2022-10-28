using FizzBuzz.Service;
using Moq; //there was no necessity to use mock data as this is simple single function
using NUnit.Framework;

namespace FizzBuzz.Test
{
    public class FizzBuzzServiceTest
    {
        public FizzBuzzGame FizzBuzzClient { get; set; }

        [SetUp]
        public void Setup()
        {
            FizzBuzzClient = new FizzBuzzGame();
        }

        [Test]
        public void FizzBuzzTestFor2And5Positive()
        {
            int start = 2, end = 5;

            string[] returnValues = FizzBuzzClient.Run(start, end);

            //Assertions
            int actualLength = (end - start) + 1;
            Assert.AreEqual(returnValues.Length, actualLength);
            Assert.AreEqual(returnValues[1], "Fizz");
            Assert.AreEqual(returnValues[actualLength - 1], "Buzz");

        }

        [Test]
        public void FizzBuzzTestWithNegativeValues()
        {
            int start = -5, end = 5;

            string[] returnValues = FizzBuzzClient.Run(start, end);

            //Assertions
            int actualLength = (end - start) + 1;
            Assert.AreEqual(returnValues.Length, actualLength);
            Assert.AreEqual(returnValues[2], "Fizz");
            Assert.AreEqual(returnValues[actualLength - 1], "Buzz");
            Assert.AreEqual(returnValues[5], "FizzBuzz");
        }

        [Test]
        public void FizzBuzzNegativeTestCase()
        {
            int start = 6, end = 4; //start > end

            string[] returnValues = FizzBuzzClient.Run(start, end);

            //Assertions
            Assert.AreEqual(returnValues, null);

        }
    }
}