namespace System.Management;

/// <summary>Provides an abstract base class for all management query objects.           </summary>
public abstract class ManagementQuery : ICloneable
{
	/// <summary>Gets or sets the query language used in the query string, defining the format of the query string.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the format of the query string.</returns>
	public virtual string QueryLanguage
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

	/// <summary>Gets or sets the query in text format.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the query.</returns>
	public virtual string QueryString
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

	internal ManagementQuery()
	{
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>The cloned object.             </returns>
	public abstract object Clone();

	/// <summary>Parses the query string and sets the property values accordingly. If the query is valid, the class name property and condition property of the query will be parsed.                       </summary>
	/// <param name="query">The query string to be parsed.</param>
	protected internal virtual void ParseQuery(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
