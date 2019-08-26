Public Class UserSecurity
    Friend Shared Function Login(userName As String, password As String) As Boolean
        Dim u = "Raphael Policena"
        Dim p = "123456"
        If u Like userName And p Like password Then
            Return True
        End If
        Return False
    End Function
End Class
