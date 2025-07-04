using System;
using AppKit;
using CoreGraphics;

namespace AvaloniaEmbedPopupTest;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Embedding;
using Avalonia.Platform;

public class EmbeddedAvaloniaView : IDisposable
{
    private readonly EmbeddableControlRoot topLevel;

    private Control content;

    public EmbeddedAvaloniaView()
    {
        this.topLevel = new EmbeddableControlRoot();

        IPlatformHandle? platformHandle = this.topLevel.TryGetPlatformHandle();

        if (platformHandle is IMacOSTopLevelPlatformHandle handle)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            this.AvnView = ObjCRuntime.Runtime.GetNSObject(handle.NSView) as NSView;
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    public NSView AvnView { get; }

    public Control Content
    {
        get => this.content;
        set
        {
            this.content = value;

            this.topLevel.Content = this.content;

            if (this.content is null)
            {
                return;
            }

            this.content.Measure(Size.Infinity);

            this.AvnView.SetFrameSize(new CGSize(981, 574));
            this.topLevel.Prepare();
        }
    }

    public void Dispose()
    {
        this.topLevel.StopRendering();
        this.topLevel.Dispose();
        this.AvnView.Dispose();
    }

    public void Start()
    {
        this.topLevel.StartRendering();
    }
}