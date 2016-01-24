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
        public string Name { get; }
        public Alternative(string name, IEnumerable<double> values)
        {
            this.Name = name;
            this.values = new List<double>(values);
        }
    }
}
