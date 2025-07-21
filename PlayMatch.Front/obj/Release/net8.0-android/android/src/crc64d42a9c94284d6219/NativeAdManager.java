package crc64d42a9c94284d6219;


public class NativeAdManager
	extends com.google.android.gms.ads.AdListener
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.nativead.NativeAd.OnNativeAdLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdClicked:()V:GetOnAdClickedHandler\n" +
			"n_onAdClosed:()V:GetOnAdClosedHandler\n" +
			"n_onAdFailedToLoad:(Lcom/google/android/gms/ads/LoadAdError;)V:GetOnAdFailedToLoad_Lcom_google_android_gms_ads_LoadAdError_Handler\n" +
			"n_onAdImpression:()V:GetOnAdImpressionHandler\n" +
			"n_onAdLoaded:()V:GetOnAdLoadedHandler\n" +
			"n_onAdOpened:()V:GetOnAdOpenedHandler\n" +
			"n_onNativeAdLoaded:(Lcom/google/android/gms/ads/nativead/NativeAd;)V:GetOnNativeAdLoaded_Lcom_google_android_gms_ads_nativead_NativeAd_Handler:Android.Gms.Ads.NativeAd.NativeAd/IOnNativeAdLoadedListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.NativeAdManager, Plugin.MauiMtAdmob", NativeAdManager.class, __md_methods);
	}


	public NativeAdManager ()
	{
		super ();
		if (getClass () == NativeAdManager.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.NativeAdManager, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public NativeAdManager (crc6488302ad6e9e4df1a.MauiAppCompatActivity p0, crc6424817b6e85a95e78.MauiMTAdmob p1, java.lang.String p2)
	{
		super ();
		if (getClass () == NativeAdManager.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.NativeAdManager, Plugin.MauiMtAdmob", "Microsoft.Maui.MauiAppCompatActivity, Microsoft.Maui:Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public void onAdClicked ()
	{
		n_onAdClicked ();
	}

	private native void n_onAdClicked ();


	public void onAdClosed ()
	{
		n_onAdClosed ();
	}

	private native void n_onAdClosed ();


	public void onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0);


	public void onAdImpression ()
	{
		n_onAdImpression ();
	}

	private native void n_onAdImpression ();


	public void onAdLoaded ()
	{
		n_onAdLoaded ();
	}

	private native void n_onAdLoaded ();


	public void onAdOpened ()
	{
		n_onAdOpened ();
	}

	private native void n_onAdOpened ();


	public void onNativeAdLoaded (com.google.android.gms.ads.nativead.NativeAd p0)
	{
		n_onNativeAdLoaded (p0);
	}

	private native void n_onNativeAdLoaded (com.google.android.gms.ads.nativead.NativeAd p0);

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
