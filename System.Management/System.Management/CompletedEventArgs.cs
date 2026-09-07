namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementOperationObserver.Completed" /> event.          </summary>
public class CompletedEventArgs : ManagementEventArgs
{
	/// <summary>Gets the completion status of the operation.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementStatus" /> enumeration value.</returns>
	public ManagementStatus Status
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets additional status information within a WMI object. This may be null.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> that contains status information about the completion of an operation.</returns>
	public ManagementBaseObject StatusObject
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal CompletedEventArgs()
	{
	}
}
