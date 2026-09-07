namespace System.Management;

/// <summary>Specifies options for management event watching.          </summary>
public class EventWatcherOptions : ManagementOptions
{
	/// <summary>Gets or sets the block size for block operations. When waiting for events, this value specifies how many events to wait for before returning.      </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value indicating the block size for a block of operations.</returns>
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EventWatcherOptions" /> class for event watching, using default values. This is the default constructor.          </summary>
	public EventWatcherOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.EventWatcherOptions" /> class with the given values.          </summary>
	/// <param name="context">The options context object containing provider-specific information to be passed through to the provider. </param>
	/// <param name="timeout">The time-out to wait for the next events.</param>
	/// <param name="blockSize">The number of events to wait for in each block.  </param>
	public EventWatcherOptions(ManagementNamedValueCollection context, TimeSpan timeout, int blockSize)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.          </summary>
	/// <returns>The cloned object.             </returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
