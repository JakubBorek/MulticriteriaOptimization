using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon
{
    public class Alternative
    {
        private List<double> values;
        public IReadOnlyList<double> Values { get { return values; } }
        public Alternative(IEnumerable<double> values)
        {
            this.values = new List<double>(values);
        }
    }
}
