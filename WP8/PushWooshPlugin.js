var PushWooshPlugin = {
    subscribe: function (successCallback, errorCallback) {
        console.log("Subscribe to push notification");
        cordova.exec(successCallback, errorCallback, "PWNotification", "SubscribeToPushNotification");
    },
    unsubscribe: function (errorCallback) {
        console.log("Unsubscribe from push notification");
        cordova.exec(null, errorCallback, "PWNotification", "UnsubscribeFromPushNotification");
    },
    getUserData: function (successCallback, errorCallback) {
        console.log("Getting user data from last push");
        cordova.exec(successCallback, errorCallback, "PWUserData", "GetUserData");
    },
    enableGeozone: function (successCallback, errorCallback) {
        console.log("Start geozone service");
        cordova.exec(successCallback, errorCallback, "PWGeozone", "StartGeozone");
    },
    disableGeozone: function (successCallback, errorCallback) {
        console.log("Stop geozone service");
        cordova.exec(successCallback, errorCallback, "PWGeozone", "StopGeozone");
    },
    sendingTags: function (successCallback, errorCallback, tags) {
        console.log("Sending tags");
        cordova.exec(successCallback, errorCallback, "PWTags", "SendTags", tags);
    },
    userToken: function (successCallback, errorCallback, tags) {
        console.log("Geting user token");
        cordova.exec(successCallback, errorCallback, "PWUserToken", "GetUserToken", tags);
    }
}