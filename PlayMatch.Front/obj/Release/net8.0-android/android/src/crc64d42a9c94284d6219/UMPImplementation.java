package crc64d42a9c94284d6219;


public class UMPImplementation
	extends com.google.android.gms.ads.rewardedinterstitial.RewardedInterstitialAdLoadCallback
	implements
		mono.android.IGCUserPeer,
		com.google.android.ump.ConsentInformation.OnConsentInfoUpdateSuccessListener,
		com.google.android.ump.ConsentInformation.OnConsentInfoUpdateFailureListener,
		com.google.android.ump.ConsentForm.OnConsentFormDismissedListener,
		com.google.android.ump.UserMessagingPlatform.OnConsentFormLoadSuccessListener,
		com.google.android.ump.UserMessagingPlatform.OnConsentFormLoadFailureListener,
		com.google.android.gms.ads.initialization.OnInitializationCompleteListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConsentInfoUpdateSuccess:()V:GetOnConsentInfoUpdateSuccessHandler:Xamarin.Google.UserMesssagingPlatform.IConsentInformationOnConsentInfoUpdateSuccessListenerInvoker, Xamarin.Google.UserMessagingPlatform\n" +
			"n_onConsentInfoUpdateFailure:(Lcom/google/android/ump/FormError;)V:GetOnConsentInfoUpdateFailure_Lcom_google_android_ump_FormError_Handler:Xamarin.Google.UserMesssagingPlatform.IConsentInformationOnConsentInfoUpdateFailureListenerInvoker, Xamarin.Google.UserMessagingPlatform\n" +
			"n_onConsentFormDismissed:(Lcom/google/android/ump/FormError;)V:GetOnConsentFormDismissed_Lcom_google_android_ump_FormError_Handler:Xamarin.Google.UserMesssagingPlatform.IConsentFormOnConsentFormDismissedListenerInvoker, Xamarin.Google.UserMessagingPlatform\n" +
			"n_onConsentFormLoadSuccess:(Lcom/google/android/ump/ConsentForm;)V:GetOnConsentFormLoadSuccess_Lcom_google_android_ump_ConsentForm_Handler:Xamarin.Google.UserMesssagingPlatform.UserMessagingPlatform/IOnConsentFormLoadSuccessListenerInvoker, Xamarin.Google.UserMessagingPlatform\n" +
			"n_onConsentFormLoadFailure:(Lcom/google/android/ump/FormError;)V:GetOnConsentFormLoadFailure_Lcom_google_android_ump_FormError_Handler:Xamarin.Google.UserMesssagingPlatform.UserMessagingPlatform/IOnConsentFormLoadFailureListenerInvoker, Xamarin.Google.UserMessagingPlatform\n" +
			"n_onInitializationComplete:(Lcom/google/android/gms/ads/initialization/InitializationStatus;)V:GetOnInitializationComplete_Lcom_google_android_gms_ads_initialization_InitializationStatus_Handler:Android.Gms.Ads.Initialization.IOnInitializationCompleteListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.UMPImplementation, Plugin.MauiMtAdmob", UMPImplementation.class, __md_methods);
	}


	public UMPImplementation ()
	{
		super ();
		if (getClass () == UMPImplementation.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.UMPImplementation, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public UMPImplementation (crc6424817b6e85a95e78.MauiMTAdmob p0, crc6488302ad6e9e4df1a.MauiAppCompatActivity p1, java.lang.String p2, java.lang.String p3, java.lang.String p4, boolean p5, java.lang.String p6, boolean p7, int p8, boolean p9)
	{
		super ();
		if (getClass () == UMPImplementation.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.UMPImplementation, Plugin.MauiMtAdmob", "Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob:Microsoft.Maui.MauiAppCompatActivity, Microsoft.Maui:System.String, System.Private.CoreLib:System.String, System.Private.CoreLib:System.String, System.Private.CoreLib:System.Boolean, System.Private.CoreLib:System.String, System.Private.CoreLib:System.Boolean, System.Private.CoreLib:Plugin.MauiMTAdmob.Extra.DebugGeography, Plugin.MauiMtAdmob:System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 });
		}
	}


	public void onConsentInfoUpdateSuccess ()
	{
		n_onConsentInfoUpdateSuccess ();
	}

	private native void n_onConsentInfoUpdateSuccess ();


	public void onConsentInfoUpdateFailure (com.google.android.ump.FormError p0)
	{
		n_onConsentInfoUpdateFailure (p0);
	}

	private native void n_onConsentInfoUpdateFailure (com.google.android.ump.FormError p0);


	public void onConsentFormDismissed (com.google.android.ump.FormError p0)
	{
		n_onConsentFormDismissed (p0);
	}

	private native void n_onConsentFormDismissed (com.google.android.ump.FormError p0);


	public void onConsentFormLoadSuccess (com.google.android.ump.ConsentForm p0)
	{
		n_onConsentFormLoadSuccess (p0);
	}

	private native void n_onConsentFormLoadSuccess (com.google.android.ump.ConsentForm p0);


	public void onConsentFormLoadFailure (com.google.android.ump.FormError p0)
	{
		n_onConsentFormLoadFailure (p0);
	}

	private native void n_onConsentFormLoadFailure (com.google.android.ump.FormError p0);


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
