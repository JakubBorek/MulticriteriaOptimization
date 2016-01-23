using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreIs
{
    public static class ProblemDefinitionSolvingExtension
    {
        public static bool[,] Solve(this ProblemDefinition problemDefinition)
        {
            var solver = new Solver(problemDefinition);
            return solver.Solve();
        }
    }
}
