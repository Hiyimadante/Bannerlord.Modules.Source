using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Management;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string InvalidQuery => GetResourceString("InvalidQuery");

	internal static string InvalidQueryDuplicatedToken => GetResourceString("InvalidQueryDuplicatedToken");

	internal static string InvalidQueryNullToken => GetResourceString("InvalidQueryNullToken");

	internal static string WorkerThreadWakeupFailed => GetResourceString("WorkerThreadWakeupFailed");

	internal static string ClassNameNotInitializedException => GetResourceString("ClassNameNotInitializedException");

	internal static string ClassNameNotFoundException => GetResourceString("ClassNameNotFoundException");

	internal static string CommentAttributeProperty => GetResourceString("CommentAttributeProperty");

	internal static string CommentAutoCommitProperty => GetResourceString("CommentAutoCommitProperty");

	internal static string CommentClassBegin => GetResourceString("CommentClassBegin");

	internal static string CommentConstructors => GetResourceString("CommentConstructors");

	internal static string CommentCreatedClass => GetResourceString("CommentCreatedClass");

	internal static string CommentCreatedWmiNamespace => GetResourceString("CommentCreatedWmiNamespace");

	internal static string CommentCurrentObject => GetResourceString("CommentCurrentObject");

	internal static string CommentDateConversionFunction => GetResourceString("CommentDateConversionFunction");

	internal static string CommentEmbeddedObject => GetResourceString("CommentEmbeddedObject");

	internal static string CommentEnumeratorImplementation => GetResourceString("CommentEnumeratorImplementation");

	internal static string CommentFlagForEmbedded => GetResourceString("CommentFlagForEmbedded");

	internal static string CommentGetInstances => GetResourceString("CommentGetInstances");

	internal static string CommentIsPropNull => GetResourceString("CommentIsPropNull");

	internal static string CommentLateBoundObject => GetResourceString("CommentLateBoundObject");

	internal static string CommentLateBoundProperty => GetResourceString("CommentLateBoundProperty");

	internal static string CommentManagementPath => GetResourceString("CommentManagementPath");

	internal static string CommentManagementScope => GetResourceString("CommentManagementScope");

	internal static string CommentOriginNamespace => GetResourceString("CommentOriginNamespace");

	internal static string CommentPrivateAutoCommit => GetResourceString("CommentPrivateAutoCommit");

	internal static string CommentPrototypeConverter => GetResourceString("CommentPrototypeConverter");

	internal static string CommentResetProperty => GetResourceString("CommentResetProperty");

	internal static string CommentShouldSerialize => GetResourceString("CommentShouldSerialize");

	internal static string CommentStaticManagementScope => GetResourceString("CommentStaticManagementScope");

	internal static string CommentStaticScopeProperty => GetResourceString("CommentStaticScopeProperty");

	internal static string CommentSystemObject => GetResourceString("CommentSystemObject");

	internal static string CommentSystemPropertiesClass => GetResourceString("CommentSystemPropertiesClass");

	internal static string CommentTimeSpanConvertionFunction => GetResourceString("CommentTimeSpanConvertionFunction");

	internal static string CommentToDateTime => GetResourceString("CommentToDateTime");

	internal static string CommentToDmtfDateTime => GetResourceString("CommentToDmtfDateTime");

	internal static string CommentToDmtfTimeInterval => GetResourceString("CommentToDmtfTimeInterval");

	internal static string CommentToTimeSpan => GetResourceString("CommentToTimeSpan");

	internal static string EmbeddedComment => GetResourceString("EmbeddedComment");

	internal static string EmbeddedComment2 => GetResourceString("EmbeddedComment2");

	internal static string EmbeddedComment3 => GetResourceString("EmbeddedComment3");

	internal static string EmbeddedComment4 => GetResourceString("EmbeddedComment4");

	internal static string EmbeddedComment5 => GetResourceString("EmbeddedComment5");

	internal static string EmbeddedComment6 => GetResourceString("EmbeddedComment6");

	internal static string EmbeddedComment7 => GetResourceString("EmbeddedComment7");

	internal static string EmbeddedComment8 => GetResourceString("EmbeddedComment8");

	internal static string EmbeddedCSharpComment1 => GetResourceString("EmbeddedCSharpComment1");

	internal static string EmbeddedCSharpComment10 => GetResourceString("EmbeddedCSharpComment10");

	internal static string EmbeddedCSharpComment11 => GetResourceString("EmbeddedCSharpComment11");

	internal static string EmbeddedCSharpComment12 => GetResourceString("EmbeddedCSharpComment12");

	internal static string EmbeddedCSharpComment13 => GetResourceString("EmbeddedCSharpComment13");

	internal static string EmbeddedCSharpComment14 => GetResourceString("EmbeddedCSharpComment14");

	internal static string EmbeddedCSharpComment15 => GetResourceString("EmbeddedCSharpComment15");

	internal static string EmbeddedCSharpComment2 => GetResourceString("EmbeddedCSharpComment2");

	internal static string EmbeddedCSharpComment3 => GetResourceString("EmbeddedCSharpComment3");

	internal static string EmbeddedCSharpComment4 => GetResourceString("EmbeddedCSharpComment4");

	internal static string EmbeddedCSharpComment5 => GetResourceString("EmbeddedCSharpComment5");

	internal static string EmbeddedCSharpComment6 => GetResourceString("EmbeddedCSharpComment6");

	internal static string EmbeddedCSharpComment7 => GetResourceString("EmbeddedCSharpComment7");

	internal static string EmbeddedCSharpComment8 => GetResourceString("EmbeddedCSharpComment8");

	internal static string EmbeddedCSharpComment9 => GetResourceString("EmbeddedCSharpComment9");

	internal static string EmbeddedVisualBasicComment1 => GetResourceString("EmbeddedVisualBasicComment1");

	internal static string EmbeddedVisualBasicComment10 => GetResourceString("EmbeddedVisualBasicComment10");

	internal static string EmbeddedVisualBasicComment2 => GetResourceString("EmbeddedVisualBasicComment2");

	internal static string EmbeddedVisualBasicComment3 => GetResourceString("EmbeddedVisualBasicComment3");

	internal static string EmbeddedVisualBasicComment4 => GetResourceString("EmbeddedVisualBasicComment4");

	internal static string EmbeddedVisualBasicComment5 => GetResourceString("EmbeddedVisualBasicComment5");

	internal static string EmbeddedVisualBasicComment6 => GetResourceString("EmbeddedVisualBasicComment6");

	internal static string EmbeddedVisualBasicComment7 => GetResourceString("EmbeddedVisualBasicComment7");

	internal static string EmbeddedVisualBasicComment8 => GetResourceString("EmbeddedVisualBasicComment8");

	internal static string EmbeddedVisualBasicComment9 => GetResourceString("EmbeddedVisualBasicComment9");

	internal static string EmptyFilePathException => GetResourceString("EmptyFilePathException");

	internal static string NamespaceNotInitializedException => GetResourceString("NamespaceNotInitializedException");

	internal static string NullFilePathException => GetResourceString("NullFilePathException");

	internal static string UnableToCreateCodeGeneratorException => GetResourceString("UnableToCreateCodeGeneratorException");

	internal static string PlatformNotSupported_SystemManagement => GetResourceString("PlatformNotSupported_SystemManagement");

	internal static string PlatformNotSupported_FullFrameworkRequired => GetResourceString("PlatformNotSupported_FullFrameworkRequired");

	internal static string LoadLibraryFailed => GetResourceString("LoadLibraryFailed");

	internal static string PlatformNotSupported_FrameworkUpdatedRequired => GetResourceString("PlatformNotSupported_FrameworkUpdatedRequired");

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString = null)
	{
		if (UsingResourceKeys())
		{
			return defaultString ?? resourceKey;
		}
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(provider, resourceFormat, args);
		}
		return resourceFormat;
	}
}
