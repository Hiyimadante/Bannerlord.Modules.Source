namespace System.Management;

/// <summary>Represents a WMI event query.          </summary>
public class EventQuery : ManagementQuery
{
	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EventQuery" /> class. This is the default constructor.          </summary>
	public EventQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EventQuery" /> class for the specified query.          </summary>
	/// <param name="query">A textual representation of the <paramref name="event query" />.</param>
	public EventQuery(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EventQuery" /> class for the specified language and query.           </summary>
	/// <param name="language">The language in which the query string is specified. </param>
	/// <param name="query">The string representation of the query.</param>
	public EventQuery(string language, string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>The cloned object.             </returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
