using System.Collections.Specialized;

namespace System.Management;

/// <summary>Represents a WMI event query in WQL format.          </summary>
public class WqlEventQuery : EventQuery
{
	/// <summary>Gets or sets the condition to be applied to events of the specified class.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the condition or conditions in the event query.</returns>
	public string Condition
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the event class to query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the event class in the event query.</returns>
	public string EventClassName
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets properties in the event to be used for grouping events of the same type.          </summary>
	/// <returns>Returns a <see cref="T:System.Collections.Specialized.StringCollection" /> containing the properties in the event to be used for grouping events of the same type.</returns>
	public StringCollection GroupByPropertyList
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the interval to be used for grouping events of the same type.          </summary>
	/// <returns>Returns a <see cref="T:System.TimeSpan" /> value containing the interval used for grouping events of the same type.</returns>
	public TimeSpan GroupWithinInterval
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the condition to be applied to the aggregation of events, based on the number of events received.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the condition applied to the aggregation of events, based on the number of events received.</returns>
	public string HavingCondition
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets  the language of the query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value that contains the query language that the query is written in.</returns>
	public override string QueryLanguage
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the string representing the query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the query.</returns>
	public override string QueryString
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the polling interval to be used in this query.          </summary>
	/// <returns>Returns a <see cref="T:System.TimeSpan" /> value containing the polling interval used in the event query.</returns>
	public TimeSpan WithinInterval
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class. This is the default constructor.          </summary>
	public WqlEventQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class based on the given query string or event class name.          </summary>
	/// <param name="queryOrEventClassName">The string representing either the entire event query or the name of the event class to query. The object will try to parse the string as a valid event query. If unsuccessful, the parser will assume that the parameter represents an event class name.</param>
	public WqlEventQuery(string queryOrEventClassName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class for the specified event class name, with the specified condition.          </summary>
	/// <param name="eventClassName">The name of the event class to query.</param>
	/// <param name="condition">The condition to apply to events of the specified class. </param>
	public WqlEventQuery(string eventClassName, string condition)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class with the specified event class name, condition, and grouping interval.          </summary>
	/// <param name="eventClassName">The name of the event class to query. </param>
	/// <param name="condition">The condition to apply to events of the specified class.</param>
	/// <param name="groupWithinInterval">The specified interval at which WMI sends one <paramref name="aggregate event" />, rather than many events. </param>
	public WqlEventQuery(string eventClassName, string condition, TimeSpan groupWithinInterval)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class with the specified event class name, condition, grouping interval, and grouping properties.          </summary>
	/// <param name="eventClassName">The name of the event class to query. </param>
	/// <param name="condition">The condition to apply to events of the specified class.</param>
	/// <param name="groupWithinInterval">The specified interval at which WMI sends one <paramref name="aggregate event" />, rather than many events.</param>
	/// <param name="groupByPropertyList">The properties in the event class by which the events should be grouped.  </param>
	public WqlEventQuery(string eventClassName, string condition, TimeSpan groupWithinInterval, string[] groupByPropertyList)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class for the specified event class, with the specified latency time.          </summary>
	/// <param name="eventClassName">The name of the event class to query.</param>
	/// <param name="withinInterval">A <see cref="T:System.TimeSpan" /> value specifying the latency acceptable for receiving this event. This value is used in cases where there is no explicit event provider for the query requested, and WMI is required to poll for the condition. This interval is the maximum amount of time that can pass before notification of an event must be delivered.  </param>
	public WqlEventQuery(string eventClassName, TimeSpan withinInterval)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class with the specified event class name, polling interval, and condition.          </summary>
	/// <param name="eventClassName">The name of the event class to query. </param>
	/// <param name="withinInterval">A <see cref="T:System.TimeSpan" /> value specifying the latency acceptable for receiving this event. This value is used in cases where there is no explicit event provider for the query requested and WMI is required to poll for the condition. This interval is the maximum amount of time that can pass before notification of an event must be delivered. </param>
	/// <param name="condition">The condition to apply to events of the specified class. </param>
	public WqlEventQuery(string eventClassName, TimeSpan withinInterval, string condition)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.WqlEventQuery" /> class with the specified event class name, condition, grouping interval, grouping properties, and specified number of events.          </summary>
	/// <param name="eventClassName">The name of the event class on which to be queried.</param>
	/// <param name="withinInterval">A <see cref="T:System.TimeSpan" /> value specifying the latency acceptable for receiving this event. This value is used in cases where there is no explicit event provider for the query requested, and WMI is required to poll for the condition. This interval is the maximum amount of time that can pass before notification of an event must be delivered.</param>
	/// <param name="condition">The condition to apply to events of the specified class. </param>
	/// <param name="groupWithinInterval">The specified interval at which WMI sends one <paramref name="aggregate event" />, rather than many events. </param>
	/// <param name="groupByPropertyList">The properties in the event class by which the events should be grouped. </param>
	/// <param name="havingCondition">The condition to apply to the number of events. </param>
	public WqlEventQuery(string eventClassName, TimeSpan withinInterval, string condition, TimeSpan groupWithinInterval, string[] groupByPropertyList, string havingCondition)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Builds the query string according to the current property values.                       </summary>
	protected internal void BuildQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a copy of the object.          </summary>
	/// <returns>The copied object.             </returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Parses the query string and sets the property values accordingly.                       </summary>
	/// <param name="query">The query string to be parsed.</param>
	protected internal override void ParseQuery(string query)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
