namespace System.Management;

/// <summary>Represents a WMI data query in WQL format.          </summary>
public class WqlObjectQuery : ObjectQuery
{
	/// <summary>Gets the language of the query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the language of the query.</returns>
	public override string QueryLanguage
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlObjectQuery" /> class. This is the default constructor.          </summary>
	public WqlObjectQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlObjectQuery" /> class initialized to the specified query.          </summary>
	/// <param name="query"> The representation of the data query.</param>
	public WqlObjectQuery(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a copy of the object.          </summary>
	/// <returns>The copied object.             </returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
