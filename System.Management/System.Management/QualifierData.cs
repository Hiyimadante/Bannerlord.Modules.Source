namespace System.Management;

/// <summary>Contains information about a WMI qualifier.          </summary>
public class QualifierData
{
	/// <summary>Gets or sets a value indicating whether the qualifier is amended.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the qualifier is amended.</returns>
	public bool IsAmended
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

	/// <summary>Gets a value indicating whether the qualifier has been defined locally on this class or has been propagated from a base class.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the qualifier has been defined locally on this class or has been propagated from a base class.</returns>
	public bool IsLocal
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets a value indicating whether the value of the qualifier can be overridden when propagated.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the value of the qualifier can be overridden when propagated.</returns>
	public bool IsOverridable
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

	/// <summary>Represents the name of the qualifier.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the qualifier.</returns>
	public string Name
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets a value indicating whether the qualifier should be propagated to instances of the class.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the qualifier should be propagated to instances of the class.</returns>
	public bool PropagatesToInstance
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

	/// <summary>Gets or sets a value indicating whether the qualifier should be propagated to                    subclasses of the class.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the qualifier should be propagated to subclasses of the class.</returns>
	public bool PropagatesToSubclass
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

	/// <summary>Gets or sets the value of the qualifier.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value containing the value of the qualifier.</returns>
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

	internal QualifierData()
	{
	}
}
