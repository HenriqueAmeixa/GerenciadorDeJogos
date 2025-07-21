package crc6424817b6e85a95e78;


public class MauiMTAdmob
	extends com.google.android.gms.ads.interstitial.InterstitialAdLoadCallback
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.initialization.OnInitializationCompleteListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializationComplete:(Lcom/google/android/gms/ads/initialization/InitializationStatus;)V:GetOnInitializationComplete_Lcom_google_android_gms_ads_initialization_InitializationStatus_Handler:Android.Gms.Ads.Initialization.IOnInitializationCompleteListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob", MauiMTAdmob.class, __md_methods);
	}


	public MauiMTAdmob ()
	{
		super ();
		if (getClass () == MauiMTAdmob.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}


	public void onInitializationComplete (com.google.android.gms.ads.initialization.InitializationStatus p0)
	{
		n_onInitializationComplete (p0);
	}

	private native void n_onInitializationComplete (com.google.android.gms.ads.initialization.InitializationStatus p0);

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
