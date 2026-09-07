namespace System.Management;

/// <summary>Describes the enumeration of all WMI error codes that are currently defined. </summary>
public enum ManagementStatus
{
	/// <summary>The call failed.</summary>
	Failed = -2147217407,
	/// <summary>The object could not be found. </summary>
	NotFound = -2147217406,
	/// <summary>The current user does not have permission to perform the action. </summary>
	AccessDenied = -2147217405,
	/// <summary>The provider failed after initialization. </summary>
	ProviderFailure = -2147217404,
	/// <summary>A type mismatch occurred. </summary>
	TypeMismatch = -2147217403,
	/// <summary>There was not enough memory for the operation. </summary>
	OutOfMemory = -2147217402,
	/// <summary>The context object is not valid.</summary>
	InvalidContext = -2147217401,
	/// <summary>One of the parameters to the call is not correct. </summary>
	InvalidParameter = -2147217400,
	/// <summary>The resource, typically a remote server, is not currently available. </summary>
	NotAvailable = -2147217399,
	/// <summary>An internal, critical, and unexpected error occurred. Report this error to Microsoft Technical Support.</summary>
	CriticalError = -2147217398,
	/// <summary>One or more network packets were corrupted during a remote session.</summary>
	InvalidStream = -2147217397,
	/// <summary>The feature or operation is not supported. </summary>
	NotSupported = -2147217396,
	/// <summary>The specified superclass is not valid. </summary>
	InvalidSuperclass = -2147217395,
	/// <summary>The specified namespace could not be found. </summary>
	InvalidNamespace = -2147217394,
	/// <summary>The specified instance is not valid. </summary>
	InvalidObject = -2147217393,
	/// <summary>The specified class is not valid. </summary>
	InvalidClass = -2147217392,
	/// <summary>A provider referenced in the schema does not have a corresponding registration. </summary>
	ProviderNotFound = -2147217391,
	/// <summary>A provider referenced in the schema has an incorrect or incomplete registration. </summary>
	InvalidProviderRegistration = -2147217390,
	/// <summary>COM cannot locate a provider referenced in the schema. </summary>
	ProviderLoadFailure = -2147217389,
	/// <summary>A component, such as a provider, failed to initialize for internal reasons. </summary>
	InitializationFailure = -2147217388,
	/// <summary> A networking error that prevents normal operation has occurred. </summary>
	TransportFailure = -2147217387,
	/// <summary>The requested operation is not valid. This error usually applies to invalid attempts to delete classes or properties. </summary>
	InvalidOperation = -2147217386,
	/// <summary>The query was not syntactically valid. </summary>
	InvalidQuery = -2147217385,
	/// <summary>The requested query language is not supported.</summary>
	InvalidQueryType = -2147217384,
	/// <summary>In a put operation, the wbemChangeFlagCreateOnly flag was specified, but the instance already exists.</summary>
	AlreadyExists = -2147217383,
	/// <summary>The add operation cannot be performed on the qualifier because the owning object does not permit overrides.</summary>
	OverrideNotAllowed = -2147217382,
	/// <summary>The user attempted to delete a qualifier that was not owned. The qualifier was inherited from a parent class. </summary>
	PropagatedQualifier = -2147217381,
	/// <summary>The user attempted to delete a property that was not owned. The property was inherited from a parent class. </summary>
	PropagatedProperty = -2147217380,
	/// <summary>The client made an unexpected and illegal sequence of calls. </summary>
	Unexpected = -2147217379,
	/// <summary>The user requested an illegal operation, such as spawning a class from an instance.</summary>
	IllegalOperation = -2147217378,
	/// <summary>There was an illegal attempt to specify a key qualifier on a property that cannot be a key. The keys are specified in the class definition for an object and cannot be altered on a per-instance basis.</summary>
	CannotBeKey = -2147217377,
	/// <summary>The current object is not a valid class definition. Either it is incomplete, or it has not been registered with WMI using <see cref="M:System.Management.ManagementObject.Put" />().</summary>
	IncompleteClass = -2147217376,
	/// <summary>Reserved for future use. </summary>
	InvalidSyntax = -2147217375,
	/// <summary>Reserved for future use. </summary>
	NondecoratedObject = -2147217374,
	/// <summary>The property that you are attempting to modify is read-only.</summary>
	ReadOnly = -2147217373,
	/// <summary>The provider cannot perform the requested operation, such as requesting a query that is too complex, retrieving an instance, creating or updating a class, deleting a class, or enumerating a class. </summary>
	ProviderNotCapable = -2147217372,
	/// <summary>An attempt was made to make a change that would invalidate a derived class.</summary>
	ClassHasChildren = -2147217371,
	/// <summary>An attempt has been made to delete or modify a class that has instances. </summary>
	ClassHasInstances = -2147217370,
	/// <summary>Reserved for future use. </summary>
	QueryNotImplemented = -2147217369,
	/// <summary>A value of null was specified for a property that may not be null, such as one that is marked by a Key, Indexed, or Not_Null qualifier.</summary>
	IllegalNull = -2147217368,
	/// <summary>The value provided for a qualifier was not a legal qualifier type.</summary>
	InvalidQualifierType = -2147217367,
	/// <summary>The CIM type specified for a property is not valid. </summary>
	InvalidPropertyType = -2147217366,
	/// <summary>The request was made with an out-of-range value, or is incompatible with the type. </summary>
	ValueOutOfRange = -2147217365,
	/// <summary>An illegal attempt was made to make a class singleton, such as when the class is derived from a non-singleton class.</summary>
	CannotBeSingleton = -2147217364,
	/// <summary>The CIM type specified is not valid. </summary>
	InvalidCimType = -2147217363,
	/// <summary>The requested method is not available. </summary>
	InvalidMethod = -2147217362,
	/// <summary>The parameters provided for the method are not valid. </summary>
	InvalidMethodParameters = -2147217361,
	/// <summary>There was an attempt to get qualifiers on a system property. </summary>
	SystemProperty = -2147217360,
	/// <summary>The property type is not recognized. </summary>
	InvalidProperty = -2147217359,
	/// <summary>An asynchronous process has been canceled internally or by the user. Note that because of the timing and nature of the asynchronous operation, the operation may not have been truly canceled. </summary>
	CallCanceled = -2147217358,
	/// <summary>The user has requested an operation while WMI is in the process of closing.</summary>
	ShuttingDown = -2147217357,
	/// <summary>An attempt was made to reuse an existing method name from a superclass, and the signatures did not match. </summary>
	PropagatedMethod = -2147217356,
	/// <summary>One or more parameter values, such as a query text, is too complex or unsupported. WMI is requested to retry the operation with simpler parameters. </summary>
	UnsupportedParameter = -2147217355,
	/// <summary>A parameter was missing from the method call. </summary>
	MissingParameterID = -2147217354,
	/// <summary>A method parameter has an invalid ID qualifier. </summary>
	InvalidParameterID = -2147217353,
	/// <summary>One or more of the method parameters have ID qualifiers that are out of sequence. </summary>
	NonconsecutiveParameterIDs = -2147217352,
	/// <summary>The return value for a method has an ID qualifier. </summary>
	ParameterIDOnRetval = -2147217351,
	/// <summary>The specified object path was invalid. </summary>
	InvalidObjectPath = -2147217350,
	/// <summary>There is not enough free disk space to continue the operation. </summary>
	OutOfDiskSpace = -2147217349,
	/// <summary>The supplied buffer was too small to hold all the objects in the enumerator or to read a string property. </summary>
	BufferTooSmall = -2147217348,
	/// <summary>The provider does not support the requested put operation. </summary>
	UnsupportedPutExtension = -2147217347,
	/// <summary>An object with an incorrect type or version was encountered during marshaling. </summary>
	UnknownObjectType = -2147217346,
	/// <summary>A packet with an incorrect type or version was encountered during marshaling. </summary>
	UnknownPacketType = -2147217345,
	/// <summary>The packet has an unsupported version. </summary>
	MarshalVersionMismatch = -2147217344,
	/// <summary>The packet is corrupted.</summary>
	MarshalInvalidSignature = -2147217343,
	/// <summary>An attempt has been made to mismatch qualifiers, such as putting [ManagementKey] on an object instead of a property. </summary>
	InvalidQualifier = -2147217342,
	/// <summary>A duplicate parameter has been declared in a CIM method. </summary>
	InvalidDuplicateParameter = -2147217341,
	/// <summary>Reserved for future use. </summary>
	TooMuchData = -2147217340,
	/// <summary>The delivery of an event has failed. The provider may choose to re-raise the event.</summary>
	ServerTooBusy = -2147217339,
	/// <summary>The specified flavor was invalid. </summary>
	InvalidFlavor = -2147217338,
	/// <summary>An attempt has been made to create a reference that is circular (for example, deriving a class from itself). </summary>
	CircularReference = -2147217337,
	/// <summary>The specified class is not supported. </summary>
	UnsupportedClassUpdate = -2147217336,
	/// <summary>An attempt was made to change a key when instances or derived classes are already using the key. </summary>
	CannotChangeKeyInheritance = -2147217335,
	/// <summary>An attempt was made to change an index when instances or derived classes are already using the index. </summary>
	CannotChangeIndexInheritance = -2147217328,
	/// <summary>An attempt was made to create more properties than the current version of the class supports. </summary>
	TooManyProperties = -2147217327,
	/// <summary>A property was redefined with a conflicting type in a derived class. </summary>
	UpdateTypeMismatch = -2147217326,
	/// <summary>An attempt was made in a derived class to override a non-overrideable qualifier. </summary>
	UpdateOverrideNotAllowed = -2147217325,
	/// <summary>A method was redeclared with a conflicting signature in a derived class. </summary>
	UpdatePropagatedMethod = -2147217324,
	/// <summary>An attempt was made to execute a method not marked with [implemented] in any relevant class. </summary>
	MethodNotImplemented = -2147217323,
	/// <summary>An attempt was made to execute a method marked with [disabled]. </summary>
	MethodDisabled = -2147217322,
	/// <summary>The refresher is busy with another operation. </summary>
	RefresherBusy = -2147217321,
	/// <summary>The filtering query is syntactically invalid. </summary>
	UnparsableQuery = -2147217320,
	/// <summary>The FROM clause of a filtering query references a class that is not an event class. </summary>
	NotEventClass = -2147217319,
	/// <summary>A GROUP BY clause was used without the corresponding GROUP WITHIN clause. </summary>
	MissingGroupWithin = -2147217318,
	/// <summary>A GROUP BY clause was used. Aggregation on all properties is not supported. </summary>
	MissingAggregationList = -2147217317,
	/// <summary>Dot notation was used on a property that is not an embedded object. </summary>
	PropertyNotAnObject = -2147217316,
	/// <summary>A GROUP BY clause references a property that is an embedded object without using dot notation. </summary>
	AggregatingByObject = -2147217315,
	/// <summary>An event provider registration query (__EventProviderRegistration) did not specify the classes for which events were provided. </summary>
	UninterpretableProviderQuery = -2147217313,
	/// <summary>An request was made to back up or restore the repository while WinMgmt.exe was using it. </summary>
	BackupRestoreWinmgmtRunning = -2147217312,
	/// <summary>The asynchronous delivery queue overflowed from the event consumer being too slow. </summary>
	QueueOverflow = -2147217311,
	/// <summary>The operation failed because the client did not have the necessary security privilege. </summary>
	PrivilegeNotHeld = -2147217310,
	/// <summary>The operator is not valid for this property type.</summary>
	InvalidOperator = -2147217309,
	/// <summary>The user specified a user name, password, or authority on a local connection. The user must use an empty user name and password and rely on default security. </summary>
	LocalCredentials = -2147217308,
	/// <summary>The class was made abstract when its superclass is not abstract. </summary>
	CannotBeAbstract = -2147217307,
	/// <summary>An amended object was used in a put operation without the WBEM_FLAG_USE_AMENDED_QUALIFIERS flag being specified. </summary>
	AmendedObject = -2147217306,
	/// <summary>The client was not retrieving objects quickly enough from an enumeration. </summary>
	ClientTooSlow = -2147217305,
	/// <summary>The provider registration overlaps with the system event domain. </summary>
	RegistrationTooBroad = -2147213311,
	/// <summary>A WITHIN clause was not used in this query. </summary>
	RegistrationTooPrecise = -2147213310,
	/// <summary>The operation was successful. </summary>
	NoError = 0,
	/// <summary>This value is returned when no more objects are available, the number of objects returned is less than the number requested, or at the end of an enumeration. It is also returned when the method is called with a value of 0 for the parameter.</summary>
	False = 1,
	/// <summary>An overridden property was deleted. This value is returned to signal that the original, non-overridden value has been restored as a result of the deletion.</summary>
	ResetToDefault = 262146,
	/// <summary>The compared items (such as objects and classes) are not identical.</summary>
	Different = 262147,
	/// <summary>A call timed out. This is not an error condition; therefore, some results may have been returned.</summary>
	Timedout = 262148,
	/// <summary>No more data is available from the enumeration; the user should terminate the enumeration. </summary>
	NoMoreData = 262149,
	/// <summary>The operation was canceled.</summary>
	OperationCanceled = 262150,
	/// <summary>A request is still in progress; however, the results are not yet available.</summary>
	Pending = 262151,
	/// <summary>More than one copy of the same object was detected in the result set of an enumeration. </summary>
	DuplicateObjects = 262152,
	/// <summary>The user did not receive all of the requested objects because of inaccessible resources (other than security violations).</summary>
	PartialResults = 262160
}
