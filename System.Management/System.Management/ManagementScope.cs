namespace System.Management;

/// <summary>Represents a scope (namespace) for management operations.           </summary>
public class ManagementScope : ICloneable
{
	/// <summary>Gets a value indicating whether the <see cref="T:System.Management.ManagementScope" /> is currently bound to a WMI server and namespace.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the scope is currently bound to a WMI server and namespace.</returns>
	public bool IsConnected
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets options for making the WMI connection.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ConnectionOptions" /> that contains the options for making a WMI connection.</returns>
	public ConnectionOptions Options
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

	/// <summary>Gets or sets the path for the <see cref="T:System.Management.ManagementScope" />.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementPath" /> containing the path to the scope (namespace).</returns>
	public ManagementPath Path
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class, with default values. This is the default constructor.          </summary>
	public ManagementScope()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path.          </summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> containing the path to a server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
	public ManagementScope(ManagementPath path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path, with the specified options.          </summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> containing the path to the server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
	/// <param name="options">The <see cref="T:System.Management.ConnectionOptions" /> containing options for the connection. </param>
	public ManagementScope(ManagementPath path, ConnectionOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path.          </summary>
	/// <param name="path">The server and namespace path for the <see cref="T:System.Management.ManagementScope" />.</param>
	public ManagementScope(string path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path, with the specified options.          </summary>
	/// <param name="path">The server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
	/// <param name="options">A <see cref="T:System.Management.ConnectionOptions" /> containing options for the connection. </param>
	public ManagementScope(string path, ConnectionOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>A new copy of the <see cref="T:System.Management.ManagementScope" />.</returns>
	public ManagementScope Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Connects this <see cref="T:System.Management.ManagementScope" /> to the actual WMI scope.          </summary>
	public void Connect()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a new object that is a copy of the current instance.  </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	object ICloneable.Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
