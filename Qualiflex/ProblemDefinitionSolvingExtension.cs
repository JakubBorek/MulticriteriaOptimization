using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualiflex
{
    public static class ProblemDefinitionSolvingExtension
    {
        public static IReadOnlyList<Alternative> SolveWithQualiflex(this ProblemDefinition problemDefinition)
        {
            var solver = new Solver(problemDefinition);
            return solver.Solve();
        }
    }
}
