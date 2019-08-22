Namespace Pessoas
    Public Class Pessoa
        Public Property Codigo As Integer
        Public Property Nome As String
        Public Property Cpf As String
        Public Property Uf As String
        Public Property DataDeNascimento As Date

        Public Sub New()
        End Sub

        Public Sub New(ByVal _codigo As Integer, ByVal _nome As String, ByVal _cpf As String, ByVal _uf As String, ByVal _dataNascimento As Date)
            Me.Codigo = _codigo
            Me.Nome = _nome
            Me.Cpf = _cpf
            Me.Uf = _uf
            Me.DataDeNascimento = _dataNascimento
        End Sub

        'Lista de pessoas
        Public Function ListOfPerson() As List(Of Pessoa)
            Dim listaPessoas = New List(Of Pessoa) From {
                New Pessoa(1, "Raphael Policena", "06885400150", "GO", "23/08/1997"),
                New Pessoa(2, "Jefferson", "06885400151", "SP", "25/04/1998"),
                New Pessoa(3, "Miriam", "06885400152", "MT", "18/08/1994"),
                New Pessoa(4, "Janice", "06885400153", "CE", "25/02/1997"),
                New Pessoa(5, "Lena", "06885400154", "TO", "29/08/1980"),
                New Pessoa(6, "Susana", "06885400155", "RS", "28/01/1995"),
                New Pessoa(7, "Jonas", "06885400156", "ES", "01/01/1992"),
                New Pessoa(8, "Jane", "06885400157", "SC", "01/07/1997"),
                New Pessoa(9, "Roberto", "06885400158", "AC", "01/08/1975"),
                New Pessoa(10, "Carlos", "06885400159", "AM", "24/08/1997"),
                New Pessoa(11, "Gina", "06885400160", "MG", "25/09/2019"),
                New Pessoa(12, "Joel", "06885400161", "AL", "27/08/2007"),
                New Pessoa(13, "George", "06885400162", "RJ", "23/08/1997"),
                New Pessoa(14, "Ricardo", "06885400163", "GO", "29/05/1997"),
                New Pessoa(15, "Maria", "06885400164", "RE", "01/12/1997")
            }
            Return listaPessoas
        End Function
    End Class
End Namespace