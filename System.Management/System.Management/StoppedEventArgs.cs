namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementEventWatcher.Stopped" /> event.          </summary>
public class StoppedEventArgs : ManagementEventArgs
{
	/// <summary>Gets the completion status of the operation.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementStatus" /> containing the status of the operation.</returns>
	public ManagementStatus Status
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal StoppedEventArgs()
	{
	}
}
