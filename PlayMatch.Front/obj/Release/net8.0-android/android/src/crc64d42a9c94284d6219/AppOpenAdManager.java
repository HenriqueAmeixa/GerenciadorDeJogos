package crc64d42a9c94284d6219;


public class AppOpenAdManager
	extends com.google.android.gms.ads.appopen.AppOpenAd.AppOpenAdLoadCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoaded:(Lcom/google/android/gms/ads/appopen/AppOpenAd;)V:GetOnAdLoadedHandler\n" +
			"n_onAdFailedToLoad:(Lcom/google/android/gms/ads/LoadAdError;)V:GetOnAdFailedToLoad_Lcom_google_android_gms_ads_LoadAdError_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.AppOpenAdManager, Plugin.MauiMtAdmob", AppOpenAdManager.class, __md_methods);
	}


	public AppOpenAdManager ()
	{
		super ();
		if (getClass () == AppOpenAdManager.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AppOpenAdManager, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public AppOpenAdManager (crc6488302ad6e9e4df1a.MauiAppCompatActivity p0, crc6424817b6e85a95e78.MauiMTAdmob p1, java.lang.String p2)
	{
		super ();
		if (getClass () == AppOpenAdManager.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AppOpenAdManager, Plugin.MauiMtAdmob", "Microsoft.Maui.MauiAppCompatActivity, Microsoft.Maui:Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public void onAdLoaded (com.google.android.gms.ads.appopen.AppOpenAd p0)
	{
		n_onAdLoaded (p0);
	}

	private native void n_onAdLoaded (com.google.android.gms.ads.appopen.AppOpenAd p0);


	public void onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
