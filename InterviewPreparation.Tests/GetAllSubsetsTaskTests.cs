using System.Linq;
using InterviewPreparation.Tasks;
using NUnit.Framework;

namespace InterviewPreparation.Tests
{
    public class GetAllSubsetsTaskTests
    {
        [Test]
        public void GetAllSubsetsSimpleTest_ShouldReturnAllSubsets()
        {
            var sourceSet = new[] { 1, 2, 3 };
            var allSubsets = GetAllSubsetsTask.GetAllSubsets(sourceSet);
            Assert.That(allSubsets.Count(), Is.EqualTo(7));
        }

        [Test]
        public void GetAllSubstringsSimpleTest_ShouldReturnAllSubstrings()
        {
            var sourceString = "123";
            var allSubstrings = GetAllSubstringsTask.GetAllSubstrings(sourceString);
            Assert.That(allSubstrings.Count, Is.EqualTo(6));
        }
    }
}