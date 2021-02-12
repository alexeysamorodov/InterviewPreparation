using NUnit.Framework;
using InterviewPreparation.Tasks;

namespace InterviewPreparation.Tests
{
    [TestFixture]
    public class RoadsAndLibrariesTaskTests
    {
        [TestCase(3, 2, 1, 4, new[] {1, 2}, new[] {3, 1}, new[] {2, 3})]
        [TestCase(6, 2, 5, 12, 
            new[] {1, 3}, new[] {3, 4}, new[] {2, 4}, new[] {1,2}, new[] {2,3}, new[] {5,6})]
        [TestCase(5, 6, 1, 15, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 1, 4 })]
        public void RoadsAndLibrariesCostMainTest(int n, int c_lib, int c_road, int expected, params int[][] cities)
        {
            var actual = RoadsAndLibrariesTask.roadsAndLibraries(n, c_lib, c_road, cities);
            Assert.AreEqual(expected, actual);
        }
    }
}
