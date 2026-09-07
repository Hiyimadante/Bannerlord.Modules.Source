namespace System.Management;

/// <summary>Specifies options for deleting a management object.          </summary>
public class DeleteOptions : ManagementOptions
{
	/// <summary>Initializes a new instance of the <see cref="T:System.Management.DeleteOptions" /> class for the delete operation, using default values. This is the default constructor.          </summary>
	public DeleteOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.DeleteOptions" /> class for a delete operation, using the specified values.          </summary>
	/// <param name="context">A provider-specific, named-value pairs object to be passed through to the provider. </param>
	/// <param name="timeout">The length of time to let the operation perform before it times out. The default value is <see cref="F:System.TimeSpan.MaxValue" />. Setting this parameter will invoke the operation semisynchronously.</param>
	public DeleteOptions(ManagementNamedValueCollection context, TimeSpan timeout)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>A cloned object.</returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
