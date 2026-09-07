namespace System.Management;

/// <summary>Specifies options for committing management object changes.          </summary>
public class PutOptions : ManagementOptions
{
	/// <summary>Gets or sets the type of commit to be performed for the object.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.PutType" /> enumeration value representing the type of commit to be performed for the object.</returns>
	public PutType Type
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

	/// <summary>Gets or sets a value indicating whether the objects returned from WMI should                   contain amended information. Typically, amended information is localizable information attached to the WMI object, such as object and property descriptions.          </summary>
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.PutOptions" /> class for put operations, using default values. This is the default constructor.          </summary>
	public PutOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.PutOptions" /> class for committing a WMI object, using the specified provider-specific context.          </summary>
	/// <param name="context">A provider-specific, named-value pairs context object to be passed through to the provider.</param>
	public PutOptions(ManagementNamedValueCollection context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.PutOptions" /> class for committing a WMI object, using the specified option values.          </summary>
	/// <param name="context">A provider-specific, named-value pairs object to be passed through to the provider. </param>
	/// <param name="timeout">The length of time to let the operation perform before it times out. The default is <see cref="F:System.TimeSpan.MaxValue" />. </param>
	/// <param name="useAmendedQualifiers">
	///       <see langword="true" /> if the returned objects should contain amended (locale-aware) qualifiers; otherwise, <see langword="false" />. </param>
	/// <param name="putType">The type of commit to be performed (update or create). </param>
	public PutOptions(ManagementNamedValueCollection context, TimeSpan timeout, bool useAmendedQualifiers, PutType putType)
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
