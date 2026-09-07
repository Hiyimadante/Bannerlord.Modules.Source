namespace System.Management;

/// <summary>Represents the method that will handle the <see cref="E:System.Management.ManagementEventWatcher.EventArrived" /> event.          </summary>
/// <param name="sender">The instance of the object for which to invoke this method.</param>
/// <param name="e">The <see cref="T:System.Management.EventArrivedEventArgs" /> that specifies the reason the event was invoked.</param>
public delegate void EventArrivedEventHandler(object sender, EventArrivedEventArgs e);
