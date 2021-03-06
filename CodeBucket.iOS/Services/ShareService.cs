using System;
using CodeBucket.Core.Services;
using Foundation;
using UIKit;
using MvvmCross.Platform;
using MvvmCross.Platform.iOS.Views;

namespace CodeBucket.Services
{
	public class ShareService : IShareService
    {
        private readonly IMvxIosModalHost _modalHost;

		public ShareService()
		{
            _modalHost = Mvx.Resolve<IMvxIosModalHost>();
		}

		public void ShareUrl(string url)
		{
            var item = new NSUrl(new Uri(url).AbsoluteUri);
            var activityItems = new NSObject[] { item };
            UIActivity[] applicationActivities = null;
            var activityController = new UIActivityViewController (activityItems, applicationActivities);


            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
                var window = ((UIApplicationDelegate)UIApplication.SharedApplication.Delegate).Window;

                var pop = new UIPopoverController (activityController);
                pop.PresentFromRect (new CoreGraphics.CGRect (window.RootViewController.View.Frame.Width / 2, window.RootViewController.View.Frame.Height / 2, 0, 0),
                    window.RootViewController.View, UIPopoverArrowDirection.Any, true);

            } else {
                _modalHost.PresentModalViewController(activityController, true);

            }
		}
    }
}

