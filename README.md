# On My Way To Holiday

## Disclaimer

OnMyWayToHoliday is a 2D-Platformer created as a university project for the subject "Entwicklung mobiler Applikationen".

## How to play/build:

### Windows

Download the Win_x64.zip file of the current release and just start the Application with the .exe-file

### Android

Download the Android.zip file of the current release and install the Application on your Android device with the .apk-file

### iOS

The App is currently only available on iOS-devices with enabled Developer-Mode. Also you'll need a macOS device to build the App with XCode.

How to build:

1. Download the iOS.zip file of the current release on a macOS-device
2. Open the Unity-iPhone.xcodeproj-file with XCode
3. Connect your iOS-device to your macOS-device via cable.
   1. Trust the macOS-device on your iOS-device when prompted
   2. On your iOS-device, go to Settings > Privacy & Securty
   3. Scroll all the way down to developer mode and toggle it on
   4. Restart your phone as prompted
   5. After restart, make sure to activate Developer Mode when prompted
4. On your macOS-device, choose your connected iOS-device in the device list in XCode
5. Build the application

### Unity

Clone this repository and open it with Unity. We recommend Unity Editor-Version 2021.3.12f1.
The project won't compile on first start.
To be able to compile the game do the following:

1. Create a new Script called config.cs under Assets > Scripts.
2. Copy all content of the config.cs.example-file and paste it into the config.cs-file
3. Go to https://globalstats.io/ and Sign up for a new account
4. LogIn to your account
5. Click on your name in the top right and then go to Profile > My Games
6. Register a new game and name it just like you want
7. (You may need to wait a few minutes at this point, as the site can be somewhat slow at some times)
8. Click on details on your just created game
9. In "GTD's - Globalstats Tracked Data" click Add a new GTD
   1. Set "score" as key
   2. Set Name and Short Name as you like. (eg. Name: "Score", Short Name: "Scr")
   3. Set Type as Numeric
   4. Set Sorting to Larger is better
   5. Hit create
10.   Copy the ID and the Secret of the automatically generated Access Token and add them into the config.cs-file
11.   Now you can start to build and modify the game as you like.
