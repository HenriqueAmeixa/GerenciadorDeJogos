using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.MauiMTAdmob;

namespace PlayMatch.Front
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CrossMauiMTAdmob.Current.Init(
                activity: this,
                appId: "ca-app-pub-9624517469952283~9221155916",
                testDeviceId: "e82c00e6-e7bc-4825-abc5-c40553119f46",
                forceTesting: true,
                debugMode: true
            );
        }
    }
}