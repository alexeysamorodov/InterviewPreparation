using System.Linq;
using InterviewPreparation.Tasks;
using NUnit.Framework;

namespace InterviewPreparation.Tests
{
    [TestFixture]
    public class MergeKSortedListsTests
    {
        [TestCase(new[]{1, 1, 2, 3, 4, 4, 5, 6},
        new []{1, 4, 5}, new[] { 1, 3, 4}, new[] { 2, 6})]
        public void MergeKSortedLists_ShouldMerge(int[] expected, params int[][] sourceArrays)
        {
            var lists = sourceArrays.Select(MergeKSortedLists.CreateLinkedList).ToArray();
            var task = new MergeKSortedLists();
            var actual = task.MergeKLists(lists).ToArray();
            Assert.AreEqual(expected, actual);
        }
    }
}
