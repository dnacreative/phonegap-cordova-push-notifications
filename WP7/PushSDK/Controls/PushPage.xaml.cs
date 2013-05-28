using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PushSDK.Classes;

namespace PushSDK.Controls
{
    public partial class PushPage
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var applicationService = ((PhonePushApplicationService) PhoneApplicationService.Current);

            applicationService.NotificationService.LastPush = SDKHelpers.ParsePushData(e.Uri.ToString());

            applicationService.NotificationService.FireAcceptedPush();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            
            base.OnNavigatedFrom(e);
        }
    }
}