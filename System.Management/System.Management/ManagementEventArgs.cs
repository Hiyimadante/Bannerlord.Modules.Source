namespace System.Management;

/// <summary>Represents the virtual base class to hold event data for WMI events.          </summary>
public abstract class ManagementEventArgs : EventArgs
{
	/// <summary>Gets the operation context echoed back                   from the operation that triggered the event.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value for an operation context.</returns>
	public object Context
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ManagementEventArgs()
	{
	}
}
