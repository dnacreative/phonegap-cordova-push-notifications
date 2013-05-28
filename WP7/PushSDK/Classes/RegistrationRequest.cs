using System;
using System.Threading;
using Newtonsoft.Json;

namespace PushSDK.Classes
{
    [JsonObject]
    public struct RegistrationRequest
    {
        [JsonProperty("application")]
        public string AppID { get; set; }

        [JsonProperty("device_type")]
        public int DeviceType
        {
            get { return Constants.DeviceType; }
        }

        [JsonProperty("push_token")]
        public Uri PushToken { get; set; }

        [JsonProperty("language")]
        public string Language
        {
            get { return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName; }
        }


        //Note: to get a result requires ID_CAP_IDENTITY_DEVICE         
        // to be added to the capabilities of the WMAppManifest         
        // this will then warn users in marketplace  
        [JsonProperty("hwid")]
        public string HardwareId
        {
            get { return SDKHelpers.GetDeviceUniqueId(); }
        }

        [JsonProperty("timezone")]
        public double Timezone
        {
            get { return TimeZoneInfo.Local.BaseUtcOffset.TotalSeconds; }
        }
    }
}