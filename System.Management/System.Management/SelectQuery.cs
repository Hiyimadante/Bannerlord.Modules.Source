using System.Collections.Specialized;

namespace System.Management;

/// <summary>Represents a WQL SELECT data query.          </summary>
public class SelectQuery : WqlObjectQuery
{
	/// <summary>Gets or sets the class name to be selected from in the query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the class in the query.</returns>
	public string ClassName
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

	/// <summary>Gets or sets the condition to be applied in the SELECT query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the condition to be applied to the SELECT query.</returns>
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

	/// <summary>Gets or sets a value indicating whether this query is a schema query or an instances query.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the query is a schema query.</returns>
	public bool IsSchemaQuery
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

	/// <summary>Gets or sets the query in the <see cref="T:System.Management.SelectQuery" /> object, in string form.          </summary>
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

	/// <summary>Ggets or sets an array of property names to be selected in the query.          </summary>
	/// <returns>Returns a <see cref="T:System.Collections.Specialized.StringCollection" /> containing the names of the properties to be selected in the query.</returns>
	public StringCollection SelectedProperties
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.SelectQuery" /> class. This is the default constructor.          </summary>
	public SelectQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.SelectQuery" /> class for a schema query, optionally specifying a condition.          </summary>
	/// <param name="isSchemaQuery">
	///       <see langword="true" /> to indicate that this is a schema query; otherwise, <see langword="false" />. A <see langword="false" /> value is invalid in this constructor.</param>
	/// <param name="condition">The condition to be applied to form the result set of classes. </param>
	public SelectQuery(bool isSchemaQuery, string condition)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.SelectQuery" /> class for the specified query or the specified class name.          </summary>
	/// <param name="queryOrClassName">The entire query or the class name to use in the query. The parser in this class attempts to parse the string as a valid WQL SELECT query. If the parser is unsuccessful, it assumes the string is a class name.</param>
	public SelectQuery(string queryOrClassName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.SelectQuery" /> class with the specified class name and condition.          </summary>
	/// <param name="className">The name of the class to select in the query.</param>
	/// <param name="condition">The condition to be applied in the query. </param>
	public SelectQuery(string className, string condition)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.SelectQuery" /> class with the specified class name and condition, selecting only the specified properties.          </summary>
	/// <param name="className">The name of the class from which to select.</param>
	/// <param name="condition">The condition to be applied to instances of the selected class. </param>
	/// <param name="selectedProperties">An array of property names to be returned in the query results. </param>
	public SelectQuery(string className, string condition, string[] selectedProperties)
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
