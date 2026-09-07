namespace System.Management;

/// <summary>Represents a WQL ASSOCIATORS OF data query. It can be used for both instances and schema queries.           </summary>
public class RelatedObjectQuery : WqlObjectQuery
{
	/// <summary>Gets or sets a value indicating that for all instances that adhere to the query, only their class definitions be returned. This parameter is only valid for instance queries.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating that for all instances that adhere to the query, only their class definitions are to be returned.</returns>
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

	/// <summary>Gets or sets a value indicating whether this is a schema query or an instance query.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether this is a schema query.</returns>
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

	/// <summary>Gets or sets the class of the endpoint objects (the related class).          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the related class name.</returns>
	public string RelatedClass
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

	/// <summary>Gets or sets a qualifier required to be defined on the related objects.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the name of the qualifier required on the related object.</returns>
	public string RelatedQualifier
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

	/// <summary>Gets or sets the role that the related objects returned should be playing in the relationship.          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the role of the related objects.</returns>
	public string RelatedRole
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

	/// <summary>Gets or sets the type of relationship (association).          </summary>
	/// <returns>Returns a <see cref="T:System.String" /> value containing the relationship class name. </returns>
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

	/// <summary>Gets or sets a qualifier required to be defined on the relationship objects.          </summary>
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

	/// <summary>Gets or sets the source object to be used for the query. For instance queries, this is typically an instance path. For schema queries, this is typically a class name.          </summary>
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

	/// <summary>Gets or sets the role that the source object should be playing in the relationship.          </summary>
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelatedObjectQuery" /> class. This is the default constructor.          </summary>
	public RelatedObjectQuery()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelatedObjectQuery" /> class for a schema query using the given set of parameters. This constructor is used for schema queries only: the first parameter must be set to <see langword="true" />                .          </summary>
	/// <param name="isSchemaQuery">
	///       <see langword="true" /> to indicate that this is a schema query; otherwise, <see langword="false" /> .</param>
	/// <param name="sourceObject">The path of the source class.</param>
	/// <param name="relatedClass">The related objects' required base class.</param>
	/// <param name="relationshipClass">The relationship type.</param>
	/// <param name="relatedQualifier">The qualifier required to be present on the related objects.</param>
	/// <param name="relationshipQualifier">The qualifier required to be present on the relationships.</param>
	/// <param name="relatedRole">The role that the related objects are required to play in the relationship.</param>
	/// <param name="thisRole">The role that the source class is required to play in the relationship.</param>
	public RelatedObjectQuery(bool isSchemaQuery, string sourceObject, string relatedClass, string relationshipClass, string relatedQualifier, string relationshipQualifier, string relatedRole, string thisRole)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelatedObjectQuery" /> class. If the specified string can be successfully parsed as a WQL query, it is considered to be the query string; otherwise, it is assumed to be the path of the source object for the query. In this case, the query is assumed to be an instance query.           </summary>
	/// <param name="queryOrSourceObject">The query string or the path of the source object.</param>
	public RelatedObjectQuery(string queryOrSourceObject)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelatedObjectQuery" /> class for the given source object and related class. The query is assumed to be an instance query (as opposed to a schema query).          </summary>
	/// <param name="sourceObject">The path of the source object for this query.</param>
	/// <param name="relatedClass">The related objects' class.</param>
	public RelatedObjectQuery(string sourceObject, string relatedClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.RelatedObjectQuery" /> class for the given set of parameters. The query is assumed to be an instance query (as opposed to a schema query).          </summary>
	/// <param name="sourceObject">The path of the source object.</param>
	/// <param name="relatedClass">The related objects' required class.</param>
	/// <param name="relationshipClass">The relationship type.</param>
	/// <param name="relatedQualifier">The qualifier required to be present on the related objects.</param>
	/// <param name="relationshipQualifier">The qualifier required to be present on the relationships.</param>
	/// <param name="relatedRole">The role that the related objects are required to play in the relationship.</param>
	/// <param name="thisRole">The role that the source object is required to play in the relationship.</param>
	/// <param name="classDefinitionsOnly">
	///       <see langword="true" /> to return only the class definitions of the related objects; otherwise, false .</param>
	public RelatedObjectQuery(string sourceObject, string relatedClass, string relationshipClass, string relatedQualifier, string relationshipQualifier, string relatedRole, string thisRole, bool classDefinitionsOnly)
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
