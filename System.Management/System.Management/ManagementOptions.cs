using System.ComponentModel;

namespace System.Management;

/// <summary>Provides an abstract base class for all options objects.</summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
public abstract class ManagementOptions : ICloneable
{
	/// <summary>Indicates that no timeout should occur.</summary>
	public static readonly TimeSpan InfiniteTimeout;

	/// <summary>Gets or sets a WMI context object. This is a name-value pairs list to be passed through to a WMI provider that supports context information for customized operation.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementNamedValueCollection" /> that contains WMI context information. </returns>
	public ManagementNamedValueCollection Context
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

	/// <summary>Gets or sets the time-out to apply to the operation. Note that for operations that return collections, this time-out applies to the enumeration through the resulting collection, not the operation itself (the <see cref="P:System.Management.EnumerationOptions.ReturnImmediately" />                   property is used for the latter). This property is used to indicate that the operation should be performed semi-synchronously.                       </summary>
	/// <returns>Returns a <see cref="T:System.TimeSpan" /> that defines the time-out time to apply to the operation.</returns>
	public TimeSpan Timeout
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

	internal ManagementOptions()
	{
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>The cloned object.</returns>
	public abstract object Clone();
}
