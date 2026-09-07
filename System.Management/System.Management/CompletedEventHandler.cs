namespace System.Management;

/// <summary>Represents the method that will handle the <see cref="E:System.Management.ManagementOperationObserver.Completed" /> event.     </summary>
/// <param name="sender">The instance of the object for which to invoke this method.</param>
/// <param name="e">The <see cref="T:System.Management.CompletedEventArgs" /> that specifies the reason the event was invoked.</param>
public delegate void CompletedEventHandler(object sender, CompletedEventArgs e);
