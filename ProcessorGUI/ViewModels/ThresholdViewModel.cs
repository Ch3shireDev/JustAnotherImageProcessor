using System;
using System.Globalization;
using ReactiveUI;

namespace ProcessorGUI.ViewModels;

public class ThresholdViewModel : ViewModelBase
{
    public event EventHandler ThresholdChanged;

    private double threshold = 128;

    public string ValueStr
    {
        get => Threshold.ToString(CultureInfo.InvariantCulture);
        set => SetThreshold(value);
    }

    public double Threshold
    {
        get => threshold;
        set => SetThreshold(value);
    }

    public double MinValue { get; } = 0;
    public double MaxValue { get; } = 255;

    private void SetThreshold(string valueStr)
    {
        if (!double.TryParse(valueStr, out var value)) return;
        value = Math.Floor(value);
        if (value >= MinValue && value <= MaxValue) threshold = value;
        this.RaisePropertyChanged(nameof(Threshold));
        Refresh();
    }

    private void SetThreshold(double value)
    {
        value = Math.Floor(value);
        if (value >= MinValue && value <= MaxValue) threshold = value;
        this.RaisePropertyChanged(nameof(ValueStr));
        Refresh();
    }

    public void Refresh()
    {
        ThresholdChanged.Invoke(this, EventArgs.Empty);
    }
}