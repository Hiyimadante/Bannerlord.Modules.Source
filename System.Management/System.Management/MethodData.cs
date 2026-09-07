namespace System.Management;

/// <summary>Contains information about a WMI method.          </summary>
public class MethodData
{
	/// <summary>Gets the input parameters to the method. Each parameter is described as a property in the object. If a parameter is both in and out, it appears in both the <see cref="P:System.Management.MethodData.InParameters" /> and <see cref="P:System.Management.MethodData.OutParameters" /> properties.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> containing the input parameters to the method.</returns>
	public ManagementBaseObject InParameters
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the name of the method.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the method.</returns>
	public string Name
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the name of the management class in which the method was first introduced in the class inheritance hierarchy.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the class in which the method was first introduced in the class inheritance hierarchy.</returns>
	public string Origin
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the output parameters to the method. Each parameter is described as a property in the object. If a parameter is both in and out, it will appear in both the <see cref="P:System.Management.MethodData.InParameters" /> and <see cref="P:System.Management.MethodData.OutParameters" /> properties.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> containing the output parameters for the method.</returns>
	public ManagementBaseObject OutParameters
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a collection of qualifiers defined in the method. Each element is of type <see cref="T:System.Management.QualifierData" /> and contains information such as the qualifier name, value, and flavor.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.QualifierDataCollection" /> containing the qualifiers for the method.</returns>
	public QualifierDataCollection Qualifiers
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal MethodData()
	{
	}
}
