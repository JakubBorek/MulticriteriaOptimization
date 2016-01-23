using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon.DataSources
{
    public class CsvReader : IAlternativesSource
    {
        private readonly StreamReader fileReader;
        private readonly char separator;
        private readonly int criteriaCount;
        public CsvReader(string filename, char separator, int criteriaCount)
        {
            fileReader = new StreamReader(filename);
            this.separator = separator;
            this.criteriaCount = criteriaCount;
        }
        public ISet<Alternative> ReadAlternatives()
        {
            var set = new HashSet<Alternative>();
            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                var alternative = alternativeFromLine(line);
                set.Add(alternative);
            }
            return set;
        }

        private Alternative alternativeFromLine(string line)
        {
            var values = splitLine(line).Select(str => Double.Parse(str));
            return new Alternative(values);
        }

        private List<string> splitLine(string line)
        {
            var list = line.Split(separator).ToList();
            list.RemoveAll(str => String.IsNullOrWhiteSpace(str));
            if (list.Count != criteriaCount) { throw new InvalidDataException("Alternative has wrong number of criteria values"); }
            return list;
        }
    }
}
