using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.SafariServices;

namespace ReadingList
{
	public partial class ReadingListViewController : UIViewController
	{
		private UILabel labTitle;
		private UITextField txfURL;
		private UIButton btnAddURL;

		public ReadingListViewController () : base ("ReadingListViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.View.BackgroundColor = UIColor.White;

			labTitle = new UILabel () {
				Frame = new RectangleF(0, 20, 400, 20),
				Text = "URL:"
			};
			txfURL = new UITextField () {
				Frame = new RectangleF(0, 40, 400, 20),
			};

			btnAddURL = new UIButton (UIButtonType.System) {
				Frame = new RectangleF(0, 60, 400, 20),
			};
			btnAddURL.SetTitle ("Add URL to reading list", UIControlState.Normal);
			btnAddURL.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			NSError error = null;
			btnAddURL.TouchUpInside += delegate(object sender, EventArgs e) {
				NSUrl url = NSUrl.FromString(txfURL.Text);
				SSReadingList.DefaultReadingList.Add(url,"Title","PrevieText",out error);
			};

			Add(labTitle);
			Add(txfURL);
			Add(btnAddURL);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

