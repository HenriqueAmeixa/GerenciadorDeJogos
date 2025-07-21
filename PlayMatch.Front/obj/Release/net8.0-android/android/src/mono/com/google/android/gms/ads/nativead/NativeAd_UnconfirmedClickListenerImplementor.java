package mono.com.google.android.gms.ads.nativead;


public class NativeAd_UnconfirmedClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.nativead.NativeAd.UnconfirmedClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onUnconfirmedClickCancelled:()V:GetOnUnconfirmedClickCancelledHandler:Android.Gms.Ads.NativeAd.NativeAd/IUnconfirmedClickListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"n_onUnconfirmedClickReceived:(Ljava/lang/String;)V:GetOnUnconfirmedClickReceived_Ljava_lang_String_Handler:Android.Gms.Ads.NativeAd.NativeAd/IUnconfirmedClickListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Ads.NativeAd.NativeAd+IUnconfirmedClickListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", NativeAd_UnconfirmedClickListenerImplementor.class, __md_methods);
	}


	public NativeAd_UnconfirmedClickListenerImplementor ()
	{
		super ();
		if (getClass () == NativeAd_UnconfirmedClickListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Android.Gms.Ads.NativeAd.NativeAd+IUnconfirmedClickListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", "", this, new java.lang.Object[] {  });
		}
	}


	public void onUnconfirmedClickCancelled ()
	{
		n_onUnconfirmedClickCancelled ();
	}

	private native void n_onUnconfirmedClickCancelled ();


	public void onUnconfirmedClickReceived (java.lang.String p0)
	{
		n_onUnconfirmedClickReceived (p0);
	}

	private native void n_onUnconfirmedClickReceived (java.lang.String p0);

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
