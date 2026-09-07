using System.ComponentModel;

namespace System.Management;

/// <summary>Subscribes to temporary event notifications based on a specified event query.          </summary>
[ToolboxItem(false)]
public class ManagementEventWatcher : Component
{
	/// <summary>Gets or sets the options used to watch for events. </summary>
	/// <returns>Returns an <see cref="T:System.Management.EventWatcherOptions" /> that contains the event options used to watch for events.</returns>
	public EventWatcherOptions Options
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

	/// <summary>Gets or sets the criteria to apply to events.      </summary>
	/// <returns>Returns an <see cref="T:System.Management.EventQuery" /> that contains the query to apply to events.</returns>
	public EventQuery Query
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

	/// <summary>Gets or sets the scope in which to watch for events (namespace or scope).      </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementScope" /> that contains the scope the in which to watch for events.</returns>
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

	/// <summary>Occurs when a new event arrives.</summary>
	public event EventArrivedEventHandler EventArrived
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Occurs when a subscription is canceled.</summary>
	public event StoppedEventHandler Stopped
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class. For further initialization, set the properties on the object. This is the default constructor.          </summary>
	public ManagementEventWatcher()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class when given a WMI event query.          </summary>
	/// <param name="query">An <see cref="T:System.Management.EventQuery" /> representing a WMI event query, which determines the events for which the watcher will listen.</param>
	public ManagementEventWatcher(EventQuery query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" />              class that listens for events conforming to the given WMI event query.          </summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> representing the scope (namespace) in which the watcher will listen for events.</param>
	/// <param name="query">An <see cref="T:System.Management.EventQuery" /> representing a WMI event query, which determines the events for which the watcher will listen.  </param>
	public ManagementEventWatcher(ManagementScope scope, EventQuery query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class that listens for events conforming to the given WMI event query, according to the specified options. For this variant, the query and the scope are specified objects. The options object can specify options such as time-out and context information.          </summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> representing the scope (namespace) in which the watcher will listen for events.</param>
	/// <param name="query">An <see cref="T:System.Management.EventQuery" /> representing a WMI event query, which determines the events for which the watcher will listen. </param>
	/// <param name="options">An <see cref="T:System.Management.EventWatcherOptions" /> representing additional options used to watch for events. </param>
	public ManagementEventWatcher(ManagementScope scope, EventQuery query, EventWatcherOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class when given a WMI event query in the form of a string.          </summary>
	/// <param name="query"> A WMI event query, which defines the events for which the watcher will listen.</param>
	public ManagementEventWatcher(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class that listens for events conforming to the given WMI event query. For this variant, the query and the scope are specified as strings.          </summary>
	/// <param name="scope">The management scope (namespace) in which the watcher will listen for events.</param>
	/// <param name="query">The query that defines the events for which the watcher will listen. </param>
	public ManagementEventWatcher(string scope, string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementEventWatcher" /> class that listens for events conforming to the given WMI event query, according to the specified options. For this variant, the query and the scope are specified as strings. The options object can specify options such as a time-out and context information.          </summary>
	/// <param name="scope">The management scope (namespace) in which the watcher will listen for events.</param>
	/// <param name="query">The query that defines the events for which the watcher will listen.  </param>
	/// <param name="options">An <see cref="T:System.Management.EventWatcherOptions" /> representing additional options used to watch for events. </param>
	public ManagementEventWatcher(string scope, string query, EventWatcherOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Subscribes to events with the given query and delivers them, asynchronously, through the <see cref="E:System.Management.ManagementEventWatcher.EventArrived" /> event.          </summary>
	public void Start()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Cancels the subscription whether it is synchronous or asynchronous.          </summary>
	public void Stop()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Waits for the next event that matches the specified query to arrive, and then returns it.          </summary>
	/// <returns>A <see cref="T:System.Management.ManagementBaseObject" /> representing the newly arrived event.</returns>
	public ManagementBaseObject WaitForNextEvent()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
