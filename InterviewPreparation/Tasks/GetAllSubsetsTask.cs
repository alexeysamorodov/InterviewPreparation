using System.Collections.Generic;
using System.Linq;

namespace InterviewPreparation.Tasks
{
    public class GetAllSubsetsTask
    {
        public static IEnumerable<IEnumerable<T>> GetAllSubsets<T>(T[] sourceSet)
        {
            var numberBinaryRepresentation = new bool[sourceSet.Length];
            for (var i = 0; i < numberBinaryRepresentation.Length; i++)
            {
                numberBinaryRepresentation[i] = false;
            }

            while (!numberBinaryRepresentation.All(x => x))
            {
                AddOneToBinaryNumber(numberBinaryRepresentation);
                yield return GetSubsetByMask(sourceSet, numberBinaryRepresentation);
            }
        }

        public static IEnumerable<T> GetSubsetByMask<T>(T[] sourceSet, bool[] mask)
        {
            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i])
                    yield return sourceSet[i];
            }
        }

        public static void AddOneToBinaryNumber(bool[] binaryNumber)
        {
            var overflow = true;
            for (var i = binaryNumber.Length - 1; i >= 0; i--)
            {
                var sourceValue = binaryNumber[i];
                binaryNumber[i] ^= overflow;
                overflow = overflow && sourceValue;
            }
        }
    }
}
