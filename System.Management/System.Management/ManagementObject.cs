using System.Runtime.Serialization;

namespace System.Management;

/// <summary>Represents a WMI instance. </summary>
public class ManagementObject : ManagementBaseObject, ICloneable
{
	/// <summary>Gets or sets the path to the object's class.</summary>
	/// <returns>A <see cref="T:System.Management.ManagementPath" /> representing the path to the object's class.</returns>
	public override ManagementPath ClassPath
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets additional information to use when retrieving the object.</summary>
	/// <returns>An <see cref="T:System.Management.ObjectGetOptions" /> to use when retrieving the object.</returns>
	public ObjectGetOptions Options
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

	/// <summary>Gets or sets the object's WMI path.</summary>
	/// <returns>A <see cref="T:System.Management.ManagementPath" /> representing the object's path.</returns>
	public virtual ManagementPath Path
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

	/// <summary>Gets or sets the scope in which this object resides.</summary>
	/// <returns>The scope in which this object resides.</returns>
	public ManagementScope Scope
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class. This is the default constructor.</summary>
	public ManagementObject()
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class for the specified WMI object path. The path is provided as a <see cref="T:System.Management.ManagementPath" />.</summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> that contains a path to a WMI object. </param>
	public ManagementObject(ManagementPath path)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class bound to the specified WMI path, including the specified additional options.</summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> containing the WMI path. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> containing additional options for binding to the WMI object. This parameter could be null if default options are to be used. </param>
	public ManagementObject(ManagementPath path, ObjectGetOptions options)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class bound to the specified WMI path that includes the specified options.</summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> representing the scope in which the WMI object resides. In this version, scopes can only be WMI namespaces. </param>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> representing the WMI path to the manageable object. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> specifying additional options for getting the object. </param>
	public ManagementObject(ManagementScope scope, ManagementPath path, ObjectGetOptions options)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class that is serializable.</summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data. </param>
	/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization. </param>
	protected ManagementObject(SerializationInfo info, StreamingContext context)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class for the specified WMI object path. The path is provided as a string.</summary>
	/// <param name="path">A WMI path. </param>
	public ManagementObject(string path)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class bound to the specified WMI path, including the specified additional options. In this variant, the path can be specified as a string.</summary>
	/// <param name="path">The WMI path to the object. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> representing options to get the specified WMI object. </param>
	public ManagementObject(string path, ObjectGetOptions options)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementObject" /> class bound to the specified WMI path, and includes the specified options. The scope and the path are specified as strings.</summary>
	/// <param name="scopeString">The scope for the WMI object. </param>
	/// <param name="pathString">The WMI object path. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> representing additional options for getting the WMI object. </param>
	public ManagementObject(string scopeString, string pathString, ObjectGetOptions options)
		: base(null, default(StreamingContext))
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a copy of the object.</summary>
	/// <returns>The copied object.</returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location, asynchronously.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> specifying the path to which the object should be copied. </param>
	public void CopyTo(ManagementOperationObserver watcher, ManagementPath path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location, asynchronously.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	/// <param name="path">The path to which the object should be copied. </param>
	/// <param name="options">The options for how the object should be put. </param>
	public void CopyTo(ManagementOperationObserver watcher, ManagementPath path, PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location, asynchronously.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	/// <param name="path">The path to which the object should be copied. </param>
	public void CopyTo(ManagementOperationObserver watcher, string path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location, asynchronously.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	/// <param name="path">The path to which the object should be copied. </param>
	/// <param name="options">The options for how the object should be put. </param>
	public void CopyTo(ManagementOperationObserver watcher, string path, PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location.</summary>
	/// <param name="path">The <see cref="T:System.Management.ManagementPath" /> to which the object should be copied. </param>
	/// <returns>The new path of the copied object.</returns>
	public ManagementPath CopyTo(ManagementPath path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location.</summary>
	/// <param name="path">The <see cref="T:System.Management.ManagementPath" /> to which the object should be copied. </param>
	/// <param name="options">The options for how the object should be put. </param>
	/// <returns>The new path of the copied object.</returns>
	public ManagementPath CopyTo(ManagementPath path, PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location.</summary>
	/// <param name="path">The path to which the object should be copied. </param>
	/// <returns>The new path of the copied object.</returns>
	public ManagementPath CopyTo(string path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the object to a different location.</summary>
	/// <param name="path">The path to which the object should be copied. </param>
	/// <param name="options">The options for how the object should be put. </param>
	/// <returns>The new path of the copied object.</returns>
	public ManagementPath CopyTo(string path, PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Deletes the object.</summary>
	public void Delete()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Deletes the object.</summary>
	/// <param name="options">The options for how to delete the object. </param>
	public void Delete(DeleteOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Deletes the object.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	public void Delete(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Deletes the object.</summary>
	/// <param name="watcher">The object that will receive the results of the operation. </param>
	/// <param name="options">The options for how to delete the object. </param>
	public void Delete(ManagementOperationObserver watcher, DeleteOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Releases all resources used by the Component.</summary>
	public new void Dispose()
	{
	}

	/// <summary>Binds WMI class information to the management object.</summary>
	public void Get()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Binds to the management object asynchronously.</summary>
	/// <param name="watcher">The object to receive the results of the operation as events. </param>
	public void Get(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a <see cref="T:System.Management.ManagementBaseObject" /> representing the list of input parameters for a method.</summary>
	/// <param name="methodName">The name of the method. </param>
	/// <returns>A <see cref="T:System.Management.ManagementBaseObject" /> containing the input parameters to the method.</returns>
	public ManagementBaseObject GetMethodParameters(string methodName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data necessary to deserialize the field represented by this instance.          </summary>
	/// <param name="info">The object to be populated with serialization information.</param>
	/// <param name="context">The location where serialized data will be stored and retrieved.</param>
	protected override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators).</summary>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the related objects.</returns>
	public ManagementObjectCollection GetRelated()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators) asynchronously. This call returns immediately, and a delegate is called when the results are available.</summary>
	/// <param name="watcher">The object to use to return results. </param>
	public void GetRelated(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators).</summary>
	/// <param name="watcher">The object to use to return results. </param>
	/// <param name="relatedClass">The class of related objects. </param>
	public void GetRelated(ManagementOperationObserver watcher, string relatedClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators).</summary>
	/// <param name="watcher">The object to use to return results. </param>
	/// <param name="relatedClass">The class of the related objects. </param>
	/// <param name="relationshipClass">The relationship class of interest. </param>
	/// <param name="relationshipQualifier">The qualifier required to be present on the relationship class. </param>
	/// <param name="relatedQualifier">The qualifier required to be present on the related class. </param>
	/// <param name="relatedRole">The role that the related class is playing in the relationship. </param>
	/// <param name="thisRole">The role that this class is playing in the relationship. </param>
	/// <param name="classDefinitionsOnly">Return only class definitions for the instances that match the query. </param>
	/// <param name="options">Extended options for how to execute the query. </param>
	public void GetRelated(ManagementOperationObserver watcher, string relatedClass, string relationshipClass, string relationshipQualifier, string relatedQualifier, string relatedRole, string thisRole, bool classDefinitionsOnly, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators).</summary>
	/// <param name="relatedClass">A class of related objects. </param>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the related objects.</returns>
	public ManagementObjectCollection GetRelated(string relatedClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of objects related to the object (associators).</summary>
	/// <param name="relatedClass">The class of the related objects. </param>
	/// <param name="relationshipClass">The relationship class of interest. </param>
	/// <param name="relationshipQualifier">The qualifier required to be present on the relationship class. </param>
	/// <param name="relatedQualifier">The qualifier required to be present on the related class. </param>
	/// <param name="relatedRole">The role that the related class is playing in the relationship. </param>
	/// <param name="thisRole">The role that this class is playing in the relationship. </param>
	/// <param name="classDefinitionsOnly">When this method returns, it contains only class definitions for the instances that match the query. </param>
	/// <param name="options">Extended options for how to execute the query. </param>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the related objects.</returns>
	public ManagementObjectCollection GetRelated(string relatedClass, string relationshipClass, string relationshipQualifier, string relatedQualifier, string relatedRole, string thisRole, bool classDefinitionsOnly, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the association objects.</returns>
	public ManagementObjectCollection GetRelationships()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <param name="watcher">The object to use to return results. </param>
	public void GetRelationships(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <param name="watcher">The object to use to return results. </param>
	/// <param name="relationshipClass">The associations to include. </param>
	public void GetRelationships(ManagementOperationObserver watcher, string relationshipClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <param name="watcher">The object to use to return results. </param>
	/// <param name="relationshipClass">The type of relationship of interest. </param>
	/// <param name="relationshipQualifier">The qualifier to be present on the relationship. </param>
	/// <param name="thisRole">The role of this object in the relationship. </param>
	/// <param name="classDefinitionsOnly">When this method returns, it contains only the class definitions for the result set. </param>
	/// <param name="options">The extended options for the query execution. </param>
	public void GetRelationships(ManagementOperationObserver watcher, string relationshipClass, string relationshipQualifier, string thisRole, bool classDefinitionsOnly, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <param name="relationshipClass">The associations to include. </param>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the association objects.</returns>
	public ManagementObjectCollection GetRelationships(string relationshipClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets a collection of associations to the object.</summary>
	/// <param name="relationshipClass">The type of relationship of interest. </param>
	/// <param name="relationshipQualifier">The qualifier to be present on the relationship. </param>
	/// <param name="thisRole">The role of this object in the relationship. </param>
	/// <param name="classDefinitionsOnly">When this method returns, it contains only the class definitions for the result set. </param>
	/// <param name="options">The extended options for the query execution. </param>
	/// <returns>A <see cref="T:System.Management.ManagementObjectCollection" /> containing the association objects.</returns>
	public ManagementObjectCollection GetRelationships(string relationshipClass, string relationshipQualifier, string thisRole, bool classDefinitionsOnly, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes a method on the object, asynchronously.</summary>
	/// <param name="watcher">A <see cref="T:System.Management.ManagementOperationObserver" /> used to handle the asynchronous execution's progress and results. </param>
	/// <param name="methodName">The name of the method to be executed. </param>
	/// <param name="inParameters">A <see cref="T:System.Management.ManagementBaseObject" /> containing the input parameters for the method. </param>
	/// <param name="options">An <see cref="T:System.Management.InvokeMethodOptions" /> containing additional options used to execute the method. </param>
	public void InvokeMethod(ManagementOperationObserver watcher, string methodName, ManagementBaseObject inParameters, InvokeMethodOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes a method on the object, asynchronously.</summary>
	/// <param name="watcher">The object to receive the results of the operation. </param>
	/// <param name="methodName">The name of the method to execute. </param>
	/// <param name="args">An array containing parameter values. </param>
	public void InvokeMethod(ManagementOperationObserver watcher, string methodName, object[] args)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes a method on the WMI object. The input and output parameters are represented as <see cref="T:System.Management.ManagementBaseObject" /> objects.</summary>
	/// <param name="methodName">The name of the method to execute. </param>
	/// <param name="inParameters">A <see cref="T:System.Management.ManagementBaseObject" /> holding the input parameters to the method. </param>
	/// <param name="options">An <see cref="T:System.Management.InvokeMethodOptions" /> containing additional options for the execution of the method. </param>
	/// <returns>A <see cref="T:System.Management.ManagementBaseObject" /> containing the output parameters and return value of the executed method.</returns>
	public ManagementBaseObject InvokeMethod(string methodName, ManagementBaseObject inParameters, InvokeMethodOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Invokes a method on the object.</summary>
	/// <param name="methodName">The name of the method to execute. </param>
	/// <param name="args">An array containing parameter values. </param>
	/// <returns>The object value returned by the method.</returns>
	public object InvokeMethod(string methodName, object[] args)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Commits the changes to the object.</summary>
	/// <returns>A <see cref="T:System.Management.ManagementPath" /> containing the path to the committed object.</returns>
	public ManagementPath Put()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Commits the changes to the object, asynchronously.</summary>
	/// <param name="watcher">A <see cref="T:System.Management.ManagementOperationObserver" /> used to handle the progress and results of the asynchronous operation. </param>
	public void Put(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Commits the changes to the object asynchronously and using the specified options.</summary>
	/// <param name="watcher">A <see cref="T:System.Management.ManagementOperationObserver" /> used to handle the progress and results of the asynchronous operation. </param>
	/// <param name="options">A <see cref="T:System.Management.PutOptions" /> used to specify additional options for the commit operation. </param>
	public void Put(ManagementOperationObserver watcher, PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Commits the changes to the object.</summary>
	/// <param name="options">The options for how to commit the changes. </param>
	/// <returns>A <see cref="T:System.Management.ManagementPath" /> containing the path to the committed object.</returns>
	public ManagementPath Put(PutOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the full path of the object. This is an override of the default object implementation.</summary>
	/// <returns>The full path of the object.</returns>
	public override string ToString()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
