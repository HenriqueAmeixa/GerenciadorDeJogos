package crc64d42a9c94284d6219;


public class MyFullScreenContentCallback
	extends com.google.android.gms.ads.FullScreenContentCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdDismissedFullScreenContent:()V:GetOnAdDismissedFullScreenContentHandler\n" +
			"n_onAdFailedToShowFullScreenContent:(Lcom/google/android/gms/ads/AdError;)V:GetOnAdFailedToShowFullScreenContent_Lcom_google_android_gms_ads_AdError_Handler\n" +
			"n_onAdShowedFullScreenContent:()V:GetOnAdShowedFullScreenContentHandler\n" +
			"n_onAdImpression:()V:GetOnAdImpressionHandler\n" +
			"n_onAdClicked:()V:GetOnAdClickedHandler\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.MyFullScreenContentCallback, Plugin.MauiMtAdmob", MyFullScreenContentCallback.class, __md_methods);
	}


	public MyFullScreenContentCallback ()
	{
		super ();
		if (getClass () == MyFullScreenContentCallback.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.MyFullScreenContentCallback, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public MyFullScreenContentCallback (crc6424817b6e85a95e78.MauiMTAdmob p0, int p1, crc64d42a9c94284d6219.AppOpenAdManager p2)
	{
		super ();
		if (getClass () == MyFullScreenContentCallback.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.MyFullScreenContentCallback, Plugin.MauiMtAdmob", "Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob:Plugin.MauiMTAdmob.Extra.AdType, Plugin.MauiMtAdmob:Plugin.MauiMTAdmob.Platforms.Android.AppOpenAdManager, Plugin.MauiMtAdmob", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public void onAdDismissedFullScreenContent ()
	{
		n_onAdDismissedFullScreenContent ();
	}

	private native void n_onAdDismissedFullScreenContent ();


	public void onAdFailedToShowFullScreenContent (com.google.android.gms.ads.AdError p0)
	{
		n_onAdFailedToShowFullScreenContent (p0);
	}

	private native void n_onAdFailedToShowFullScreenContent (com.google.android.gms.ads.AdError p0);


	public void onAdShowedFullScreenContent ()
	{
		n_onAdShowedFullScreenContent ();
	}

	private native void n_onAdShowedFullScreenContent ();


	public void onAdImpression ()
	{
		n_onAdImpression ();
	}

	private native void n_onAdImpression ();


	public void onAdClicked ()
	{
		n_onAdClicked ();
	}

	private native void n_onAdClicked ();

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
