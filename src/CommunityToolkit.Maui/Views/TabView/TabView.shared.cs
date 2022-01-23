using System.Collections;
using Microsoft.Maui;
using CommunityToolkit.Maui.Core;

namespace IGT.FluidConnect.Controls;

[ContentProperty(nameof(Content))]
public class TabView : ContentView, IDisposable
{
    private bool disposedValue;


    public TabView()
    {
        Content = new StackLayout
        {
            Children = {
                new Label { Text = "Welcome to .NET MAUI!" }
            }
        };
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}