namespace System.Management;

/// <summary>Specifies options for getting a management object.          </summary>
public class ObjectGetOptions : ManagementOptions
{
	/// <summary>Gets or sets a value indicating whether the objects returned from WMI should contain amended information. Typically, amended information is localizable information attached to the WMI object, such as object and property descriptions.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the objects returned from WMI should contain amended information.</returns>
	public bool UseAmendedQualifiers
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectGetOptions" /> class for getting a WMI object, using default values. This is the default constructor.          </summary>
	public ObjectGetOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectGetOptions" /> class for getting a WMI object, using the specified provider-specific context.          </summary>
	/// <param name="context">A provider-specific, named-value pairs context object to be passed through to the provider.</param>
	public ObjectGetOptions(ManagementNamedValueCollection context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ObjectGetOptions" /> class for getting a WMI object, using the given options values.          </summary>
	/// <param name="context">A provider-specific, named-value pairs context object to be passed through to the provider.</param>
	/// <param name="timeout">The length of time to let the operation perform before it times out. The default is <see cref="F:System.TimeSpan.MaxValue" />.  </param>
	/// <param name="useAmendedQualifiers">
	///       <see langword="true" /> if the returned objects should contain amended (locale-aware) qualifiers; otherwise, <see langword="false" />. </param>
	public ObjectGetOptions(ManagementNamedValueCollection context, TimeSpan timeout, bool useAmendedQualifiers)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>The cloned object.</returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
