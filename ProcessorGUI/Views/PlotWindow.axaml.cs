using Avalonia.Controls;
using ScottPlot;

namespace ProcessorGUI.Views
{
    public partial class PlotWindow : Window
    {
        public PlotWindow()
        {
            InitializeComponent();
        }

        public Plot Plot
        {
            get => AvaPlot1.Plot;
        }
    }
}
