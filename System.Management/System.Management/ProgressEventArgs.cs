namespace System.Management;

/// <summary>Holds event data for the <see cref="E:System.Management.ManagementOperationObserver.Progress" /> event.          </summary>
public class ProgressEventArgs : ManagementEventArgs
{
	/// <summary>Gets the current amount of work done by the operation. This is always less than or equal to <see cref="P:System.Management.ProgressEventArgs.UpperBound" />.          </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value representing the current amount of work already completed by the operation.</returns>
	public int Current
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets optional additional information regarding the operation's progress.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing information regarding the operation's progress.</returns>
	public string Message
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the total amount of work required to be done by the operation.          </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value representing the total amount of work to be done by the operation.</returns>
	public int UpperBound
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ProgressEventArgs()
	{
	}
}
