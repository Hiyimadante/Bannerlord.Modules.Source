namespace System.Management;

/// <summary>Manages asynchronous operations and handles management information and events received asynchronously.          </summary>
public class ManagementOperationObserver
{
	/// <summary>Occurs when an operation has completed.</summary>
	public event CompletedEventHandler Completed
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Occurs when an object has been successfully committed.</summary>
	public event ObjectPutEventHandler ObjectPut
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Occurs when a new object is available.</summary>
	public event ObjectReadyEventHandler ObjectReady
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Occurs to indicate the progress of an ongoing operation.</summary>
	public event ProgressEventHandler Progress
	{
		add
		{
		}
		remove
		{
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementOperationObserver" /> class. This is the default constructor.          </summary>
	public ManagementOperationObserver()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Cancels all outstanding operations.          </summary>
	public void Cancel()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
