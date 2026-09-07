namespace System.Management;

/// <summary>Represents a management query that returns instances or classes.          </summary>
public class ObjectQuery : ManagementQuery
{
	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectQuery" /> class with no initialized values. This is the default constructor.          </summary>
	public ObjectQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectQuery" /> class for a specific query string.          </summary>
	/// <param name="query">The string representation of the query.</param>
	public ObjectQuery(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectQuery" /> class for a specific query string and language.          </summary>
	/// <param name="language">The query language in which this query is specified.</param>
	/// <param name="query">The string representation of the query. </param>
	public ObjectQuery(string language, string query)
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
