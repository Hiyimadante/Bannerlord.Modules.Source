namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementEventWatcher.EventArrived" /> event.          </summary>
public class EventArrivedEventArgs : ManagementEventArgs
{
	/// <summary>Gets the WMI event that was delivered.      </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> that contains the delivered WMI event.</returns>
	public ManagementBaseObject NewEvent
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal EventArrivedEventArgs()
	{
	}
}
