using System;
using System.Collections.Generic;
using Microsoft.Phone.Shell;

namespace PushSDK
{
    public class PhonePushApplicationService : PhoneApplicationService
    {
        public PhonePushApplicationService()
        {
            TileTrustedServers = new List<string>();

            Activated += (sender, args) => Subscribe();
            Launching += (sender, args) => Subscribe();
        }

        public NotificationService NotificationService
        {
            get
            {
                if (string.IsNullOrEmpty(PWAppId))
                    throw new ArgumentNullException("PWAppId");

                return NotificationService.GetCurrent(PWAppId, PushPage, TileTrustedServers);
            }
        }

        /// <summary>
        /// [Required] Get or set PushWoosh application id
        /// </summary>
        public string PWAppId { get; set; }

        /// <summary>
        /// [Optional] Page on which the navigation is when receiving toast push notification
        /// </summary>
        public string PushPage { get; set; }

        /// <summary>
        /// [Optional] Get or set trusted servers for receive tile notification
        /// </summary>
        public List<string> TileTrustedServers { get; set; }

        /// <summary>
        /// [Optional] The name that the web service uses to associate itself with the Push Notification Service.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// [Default=false] Enable geo zone function for Push Woosh
        /// </summary>
        public bool GeoZones { get; set; }

        private void Subscribe()
        {
            if (ServiceName == null)
                NotificationService.SubscribeToPushService();
            else
                NotificationService.SubscribeToPushService(ServiceName);
        }
    }
}