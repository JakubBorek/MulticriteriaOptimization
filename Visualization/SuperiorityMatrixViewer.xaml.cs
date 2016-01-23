using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Visualization
{
    /// <summary>
    /// Interaction logic for SuperiorityMatrixViewer.xaml
    /// </summary>
    public partial class SuperiorityMatrixViewer : Window
    {
        public IBidirectionalGraph<object, IEdge<object>> GraphToVisualize { get; private set; }
        public SuperiorityMatrixViewer(bool[,] superiorityMatrix)
        {
            CreateGraphToVisualize(superiorityMatrix);
            InitializeComponent();
        }

        private void CreateGraphToVisualize(bool[,] superiorityMatrix)
        {
            var g = new BidirectionalGraph<object, IEdge<object>>();
            int size = superiorityMatrix.GetLength(0);

            string[] vertices = new string[size];
            for (int i = 0; i < size; i++)
            {
                vertices[i] = i.ToString();
                g.AddVertex(vertices[i]);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j && superiorityMatrix[i, j])
                    {
                        g.AddEdge(new Edge<object>(vertices[i], vertices[j]));
                    }
                }
            }

            GraphToVisualize = g;
        }
    }
}
