using System.Net;
using Newtonsoft.Json;
using PushSDK.Classes;

namespace PushSDK
{
    internal class StatisticService
    {
        private readonly StatisticRequest _request;
        private readonly WebClient _webClient = new WebClient();

        public StatisticService(string appId)
        {
            _request = new StatisticRequest {AppId = appId};
        }

        public void SendRequest()
        {
            string request = string.Format("{{\"request\":{0}}}", JsonConvert.SerializeObject(_request));
            _webClient.UploadStringAsync(Constants.StatisticUrl, request);
        }
    }
}