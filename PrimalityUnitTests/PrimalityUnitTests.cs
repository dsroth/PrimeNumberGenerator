using NUnit.Framework;
using PrimalityTest;
using System;
using System.Collections.Generic;
using System.IO;


namespace PrimalityUnitTests
{
    public class Tests
    {
        public PrimalityCheck check;

        [SetUp]
        public void Setup()
        {
            check = new PrimalityCheck();
        }

        [Test]
        public void GenerateTest()
        {
            var rangeList = check.Generate(1, 10);
            Console.WriteLine(rangeList);
            Assert.AreEqual(rangeList.Count, 4);
        }

        [Test]
        public void InvertTest()
        {
            var primes = check.Generate(1, 10);
            var inverted_primes = check.Generate(10, 1);
            Assert.AreEqual(primes, inverted_primes);
        }

        [Test]
        public void IsPrimeSpotCheck()
        {
            var primes = check.Generate(7900, 7920);
            Assert.Contains(7901, primes);
            Assert.Contains(7907, primes);
            Assert.Contains(7919, primes);
            Assert.AreEqual(primes.Count, 3);
        }

        [Test]
        public void MainTest()
        {
            var string_writer = new StringWriter();
            Console.SetOut(string_writer);
            var string_reader = new StringReader("1\r\n10\r\n");
            Console.SetIn(string_reader);
            PrimalityCheck.Main();
            Assert.AreEqual(99, string_writer.ToString().Length);
        }

        [Test]
        public void WritePrimesTest()
        {
            var string_writer = new StringWriter();
            Console.SetOut(string_writer);
            var primes = new List<int> { 2, 3, 5 };
            PrimalityCheck.WritePrimes(primes);
            Assert.AreEqual("2\r\n3\r\n5\r\n", string_writer.ToString());
        }

        [Test]
        public void ReadInputTest()
        {
            var string_reader = new StringReader("1");
            Console.SetIn(string_reader);
            Assert.AreEqual(PrimalityCheck.ReadInput(), 1);
        }

        [Test]
        public void ReadNegativeInputTest()
        {
            var string_reader = new StringReader("-1");
            Console.SetIn(string_reader);
            Assert.AreEqual(PrimalityCheck.ReadInput(), 1);
        }
    }
}