﻿using System.Linq;
using Algorithms.Trees.RangeTree;
using NUnit.Framework;

namespace AlgorithmsTest.TreeTests.RangeTreeTests
{
    [TestFixture]
    public class RangeTreeTests
    {
        [Test]
        public void GettingMin_InnerItems()
        {
            var tree = new RangeTree<int, int>
            {
                { 1, 5, -1 },
                { 2, 5, -1 },
                { 3, 5, -1 },
            };

            var min = tree.Min;

            Assert.That(min, Is.EqualTo(1));
        }

        [Test]
        public void GettingMin_LeftRecurse()
        {
            var tree = new RangeTree<int, int>
            {
                { 1, 2, -1 },
                { 3, 4, -1 }
            };

            var min = tree.Min;

            Assert.That(min, Is.EqualTo(1));
        }

        [Test]
        public void GettingMax_InnerItems()
        {
            var tree = new RangeTree<int, int>
            {
                { 1, 2, -1 },
                { 1, 3, -1 },
                { 1, 4, -1 },
            };

            var max = tree.Max;

            Assert.That(max, Is.EqualTo(4));
        }

        [Test]
        public void GettingMax_RightRecurse()
        {
            var tree = new RangeTree<int, int>
            {
                { 1, 2, -1 },
                { 3, 4, -1 },
                { 5, 6, -1 }
            };

            var max = tree.Max;

            Assert.That(max, Is.EqualTo(6));
        }

        [Test]
        public void Query_CreateTreeAndExecuteQuery_ExpectCorrectElementsToBeReturned()
        {
            var tree = new RangeTree<int, string>()
            {
                { 0, 10, "1" },
                { 20, 30, "2" },
                { 15, 17, "3" },
                { 25, 35, "4" },
            };

            var results1 = tree.Query(5).ToArray();
            Assert.That(results1.Count, Is.EqualTo(1));
            Assert.That(results1[0], Is.EqualTo("1"));

            var results2 = tree.Query(10).ToArray();
            Assert.That(results2.Count, Is.EqualTo(1));
            Assert.That(results2[0], Is.EqualTo("1"));

            var results3 = tree.Query(29).ToArray();
            Assert.That(results3.Count, Is.EqualTo(2));
            Assert.That(results3[0], Is.EqualTo("2"));
            Assert.That(results3[1], Is.EqualTo("4"));

            var results4 = tree.Query(5, 15).ToArray();
            Assert.That(results4.Count, Is.EqualTo(2));
            Assert.That(results4[0], Is.EqualTo("3"));
            Assert.That(results4[1], Is.EqualTo("1"));
        }
    }
}
