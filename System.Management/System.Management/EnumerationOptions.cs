namespace System.Management;

/// <summary>Provides a base class for query and enumeration-related options objects.          </summary>
public class EnumerationOptions : ManagementOptions
{
	/// <summary>Gets or sets the block size for block operations. When enumerating through a collection, WMI will return results in groups of the specified size.          </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value used for the block size in block operations.</returns>
	public int BlockSize
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

	/// <summary>Gets or sets a value indicating whether direct access to the WMI provider is requested for the specified class, without any regard to its super class or derived classes.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether direct access to the WMI provider is requested for the specified class.</returns>
	public bool DirectRead
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

	/// <summary>Gets or sets a value indicating whether to the objects returned should have locatable information in them. This ensures that the system properties, such as __PATH, __RELPATH, and __SERVER, are non-NULL. This flag can only be used in queries, and is ignored in enumerations.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the objects returned should have locatable information in them.</returns>
	public bool EnsureLocatable
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

	/// <summary>Gets or sets a value indicating whether recursive enumeration is requested into all classes derived from the specified superclass. If <see langword="false" />, only immediate derived class members are returned.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether recursive enumeration is requested into all classes derived from the specified superclass.</returns>
	public bool EnumerateDeep
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

	/// <summary>Gets or sets a value indicating whether the query should return a prototype of the result set instead of the actual results. This flag is used for prototyping.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the query should return a prototype of the result set instead of the actual results.</returns>
	public bool PrototypeOnly
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

	/// <summary>Gets or sets a value indicating whether the invoked operation should be performed in a synchronous or semisynchronous fashion. If this property is set to <see langword="true" />, the enumeration is invoked and the call returns immediately. The actual retrieval of the results will occur when the resulting collection is walked.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the invoked operation should be performed in a synchronous or semisynchronous fashion.</returns>
	public bool ReturnImmediately
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

	/// <summary>Gets or sets a value indicating whether the collection is assumed to be rewindable. If <see langword="true" />, the objects in the collection will be kept available for multiple enumerations. If <see langword="false" />, the collection can only be enumerated one time.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the collection is assumed to be rewindable.</returns>
	public bool Rewindable
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

	/// <summary>Gets or sets a value indicating whether the objects returned from WMI should contain amended information. Typically, amended information is localizable information attached to the WMI object, such as object and property descriptions.  </summary>
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EnumerationOptions" /> class with default values (see the individual property descriptions for what the default values are). This is the default constructor.           </summary>
	public EnumerationOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EnumerationOptions" /> class to be used for queries or enumerations, allowing the user to specify values for the different options.          </summary>
	/// <param name="context">The options context object containing provider-specific information that can be passed through to the provider.</param>
	/// <param name="timeout">The time-out value for enumerating through the results.</param>
	/// <param name="blockSize">The number of items to retrieve at one time from WMI.</param>
	/// <param name="rewindable">
	///       <see langword="true" /> to show that the result set is rewindable (allows multiple traversal); otherwise, <see langword="false" />.</param>
	/// <param name="returnImmediatley">
	///       <see langword="true" /> to show that the operation should return immediately (semi-sync) or block until all results are available; otherwise, <see langword="false" />.</param>
	/// <param name="useAmendedQualifiers">
	///       <see langword="true" /> to show that the returned objects should contain amended (locale-aware) qualifiers; otherwise, <see langword="false" />.</param>
	/// <param name="ensureLocatable">
	///       <see langword="true" /> to ensure all returned objects have valid paths; otherwise, <see langword="false" />.</param>
	/// <param name="prototypeOnly">
	///       <see langword="true" /> to return a prototype of the result set instead of the actual results; otherwise, <see langword="false" />.</param>
	/// <param name="directRead">
	///       <see langword="true" /> to retrieve objects of only the specified class or from derived classes as well; otherwise, <see langword="false" />.</param>
	/// <param name="enumerateDeep">
	///       <see langword="true" /> to use recursive enumeration in subclasses; otherwise, <see langword="false" />.</param>
	public EnumerationOptions(ManagementNamedValueCollection context, TimeSpan timeout, int blockSize, bool rewindable, bool returnImmediatley, bool useAmendedQualifiers, bool ensureLocatable, bool prototypeOnly, bool directRead, bool enumerateDeep)
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
