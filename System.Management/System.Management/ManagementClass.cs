using System.CodeDom;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace System.Management;

/// <summary>Represents a Common Information Model (CIM) management class. A management class is a WMI class such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. The members of this class enable you to access WMI data using a specific WMI class path. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
public class ManagementClass : ManagementObject
{
	/// <summary>Gets an array containing all WMI classes in the inheritance hierarchy from this class to the top of the hierarchy.</summary>
	/// <returns>A string collection containing the names of all WMI classes in the inheritance hierarchy of this class.</returns>
	public StringCollection Derivation
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets a collection of <see cref="T:System.Management.MethodData" /> objects that represent the methods defined in the WMI class.</summary>
	/// <returns>A <see cref="T:System.Management.MethodDataCollection" /> representing the methods defined in the WMI class.</returns>
	public MethodDataCollection Methods
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets or sets the path of the WMI class to which the <see cref="T:System.Management.ManagementClass" /> object is bound.</summary>
	/// <returns>The path of the object's class.</returns>
	public override ManagementPath Path
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

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class. This is the default constructor.</summary>
	public ManagementClass()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> specifying the WMI class to which to bind. The parameter must specify a WMI class path. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library. </param>
	public ManagementClass(ManagementPath path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class initialized to the given WMI class path using the specified options. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> instance representing the WMI class path. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> representing the options to use when retrieving this class. </param>
	public ManagementClass(ManagementPath path, ObjectGetOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class for the specified WMI class in the specified scope and with the specified options. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="scope">A <see cref="T:System.Management.ManagementScope" /> that specifies the scope (server and namespace) where the WMI class resides. </param>
	/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> that represents the path to the WMI class in the specified scope. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.  </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> that specifies the options to use when retrieving the WMI class. </param>
	public ManagementClass(ManagementScope scope, ManagementPath path, ObjectGetOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class from the specified instances of the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> and <see cref="T:System.Runtime.Serialization.StreamingContext" /> classes.</summary>
	/// <param name="info">An instance of the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> class containing the information required to serialize the new <see cref="T:System.Management.ManagementClass" />.</param>
	/// <param name="context">An instance of the <see cref="T:System.Runtime.Serialization.StreamingContext" /> class containing the source of the serialized stream associated with the new <see cref="T:System.Management.ManagementClass" />.</param>
	protected ManagementClass(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class initialized to the given path. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="path">The path to the WMI class. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</param>
	public ManagementClass(string path)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class initialized to the given WMI class path using the specified options. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="path">The path to the WMI class. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> representing the options to use when retrieving the WMI class. </param>
	public ManagementClass(string path, ObjectGetOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementClass" /> class for the specified WMI class, in the specified scope, and with the specified options. The class represents a Common Information Model (CIM) management class from WMI such as Win32_LogicalDisk, which can represent a disk drive, and Win32_Process, which represents a process such as Notepad.exe. For more information, see "Win32 Classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</summary>
	/// <param name="scope">The scope in which the WMI class resides. </param>
	/// <param name="path">The path to the WMI class within the specified scope. The class represents a CIM management class from WMI. CIM classes represent management information including hardware, software, processes, and so on. For more information about the CIM classes available in Windows, see "Win32 classes" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library. </param>
	/// <param name="options">An <see cref="T:System.Management.ObjectGetOptions" /> that specifies the options to use when retrieving the WMI class. </param>
	public ManagementClass(string scope, string path, ObjectGetOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.</summary>
	/// <returns>The cloned object.</returns>
	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the WMI class.</summary>
	/// <returns>A <see cref="T:System.Management.ManagementObject" /> that represents a new instance of the WMI class.</returns>
	public ManagementObject CreateInstance()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Derives a new class from this class.</summary>
	/// <param name="newClassName">The name of the new class to be derived. </param>
	/// <returns>A new <see cref="T:System.Management.ManagementClass" /> that represents a new WMI class derived from the original class.</returns>
	public ManagementClass Derive(string newClassName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all instances of the class.</summary>
	/// <returns>A collection of the <see cref="T:System.Management.ManagementObject" /> objects representing the instances of the class.</returns>
	public ManagementObjectCollection GetInstances()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all instances of the class using the specified options.</summary>
	/// <param name="options">The additional operation options. </param>
	/// <returns>A collection of the <see cref="T:System.Management.ManagementObject" /> objects representing the instances of the class, according to the specified options.</returns>
	public ManagementObjectCollection GetInstances(EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all instances of the class, asynchronously.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	public void GetInstances(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all instances of the class, asynchronously, using the specified options.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	/// <param name="options">The specified additional options for getting the instances. </param>
	public void GetInstances(ManagementOperationObserver watcher, EnumerationOptions options)
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

	/// <summary>Retrieves classes related to the WMI class.</summary>
	/// <returns>A collection of the <see cref="T:System.Management.ManagementClass" /> or <see cref="T:System.Management.ManagementObject" /> objects that represents WMI classes or instances related to the WMI class.</returns>
	public ManagementObjectCollection GetRelatedClasses()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves classes related to the WMI class, asynchronously.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	public void GetRelatedClasses(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves classes related to the WMI class, asynchronously, given the related class name.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	/// <param name="relatedClass">The name of the related class. </param>
	public void GetRelatedClasses(ManagementOperationObserver watcher, string relatedClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves classes related to the WMI class, asynchronously, using the specified options.</summary>
	/// <param name="watcher">Handler for progress and results of the asynchronous operation. </param>
	/// <param name="relatedClass">The class from which resulting classes have to be derived. </param>
	/// <param name="relationshipClass">The relationship type which resulting classes must have with the source class. </param>
	/// <param name="relationshipQualifier">This qualifier must be present on the relationship. </param>
	/// <param name="relatedQualifier">This qualifier must be present on the resulting classes. </param>
	/// <param name="relatedRole">The resulting classes must have this role in the relationship. </param>
	/// <param name="thisRole">The source class must have this role in the relationship. </param>
	/// <param name="options">The options for retrieving the resulting classes. </param>
	public void GetRelatedClasses(ManagementOperationObserver watcher, string relatedClass, string relationshipClass, string relationshipQualifier, string relatedQualifier, string relatedRole, string thisRole, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves classes related to the WMI class.</summary>
	/// <param name="relatedClass">The class from which resulting classes have to be derived. </param>
	/// <returns>A collection of classes related to this class.</returns>
	public ManagementObjectCollection GetRelatedClasses(string relatedClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves classes related to the WMI class based on the specified options.</summary>
	/// <param name="relatedClass">The class from which resulting classes have to be derived. </param>
	/// <param name="relationshipClass">The relationship type which resulting classes must have with the source class. </param>
	/// <param name="relationshipQualifier">This qualifier must be present on the relationship. </param>
	/// <param name="relatedQualifier">This qualifier must be present on the resulting classes. </param>
	/// <param name="relatedRole">The resulting classes must have this role in the relationship. </param>
	/// <param name="thisRole">The source class must have this role in the relationship. </param>
	/// <param name="options">The options for retrieving the resulting classes. </param>
	/// <returns>A collection of classes related to this class.</returns>
	public ManagementObjectCollection GetRelatedClasses(string relatedClass, string relationshipClass, string relationshipQualifier, string relatedQualifier, string relatedRole, string thisRole, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate the class to others.</summary>
	/// <returns>A collection of association classes that relate the class to any other class.</returns>
	public ManagementObjectCollection GetRelationshipClasses()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate the class to others, asynchronously.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	public void GetRelationshipClasses(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate the class to the specified WMI class, asynchronously.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	/// <param name="relationshipClass">The WMI class to which all returned relationships should point. </param>
	public void GetRelationshipClasses(ManagementOperationObserver watcher, string relationshipClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate the class according to the specified options, asynchronously.</summary>
	/// <param name="watcher">The handler for progress and results of the asynchronous operation. </param>
	/// <param name="relationshipClass">The class from which all resulting relationship classes must derive. </param>
	/// <param name="relationshipQualifier">The qualifier which the resulting relationship classes must have. </param>
	/// <param name="thisRole">The role which the source class must have in the resulting relationship classes. </param>
	/// <param name="options">The options for retrieving the results. </param>
	public void GetRelationshipClasses(ManagementOperationObserver watcher, string relationshipClass, string relationshipQualifier, string thisRole, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate the class to others, where the endpoint class is the specified class.</summary>
	/// <param name="relationshipClass">The endpoint class for all relationship classes returned. </param>
	/// <returns>A collection of association classes that relate the class to the specified class. For more information about relationship classes, see "ASSOCIATORS OF Statement" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</returns>
	public ManagementObjectCollection GetRelationshipClasses(string relationshipClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves relationship classes that relate this class to others, according to specified options.</summary>
	/// <param name="relationshipClass">All resulting relationship classes must derive from this class. </param>
	/// <param name="relationshipQualifier">Resulting relationship classes must have this qualifier. </param>
	/// <param name="thisRole">The source class must have this role in the resulting relationship classes. </param>
	/// <param name="options">Specifies options for retrieving the results. </param>
	/// <returns>A collection of association classes that relate this class to others, according to the specified options. For more information about relationship classes, see "ASSOCIATORS OF Statement" in the Windows Management Instrumentation documentation in the MSDN Library at http://msdn.microsoft.com/library.</returns>
	public ManagementObjectCollection GetRelationshipClasses(string relationshipClass, string relationshipQualifier, string thisRole, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Generates a strongly-typed class for a given WMI class.</summary>
	/// <param name="includeSystemClassInClassDef">
	///       <see langword="true" /> to include the class for managing system properties; otherwise, <see langword="false" />. </param>
	/// <param name="systemPropertyClass">
	///       <see langword="true" /> to have the generated class manage system properties; otherwise, <see langword="false" />. </param>
	/// <returns>A <see cref="T:System.CodeDom.CodeTypeDeclaration" /> representing the declaration for the strongly-typed class.</returns>
	public CodeTypeDeclaration GetStronglyTypedClassCode(bool includeSystemClassInClassDef, bool systemPropertyClass)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Generates a strongly-typed class for a given WMI class. This function generates code for Visual Basic, C#, JScript, J#, or C++ depending on the input parameters.</summary>
	/// <param name="lang">The language of the code to be generated. This code language comes from the <see cref="T:System.Management.CodeLanguage" /> enumeration.</param>
	/// <param name="filePath">The path of the file where the code is to be written. </param>
	/// <param name="classNamespace">The.NET namespace into which the class should be generated. If this is empty, the namespace will be generated from the WMI namespace. </param>
	/// <returns>
	///     <see langword="true" />, if the method succeeded; otherwise, <see langword="false" />.</returns>
	public bool GetStronglyTypedClassCode(CodeLanguage lang, string filePath, string classNamespace)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all subclasses for the class.</summary>
	/// <returns>A collection of the <see cref="T:System.Management.ManagementObject" /> objects that represent the subclasses of the WMI class.</returns>
	public ManagementObjectCollection GetSubclasses()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves the subclasses of the class using the specified options.</summary>
	/// <param name="options">The specified additional options for retrieving subclasses of the class. </param>
	/// <returns>A collection of the <see cref="T:System.Management.ManagementObject" /> objects representing the subclasses of the WMI class, according to the specified options.</returns>
	public ManagementObjectCollection GetSubclasses(EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the collection of all classes derived from this class, asynchronously.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	public void GetSubclasses(ManagementOperationObserver watcher)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Retrieves all classes derived from this class, asynchronously, using the specified options.</summary>
	/// <param name="watcher">The object to handle the asynchronous operation's progress. </param>
	/// <param name="options">The specified additional options to use in the derived class retrieval. </param>
	public void GetSubclasses(ManagementOperationObserver watcher, EnumerationOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
