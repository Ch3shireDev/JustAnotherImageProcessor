using System;
using Avalonia.Controls;
using Avalonia.Input;
using ProcessorGUI.ViewModels;

namespace ProcessorGUI.Views
{
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
        }
        
        private void ActivatedEvent(object? sender, EventArgs e)
        {
            (DataContext as ImageViewModel)?.ActivatedCommand.Execute(null);
        }
    }
}
