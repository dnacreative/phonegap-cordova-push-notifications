using System;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PushSDK.Classes;

namespace PushSDK
{
    internal class RegistrationService
    {
        private RegistrationRequest _request;

        public event EventHandler SuccessefulyRegistered;
        public event EventHandler SuccessefulyUnregistered;

        public event CustomEventHandler<string>  RegisterError;
        public event CustomEventHandler<string> UnregisterError;

        public void Register(string appID, Uri pushUri)
        {
            Debug.WriteLine("/********************************************************/");
            Debug.WriteLine("Register");

            _request.AppID = appID;
            _request.PushToken = pushUri;

            SendRequest(Constants.RegisterUrl, SuccessefulyRegistered, RegisterError);
        }

        public void Unregister()
        {
            Debug.WriteLine("/********************************************************/");
            Debug.WriteLine("Unregister");

            SendRequest(Constants.UnregisterUrl, SuccessefulyUnregistered, UnregisterError);
        }

        private void SendRequest(Uri url, EventHandler successEvent, CustomEventHandler<string> errorEvent)
        {
            var webClient = new WebClient();
            webClient.UploadStringCompleted += (sender, args) =>
                                                   {
                                                       string errorMessage = String.Empty;

                                                       if (args.Error != null)
                                                           errorMessage = args.Error.Message;
                                                       else
                                                       {
                                                           Debug.WriteLine("Response: " + args.Result);

                                                           JObject jRoot = JObject.Parse(args.Result);
                                                           int code = JsonHelpers.GetStatusCode(jRoot);
                                                           if (code == 200 || code == 103)
                                                           {
                                                               if (successEvent != null)
                                                               {
                                                                   successEvent(this, null);
                                                               }
                                                           }
                                                           else
                                                               errorMessage = JsonHelpers.GetStatusMessage(jRoot);
                                                       }

                                                       if (!String.IsNullOrEmpty(errorMessage) && errorEvent != null)
                                                       {
                                                           Debug.WriteLine("Error: " + errorMessage);
                                                           errorEvent(this, new CustomEventArgs<string> {Result = errorMessage});
                                                       }
                                                   };

            string request = String.Format("{{ \"request\":{0}}}", JsonConvert.SerializeObject(_request));
            Debug.WriteLine("Sending request: " + request);

            webClient.UploadStringAsync(url, request);
        }
    }
}