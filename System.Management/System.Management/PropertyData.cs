namespace System.Management;

/// <summary>Represents information about a WMI property.          </summary>
public class PropertyData
{
	/// <summary>Gets a value indicating whether the property is an array.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the property is an array.</returns>
	public bool IsArray
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a value indicating whether the property has been defined in the current WMI class.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the property has been defined in the current WMI class.</returns>
	public bool IsLocal
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the name of the property.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the property name.</returns>
	public string Name
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the name of the WMI class in the hierarchy in which the property was introduced.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the WMI class in the hierarchy in which the property was introduced.</returns>
	public string Origin
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the set of qualifiers defined on the property.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.QualifierDataCollection" /> containing the set of qualifiers defined on the property.</returns>
	public QualifierDataCollection Qualifiers
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the CIM type of the property.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.CimType" /> enumeration value representing the CIM type of the property.</returns>
	public CimType Type
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the current value of the property.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value representing the value of the property.</returns>
	public object Value
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

	internal PropertyData()
	{
	}
}
