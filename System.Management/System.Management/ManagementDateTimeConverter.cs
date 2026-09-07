namespace System.Management;

/// <summary>Provides methods to convert DMTF datetime and time intervals to CLR-compliant <see cref="T:System.DateTime" /> and <see cref="T:System.TimeSpan" /> format and vice versa.                           </summary>
public sealed class ManagementDateTimeConverter
{
	internal ManagementDateTimeConverter()
	{
	}

	/// <summary>Converts a given DMTF datetime to <see cref="T:System.DateTime" />. The returned <see cref="T:System.DateTime" /> will be in the current time zone of the system.          </summary>
	/// <param name="dmtfDate">A string representing the datetime in DMTF format.</param>
	/// <returns>A <see cref="T:System.DateTime" /> that represents the given DMTF datetime.</returns>
	public static DateTime ToDateTime(string dmtfDate)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Converts a given <see cref="T:System.DateTime" /> to DMTF datetime format.          </summary>
	/// <param name="date">A <see cref="T:System.DateTime" /> representing the datetime to be converted to DMTF datetime.</param>
	/// <returns>A string that represents the DMTF datetime for the given <see cref="T:System.DateTime" />.</returns>
	public static string ToDmtfDateTime(DateTime date)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Converts a given <see cref="T:System.TimeSpan" /> to DMTF time interval.          </summary>
	/// <param name="timespan">A <see cref="T:System.TimeSpan" /> representing the datetime to be converted to DMTF time interval.             </param>
	/// <returns>A string that represents the DMTF time interval for the given <see cref="T:System.TimeSpan" />.</returns>
	public static string ToDmtfTimeInterval(TimeSpan timespan)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Converts a given DMTF time interval to a <see cref="T:System.TimeSpan" />.          </summary>
	/// <param name="dmtfTimespan">A string representation of the DMTF time interval.</param>
	/// <returns>A <see cref="T:System.TimeSpan" /> that represents the given DMTF time interval.</returns>
	public static TimeSpan ToTimeSpan(string dmtfTimespan)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
