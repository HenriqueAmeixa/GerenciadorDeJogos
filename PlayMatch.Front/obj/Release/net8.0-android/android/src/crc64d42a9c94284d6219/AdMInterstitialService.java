package crc64d42a9c94284d6219;


public class AdMInterstitialService
	extends com.google.android.gms.ads.admanager.AdManagerInterstitialAdLoadCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoaded:(Lcom/google/android/gms/ads/admanager/AdManagerInterstitialAd;)V:GetOnAdLoadedHandler\n" +
			"n_onAdFailedToLoad:(Lcom/google/android/gms/ads/LoadAdError;)V:GetOnAdFailedToLoad_Lcom_google_android_gms_ads_LoadAdError_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.AdMInterstitialService, Plugin.MauiMtAdmob", AdMInterstitialService.class, __md_methods);
	}


	public AdMInterstitialService ()
	{
		super ();
		if (getClass () == AdMInterstitialService.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AdMInterstitialService, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public AdMInterstitialService (crc6424817b6e85a95e78.MauiMTAdmob p0)
	{
		super ();
		if (getClass () == AdMInterstitialService.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AdMInterstitialService, Plugin.MauiMtAdmob", "Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob", this, new java.lang.Object[] { p0 });
		}
	}


	public void onAdLoaded (com.google.android.gms.ads.admanager.AdManagerInterstitialAd p0)
	{
		n_onAdLoaded (p0);
	}

	private native void n_onAdLoaded (com.google.android.gms.ads.admanager.AdManagerInterstitialAd p0);


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
