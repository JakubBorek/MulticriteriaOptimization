using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Visualization
{
    public static class SuperiorityMatrixVisualizationExtension
    {
        public static void Visualize(this bool[,] matrix)
        {
            Application app = new Application();
            app.Run(new SuperiorityMatrixViewer(matrix));
        }
    }
}
