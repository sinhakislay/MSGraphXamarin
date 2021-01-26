# MSGraphXamarin
Refer to video https://www.youtube.com/watch?v=9opLnX4G9EQ&feature=youtu.be
In this video I explain how to call Microsoft Graph from Xamarin mobile app.

Following topics are covered
Demo of the App that is getting user's email address, photo and calendar entries
Prerequisties
Code structure
Code overview

I give  a demo of the App I have created abd the discuss the Prerequisties to start the development.
Then I cover howto authenticate to Azure AD and call Microsoft  Graph from Xamarin Mobile App.
Then I give  a detailed description of UI elements and how to implement logic to get details from Microsofr Graph for logged in user's email, calendar and how to add an event in the calendar as well.


Packages to be installed
Install-Package Microsoft.Identity.Client -Version 4.24.0 -Project MSGraphXamarin
Install-Package Microsoft.Identity.Client -Version 4.24.0 -Project MSGraphXamarin.Android
Install-Package Microsoft.Identity.Client -Version 4.24.0 -Project MSGraphXamarin.iOS
Install-Package Microsoft.Graph -Version 3.21.0 -Project MSGraphXamarin
Install-Package TimeZoneConverter -Version 3.3.0 -MSGraphXamarin
