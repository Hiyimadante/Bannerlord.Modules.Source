namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementOperationObserver.ObjectPut" /> event.          </summary>
public class ObjectPutEventArgs : ManagementEventArgs
{
	/// <summary>Gets the identity of the object that has been put.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementPath" /> containing the path of the object that has been put.</returns>
	public ManagementPath Path
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ObjectPutEventArgs()
	{
	}
}
