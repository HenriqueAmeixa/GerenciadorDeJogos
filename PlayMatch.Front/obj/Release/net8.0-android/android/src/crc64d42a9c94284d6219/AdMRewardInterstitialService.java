package crc64d42a9c94284d6219;


public class AdMRewardInterstitialService
	extends com.google.android.gms.ads.rewardedinterstitial.RewardedInterstitialAdLoadCallback
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.OnUserEarnedRewardListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoaded:(Lcom/google/android/gms/ads/rewardedinterstitial/RewardedInterstitialAd;)V:GetOnAdLoadedHandler\n" +
			"n_onAdFailedToLoad:(Lcom/google/android/gms/ads/LoadAdError;)V:GetOnAdFailedToLoad_Lcom_google_android_gms_ads_LoadAdError_Handler\n" +
			"n_onUserEarnedReward:(Lcom/google/android/gms/ads/rewarded/RewardItem;)V:GetOnUserEarnedReward_Lcom_google_android_gms_ads_rewarded_RewardItem_Handler:Android.Gms.Ads.IOnUserEarnedRewardListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Plugin.MauiMTAdmob.Platforms.Android.AdMRewardInterstitialService, Plugin.MauiMtAdmob", AdMRewardInterstitialService.class, __md_methods);
	}


	public AdMRewardInterstitialService ()
	{
		super ();
		if (getClass () == AdMRewardInterstitialService.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AdMRewardInterstitialService, Plugin.MauiMtAdmob", "", this, new java.lang.Object[] {  });
		}
	}

	public AdMRewardInterstitialService (crc6424817b6e85a95e78.MauiMTAdmob p0)
	{
		super ();
		if (getClass () == AdMRewardInterstitialService.class) {
			mono.android.TypeManager.Activate ("Plugin.MauiMTAdmob.Platforms.Android.AdMRewardInterstitialService, Plugin.MauiMtAdmob", "Plugin.MauiMTAdmob.MauiMTAdmob, Plugin.MauiMtAdmob", this, new java.lang.Object[] { p0 });
		}
	}


	public void onAdLoaded (com.google.android.gms.ads.rewardedinterstitial.RewardedInterstitialAd p0)
	{
		n_onAdLoaded (p0);
	}

	private native void n_onAdLoaded (com.google.android.gms.ads.rewardedinterstitial.RewardedInterstitialAd p0);


	public void onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0)
	{
		n_onAdFailedToLoad (p0);
	}

	private native void n_onAdFailedToLoad (com.google.android.gms.ads.LoadAdError p0);


	public void onUserEarnedReward (com.google.android.gms.ads.rewarded.RewardItem p0)
	{
		n_onUserEarnedReward (p0);
	}

	private native void n_onUserEarnedReward (com.google.android.gms.ads.rewarded.RewardItem p0);

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
