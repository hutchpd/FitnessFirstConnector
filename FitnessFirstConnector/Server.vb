
Imports System.Net.Sockets
Imports System.Net
Imports WebSocketSharp

Class Server
    Sub New()
        Using ws = New WebSocket("ws://localhost:8181/")

            ' TODO?: Implement a username and password that the user can set to protect their data
            ' from malicious rowing data theives! Okay maybe we don't need this.
            ' ws.SetCredentials("username", "Password", False)

            Debug.WriteLine("trying to do the thing")

            AddHandler ws.OnMessage, AddressOf doTheThing

            ws.Connect()
            ws.Send("BALUS")

            Debug.WriteLine("doing the thing")

        End Using
    End Sub

    Sub doTheThing(sender As Object, e As MessageEventArgs)
        Debug.WriteLine("Computer says: " + e.Data)
    End Sub

End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
