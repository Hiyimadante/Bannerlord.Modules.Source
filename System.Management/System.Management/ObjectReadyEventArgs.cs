namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementOperationObserver.ObjectReady" /> event.          </summary>
public class ObjectReadyEventArgs : ManagementEventArgs
{
	/// <summary>Gets the newly-returned object.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> containing the newly-returned object.</returns>
	public ManagementBaseObject NewObject
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ObjectReadyEventArgs()
	{
	}
}
