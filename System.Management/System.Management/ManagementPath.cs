using System.ComponentModel;

namespace System.Management;

/// <summary>Provides a wrapper for parsing and building paths to WMI objects.          </summary>
public class ManagementPath : ICloneable
{
	/// <summary>Gets or sets the class portion of the path.                       </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value that holds the class portion of the path.</returns>
	[RefreshProperties(RefreshProperties.All)]
	public string ClassName
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

	/// <summary>Gets or sets the default scope path used when no scope is specified. The default scope is \\.\root\cimv2, and can be changed by setting this property.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementPath" /> that contains the default scope (namespace) path used when no scope is specified.</returns>
	public static ManagementPath DefaultPath
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

	/// <summary>Gets or sets a value indicating whether this is a class path.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether this is a class path.</returns>
	public bool IsClass
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets a value indicating whether this is an instance path.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether this is an instance path.</returns>
	public bool IsInstance
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets a value indicating whether this is a singleton instance path.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether this is a singleton instance path.</returns>
	public bool IsSingleton
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the namespace part of the path. Note that this does not include the server name, which can be retrieved separately.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the namespace part of the path.</returns>
	[RefreshProperties(RefreshProperties.All)]
	public string NamespacePath
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

	/// <summary>Gets or sets the string representation of the full path in the object.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the full path.</returns>
	[RefreshProperties(RefreshProperties.All)]
	public string Path
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

	/// <summary>Gets or sets the relative path: class name and keys only.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the relative path.</returns>
	[RefreshProperties(RefreshProperties.All)]
	public string RelativePath
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

	/// <summary>Gets or sets the server part of the path.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the server name.</returns>
	[RefreshProperties(RefreshProperties.All)]
	public string Server
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementPath" /> class that is empty. This is the default constructor.          </summary>
	public ManagementPath()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementPath" /> class for the given path.          </summary>
	/// <param name="path"> The object path. </param>
	public ManagementPath(string path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the <see cref="T:System.Management.ManagementPath" />.          </summary>
	/// <returns>The cloned object.             </returns>
	public ManagementPath Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Sets the path as a new class path. This means that the path must have a class name but not key values.          </summary>
	public void SetAsClass()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Sets the path as a new singleton object path. This means that it is a path to an instance but there are no key values.          </summary>
	public void SetAsSingleton()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a new object that is a copy of the current instance.  </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	object ICloneable.Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the full object path as the string representation.          </summary>
	/// <returns>A string containing the full object path represented by this object. This value is equivalent to the value of the <see cref="P:System.Management.ManagementPath.Path" /> property.             </returns>
	public override string ToString()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
