namespace System.Management;

/// <summary>Represents a WQL REFERENCES OF data query.           </summary>
public class RelationshipQuery : WqlObjectQuery
{
	/// <summary>Gets or sets a value indicating that only the class definitions of the relevant relationship objects be returned.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating that only the class definitions of the relevant relationship objects be returned.</returns>
	public bool ClassDefinitionsOnly
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

	/// <summary>Gets or sets a value indicating whether this query is a schema query or an instance query.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether this query is a schema query.</returns>
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

	/// <summary>Gets or sets the class of the relationship objects wanted in the query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the relationship class name.</returns>
	public string RelationshipClass
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

	/// <summary>Gets or sets a qualifier required on the relationship objects.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the qualifier required on the relationship objects.</returns>
	public string RelationshipQualifier
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

	/// <summary>Gets or sets the source object for this query.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the path of the object to be used for the query.</returns>
	public string SourceObject
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

	/// <summary>Gets or sets the role of the source object in the relationship.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the role of this object.</returns>
	public string ThisRole
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelationshipQuery" /> class. This is the default constructor.          </summary>
	public RelationshipQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelationshipQuery" /> class for a schema query using the given set of parameters. This constructor is used for schema queries only, so the first parameter must be true.          </summary>
	/// <param name="isSchemaQuery">
	///       <see langword="true" /> to indicate that this is a schema query; otherwise, <see langword="false" />.</param>
	/// <param name="sourceObject">The path of the source class for this query.</param>
	/// <param name="relationshipClass">The type of relationship for which to query.</param>
	/// <param name="relationshipQualifier">A qualifier required to be present on the relationship class.</param>
	/// <param name="thisRole">The role that the source class is required to play in the relationship.</param>
	public RelationshipQuery(bool isSchemaQuery, string sourceObject, string relationshipClass, string relationshipQualifier, string thisRole)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelationshipQuery" /> class. If the specified string can be successfully parsed as a WQL query, it is considered to be the query string; otherwise, it is assumed to be the path of the source object for the query. In this case, the query is assumed to be an instances query.           </summary>
	/// <param name="queryOrSourceObject">The query string or the class name for this query.</param>
	public RelationshipQuery(string queryOrSourceObject)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelationshipQuery" /> class for the given source object and relationship class. The query is assumed to be an instance query (as opposed to a schema query).          </summary>
	/// <param name="sourceObject"> The path of the source object for this query.</param>
	/// <param name="relationshipClass"> The type of relationship for which to query.</param>
	public RelationshipQuery(string sourceObject, string relationshipClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelationshipQuery" /> class for the given set of parameters. The query is assumed to be an instance query (as opposed to a schema query).          </summary>
	/// <param name="sourceObject">The path of the source object for this query.</param>
	/// <param name="relationshipClass">The type of relationship for which to query.</param>
	/// <param name="relationshipQualifier">A qualifier required to be present on the relationship object.</param>
	/// <param name="thisRole">The role that the source object is required to play in the relationship.</param>
	/// <param name="classDefinitionsOnly">When this method returns, it contains a Boolean that indicates that only class definitions for the resulting objects are returned.</param>
	public RelationshipQuery(string sourceObject, string relationshipClass, string relationshipQualifier, string thisRole, bool classDefinitionsOnly)
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
