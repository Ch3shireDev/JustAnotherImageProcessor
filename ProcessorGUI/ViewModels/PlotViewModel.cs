using ReactiveUI;
using ScottPlot;

namespace ProcessorGUI.ViewModels;

public class PlotViewModel : ReactiveObject
{
    public Plot Plot { get; set; }
}