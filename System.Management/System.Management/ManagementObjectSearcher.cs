using System.ComponentModel;

namespace System.Management;

/// <summary>Retrieves a collection of management objects based on a specified query. This class is one of the more commonly used entry points to retrieving management information. For example, it can be used to enumerate all disk drives, network adapters, processes and many more management objects on a system, or to query for all network connections that are up, services that are paused, and so on.  When instantiated, an instance of this class takes as input a WMI query represented in an <see cref="T:System.Management.ObjectQuery" /> or its derivatives, and optionally a <see cref="T:System.Management.ManagementScope" /> representing the WMI namespace to execute the query in. It can also take additional advanced options in an <see cref="T:System.Management.EnumerationOptions" />. When the <see cref="M:System.Management.ManagementObjectSearcher.Get" /> method on this object                   is invoked, the <see cref="T:System.Management.ManagementObjectSearcher" /> executes the given query in the specified scope and returns a collection of management objects that match the query in a <see cref="T:System.Management.ManagementObjectCollection" />. </summary>
[ToolboxItem(false)]
public class ManagementObjectSearcher : Component
{
	/// <summary>Gets or sets the options for how to search for objects.          </summary>
	/// <returns>Returns an <see cref="T:System.Management.EnumerationOptions" /> that contains the options for searching for WMI objects.</returns>
	public EnumerationOptions Options
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the query to be invoked in the searcher (that is, the criteria to be applied to the search for management objects).          </summary>
	/// <returns>Returns an <see cref="T:System.Management.ObjectQuery" /> that contains the query to be invoked in the searcher.</returns>
	public ObjectQuery Query
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the scope in which to look for objects (the scope represents a WMI namespace).          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementScope" /> that contains the scope (namespace) in which to look for the WMI objects.</returns>
	public ManagementScope Scope
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class. After some properties on this object are set, the object can be used to invoke a query for management information. This is the default constructor.          </summary>
	public ManagementObjectSearcher()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class used to invoke the specified query in the specified scope.          </summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> representing the scope in which to invoke the query.</param>
	/// <param name="query">An <see cref="T:System.Management.ObjectQuery" /> representing the query to be invoked. </param>
	public ManagementObjectSearcher(ManagementScope scope, ObjectQuery query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class to be used to invoke the specified query in the specified scope, with the specified options.          </summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> specifying the scope of the query.</param>
	/// <param name="query">An <see cref="T:System.Management.ObjectQuery" /> specifying the query to be invoked. </param>
	/// <param name="options">An <see cref="T:System.Management.EnumerationOptions" /> specifying additional options to be used for the query. </param>
	public ManagementObjectSearcher(ManagementScope scope, ObjectQuery query, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class used to invoke the specified query for management information.          </summary>
	/// <param name="query">An <see cref="T:System.Management.ObjectQuery" /> representing the query to be invoked by the searcher.</param>
	public ManagementObjectSearcher(ObjectQuery query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class used to invoke the specified query for management information.          </summary>
	/// <param name="queryString">The WMI query to be invoked by the object.</param>
	public ManagementObjectSearcher(string queryString)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class used to invoke the specified query in the specified scope.          </summary>
	/// <param name="scope">The scope in which to query.</param>
	/// <param name="queryString">The query to be invoked.  </param>
	public ManagementObjectSearcher(string scope, string queryString)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObjectSearcher" /> class used to invoke the specified query, in the specified scope, and with the specified options.          </summary>
	/// <param name="scope">The scope in which the query should be invoked.</param>
	/// <param name="queryString">The query to be invoked. </param>
	/// <param name="options">An <see cref="T:System.Management.EnumerationOptions" /> specifying additional options for the query.  </param>
	public ManagementObjectSearcher(string scope, string queryString, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes the specified WMI query and returns the resulting collection.          </summary>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the objects that match the specified query.</returns>
	public ManagementObjectCollection Get()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes the WMI query asynchronously, and binds to a watcher to deliver the results.          </summary>
	/// <param name="watcher">The watcher that raises events triggered by the operation. </param>
	public void Get(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
