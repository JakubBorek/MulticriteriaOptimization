using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon.DataSources
{
    public interface IAlternativesSource
    {
        IReadOnlyList<Alternative> ReadAlternatives();
    }
}
