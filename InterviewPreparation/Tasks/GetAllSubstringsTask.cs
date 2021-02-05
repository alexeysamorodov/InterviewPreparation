using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Tasks
{
    public class GetAllSubstringsTask
    {
        public static HashSet<string> GetAllSubstrings(string source)
        {
            var allSubstrings = new List<string>();
            for (var i = 1; i <= source.Length; i++)
            {
                allSubstrings.AddRange(GetAllSubstringsWithLength(source, i));
            }

            return allSubstrings.ToHashSet();
        }

        public static IEnumerable<string> GetAllSubstringsWithLength(string source, int length)
        {
            for (var i = 0; i + length <= source.Length; i++)
            {
                yield return source.Substring(i, length);
            }
        }
    }

}
