using System.Runtime.Serialization;

namespace System.Management;

/// <summary>Represents management exceptions.          </summary>
public class ManagementException : SystemException
{
	/// <summary>Gets the error code reported by WMI, which caused this exception.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementStatus" /> enumeration value that contains the error code.</returns>
	public ManagementStatus ErrorCode
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the extended error object provided by WMI.          </summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementBaseObject" /> that contains extended error information.</returns>
	public ManagementBaseObject ErrorInformation
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementException" /> class.          </summary>
	public ManagementException()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementException" /> class that is serializable.          </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> destination for this serialization.</param>
	protected ManagementException(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementException" />              class with a specified error message.          </summary>
	/// <param name="message">The message that describes the error. </param>
	public ManagementException(string message)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes an empty new instance of the <see cref="T:System.Management.ManagementException" /> class. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a catch block that handles the inner exception.</summary>
	/// <param name="message">The message that describes the error. </param>
	/// <param name="innerException">The exception that is the cause of the current exception.</param>
	public ManagementException(string message, Exception innerException)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Populates the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the <see cref="T:System.Management.ManagementException" />.          </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> destination for this serialization.</param>
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
