using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon
{
    public static class ParametersEnumerator
    {
        public static IEnumerable<Tuple<double, double, ParameterProperties>> Enumerate(Alternative first, Alternative second, IReadOnlyList<ParameterProperties> parameters)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                yield return Tuple.Create(first.Values[i], second.Values[i], parameters[i]);
            }
        }
    }
}
