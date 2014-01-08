// Cordova iOS Pushwoosh Push Notifications plugin
// (c) Pushwoosh, 2014
// http://www.pushwoosh.com

 Pushwoosh integration Guide for Cordova/Phonegap:
 http://www.pushwoosh.com/programming-push-notification/ios/ios-additional-platforms/push-notification-sdk-integration-for-phonegap/

The plugin is ARC based. The latest Cordova is ARC based as well so you shouldn't have any problem, but if your project is not ARC based (though you really should consider using ARC) set "-fobjc-arc" linker flag for the plugin source files.

For Cordova/Phonegap CLI check out this repo:
https://github.com/shaders/pushwoosh-phonegap-3.0-plugin