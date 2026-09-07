using System.Security;

namespace System.Management;

/// <summary>Specifies all settings required to make a WMI connection.</summary>
public class ConnectionOptions : ManagementOptions
{
	/// <summary>Gets or sets the COM authentication level to be used for operations in this connection.</summary>
	/// <returns>Returns an <see cref="T:System.Management.AuthenticationLevel" /> enumeration value indicating the COM authentication level used for a connection to the local or a remote computer. </returns>
	public AuthenticationLevel Authentication
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

	/// <summary>Gets or sets the authority to be used to authenticate the specified user.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> that defines the authority used to authenticate the specified user.</returns>
	public string Authority
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

	/// <summary>Gets or sets a value indicating whether user privileges need to be enabled for the connection operation. This property should only be used when the operation performed requires a certain user privilege to be enabled (for example, a machine restart).          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether user privileges need to be enabled for the connection operation.</returns>
	public bool EnablePrivileges
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

	/// <summary>Gets or sets the COM impersonation level to be used for operations in this connection.</summary>
	/// <returns>Returns an <see cref="T:System.Management.ImpersonationLevel" /> enumeration value indicating the impersonation level used to connect to WMI.</returns>
	public ImpersonationLevel Impersonation
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

	/// <summary>Gets or sets the locale to be used for the connection operation.</summary>
	/// <returns>Returns a <see cref="T:System.String" /> value used for the locale in a connection to WMI.</returns>
	public string Locale
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

	/// <summary>Sets the password for the specified user.</summary>
	/// <returns>Returns a <see cref="T:System.String" /> value used for the password in a connection to WMI.</returns>
	public string Password
	{
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Sets the password for the specified user.</summary>
	/// <returns>Returns a SecureString value used for the password in a connection to WMI.</returns>
	public SecureString SecurePassword
	{
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the user name to be used for the connection operation.</summary>
	/// <returns>Returns a <see cref="T:System.String" /> value used as the user name in a connection to WMI.</returns>
	public string Username
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ConnectionOptions" /> class for the connection operation, using default values. This is the default constructor.          </summary>
	public ConnectionOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a new ConnectionOption.</summary>
	/// <param name="locale">The locale to be used for the connection.</param>
	/// <param name="username">The user name to be used for the connection. If null, the credentials of the currently logged-on user are used.</param>
	/// <param name="password">The password for the given user name. If the user name is also null, the credentials used will be those of the currently logged-on user.</param>
	/// <param name="authority">The authority to be used to authenticate the specified user.</param>
	/// <param name="impersonation">The COM impersonation level to be used for the connection.</param>
	/// <param name="authentication">The COM authentication level to be used for the connection.  </param>
	/// <param name="enablePrivileges">true to enable special user privileges; otherwise, false. This parameter should only be used when performing an operation that requires special Windows NT user privileges.</param>
	/// <param name="context">A provider-specific, named value pairs object to be passed through to the provider.</param>
	/// <param name="timeout">Reserved for future use.</param>
	public ConnectionOptions(string locale, string username, SecureString password, string authority, ImpersonationLevel impersonation, AuthenticationLevel authentication, bool enablePrivileges, ManagementNamedValueCollection context, TimeSpan timeout)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ConnectionOptions" /> class to be used for a WMI connection, using the specified values.</summary>
	/// <param name="locale">The locale to be used for the connection.</param>
	/// <param name="username">The user name to be used for the connection. If null, the credentials of the currently logged-on user are used.</param>
	/// <param name="password">The password for the given user name. If the user name is also null, the credentials used will be those of the currently logged-on user.</param>
	/// <param name="authority">The authority to be used to authenticate the specified user. </param>
	/// <param name="impersonation">The COM impersonation level to be used for the connection. </param>
	/// <param name="authentication">The COM authentication level to be used for the connection.  </param>
	/// <param name="enablePrivileges">
	///       <see langword="true" /> to enable special user privileges; otherwise, <see langword="false" />. This parameter should only be used when performing an operation that requires special Windows NT user privileges.</param>
	/// <param name="context">A provider-specific, named value pairs object to be passed through to the provider. </param>
	/// <param name="timeout">Reserved for future use. </param>
	public ConnectionOptions(string locale, string username, string password, string authority, ImpersonationLevel impersonation, AuthenticationLevel authentication, bool enablePrivileges, ManagementNamedValueCollection context, TimeSpan timeout)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.</summary>
	/// <returns>The cloned object.</returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
