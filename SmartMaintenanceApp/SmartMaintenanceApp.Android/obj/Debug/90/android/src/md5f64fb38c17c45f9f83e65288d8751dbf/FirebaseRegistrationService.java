package md5f64fb38c17c45f9f83e65288d8751dbf;


public class FirebaseRegistrationService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("SmartMaintenanceApp.Droid.FirebaseRegistrationService, SmartMaintenanceApp.Android", FirebaseRegistrationService.class, __md_methods);
	}


	public FirebaseRegistrationService ()
	{
		super ();
		if (getClass () == FirebaseRegistrationService.class)
			mono.android.TypeManager.Activate ("SmartMaintenanceApp.Droid.FirebaseRegistrationService, SmartMaintenanceApp.Android", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

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
