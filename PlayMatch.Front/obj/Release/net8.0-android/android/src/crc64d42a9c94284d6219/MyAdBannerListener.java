package crc64d42a9c94284d6219;


public class MyAdBannerListener
	extends com.google.android.gms.ads.AdListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdClicked:()V:GetOnAdClickedHandler\n" +
			"n_onAdClosed:()V:GetOnAdClosedHandler\n" +
			"n_onAdImpression:()V:GetOnAdImpressionHandler\n" +
			"n_onAdOpened:()V:GetOnAdOpenedHandler\n" +
			"n_onAdFailedToLoad:(Lcom/google/android/gms/ads/LoadAdError;)V:GetOnAdFailedToLoad_Lcom_google_android_gms_ads_LoadAdError_Handler\n" +
			"n_onAdLoaded:()V:GetOnAdLoadedHandler\n" +
			"n_onAdSwipeGestureClicked:()V:GetOnAdSwipeGestureClickedHandler\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.MyAdBannerListener, Plugin.MauiMtAdmob", MyAdBannerListener.class, __md_methods);
	}


	public MyAdBannerListener ()
	{
		super ();
		if (getClass () == MyAdBannerListener.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.MyAdBannerListener, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
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


	public void onAdImpression ()
	{
		n_onAdImpression ();
	}

	private native void n_onAdImpression ();


	public void onAdOpened ()
	{
		n_onAdOpened ();
	}

	private native void n_onAdOpened ();


	public void onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0);


	public void onAdLoaded ()
	{
		n_onAdLoaded ();
	}

	private native void n_onAdLoaded ();


	public void onAdSwipeGestureClicked ()
	{
		n_onAdSwipeGestureClicked ();
	}

	private native void n_onAdSwipeGestureClicked ();

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
