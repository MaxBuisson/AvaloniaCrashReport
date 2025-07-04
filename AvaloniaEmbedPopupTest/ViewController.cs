using System;
using System.Diagnostics;
using System.Net.Quic;
using System.Threading;
using System.Threading.Tasks;
using AppKit;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using Avalonia.VisualTree;
using CoreGraphics;
using Foundation;

namespace AvaloniaEmbedPopupTest
{
	public partial class ViewController : NSViewController
	{
		
		private readonly EmbeddedAvaloniaView avaloniaUIView = new EmbeddedAvaloniaView();

		private UserControl1 avaloniaView;

		
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			if (this.avaloniaUIView.AvnView != null)
			{
				this.avaloniaView = new UserControl1();
				this.avaloniaUIView.Content = this.avaloniaView;

				this.View.AddSubview(this.avaloniaUIView.AvnView);

				this.avaloniaUIView.AvnView.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);
				
				this.avaloniaUIView.AvnView.AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
				this.avaloniaUIView.Start();
			}
		}
		
		
		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}
	}
}
