package md562f044edbf074a1c1a961722599d8cd6;


public class ViewHolderAdapter
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("OneTalent.ViewHolderAdapter, OneTalent", ViewHolderAdapter.class, __md_methods);
	}


	public ViewHolderAdapter (android.view.View p0)
	{
		super (p0);
		if (getClass () == ViewHolderAdapter.class)
			mono.android.TypeManager.Activate ("OneTalent.ViewHolderAdapter, OneTalent", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
