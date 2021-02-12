using InterviewPreparation.Tasks;
using NUnit.Framework;

namespace InterviewPreparation.Tests
{
    [TestFixture]
    public class SortingTests
    {
        [TestCase(new[] { 5, 1, 4, 2, 3 }, new[] { 1,2,3,4,5 })]
        public void HoareSort_ShouldSortAndMatchRightExpected(int[] source, int[] expected)
        {
            HoareSort.Sort(source, 0, source.Length - 1);
            Assert.AreEqual(source, expected);
        }

        [TestCase(new[] { 5, 1, 4, 2, 3 }, new[] { 1, 2, 3, 5, 4 })]
        public void HoareSort_ShouldNotMatchWrongSorting(int[] source, int[] expected)
        {
            HoareSort.Sort(source, 0, source.Length - 1);
            Assert.AreNotEqual(source, expected);
        }
    }
}
