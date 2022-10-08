using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ProcessorGUI.ViewModels
{
	public class ImageViewModel : ViewModelBase
	{
        public Bitmap Image { get; set; }
    }
}