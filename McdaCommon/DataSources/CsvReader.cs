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
        public CsvReader(string filename, char separator)
        {
            fileReader = new StreamReader(filename);
            this.separator = separator;
        }
        public IReadOnlyList<Alternative> ReadAlternatives()
        {
            var set = new List<Alternative>();
            string line;
            int counter = 0;
            while ((line = fileReader.ReadLine()) != null)
            {
                string name = "alt" + counter;
                var alternative = alternativeFromLine(name, line);
                throwIfWrongParametrsCount(alternative);
                set.Add(alternative);
                counter++;
            }
            return set;
        }

        private Alternative alternativeFromLine(string name, string line)
        {
            var values = splitLine(line).Select(str => Double.Parse(str));
            return new Alternative(name, values);
        }

        private List<string> splitLine(string line)
        {
            var list = line.Split(separator).ToList();
            list.RemoveAll(str => String.IsNullOrWhiteSpace(str));
            return list;
        }

        private int? parameterCount;
        private void throwIfWrongParametrsCount(Alternative alternative)
        {
            if (parameterCount == null)
            {
                parameterCount = alternative.Values.Count;
            }
            else
            {
                if (parameterCount != alternative.Values.Count)
                {
                    throw new InvalidDataException("Alternative has wrong number of criteria values");
                }
            }
        }
    }
}
