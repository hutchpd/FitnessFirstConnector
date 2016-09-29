Imports Hardcodet.Wpf.TaskbarNotification

Public Class HelloWorldCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Debug.WriteLine("Hello", "World")
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class

Class Application
    Private notifyIcon As TaskbarIcon
    Private WebSocket As Server

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim SysTray As New ContextMenu

        SysTray.Items.Add(New MenuItem With {.Header = "Pointless menu", .Command = New HelloWorldCommand})

        'create the notifyicon (it's a resource declared in NotifyIconResources.xaml
        notifyIcon = New TaskbarIcon With {
            .IconSource = New BitmapImage(New Uri("pack://application:,,,/FitnessFirstConnector;component/Red.ico")),
            .ToolTipText = "Fitness First Connection thingie",
            .DoubleClickCommand = New HelloWorldCommand,
            .ContextMenu = SysTray}

        notifyIcon = notifyIcon

        WebSocket = New Server

    End Sub

    Protected Overrides Sub OnExit(e As ExitEventArgs)
        notifyIcon.Dispose()
        'the icon would clean up automatically, but this is cleaner
        MyBase.OnExit(e)
    End Sub
    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

End Class
