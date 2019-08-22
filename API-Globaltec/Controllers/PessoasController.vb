Imports System.Net
Imports System.Web.Http
Imports API_Globaltec.Pessoas

Namespace Pessoas
    Public Class PessoasController
        Inherits ApiController

        ' GET: api/Pessoas
        ' Lista todas as Pessoas
        Public Function GetValues() As IHttpActionResult
            Dim gerperson As New Pessoa
            Return Ok(gerperson.ListOfPerson)
        End Function

        ' GET: api/Pessoas/5
        ' Lista a pessoa por codigo
        Public Function GetValue(ByVal id As Integer) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Codigo = id)
            Return Ok(person)
        End Function


        ' GET: api/Pessoas/5
        ' Lista a pessoa por Uf
        Public Function GetValue(ByVal Uf As String) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Uf = Uf)
            Return Ok(person)
        End Function

        ' POST: api/Pessoas
        ' Gravar Pessoa
        Public Function PostValue(<FromBody()> ByVal request As Pessoa) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim lstpessoa = gerperson.ListOfPerson
            lstpessoa.Add(New Pessoa(request.Codigo, request.Nome, request.Cpf, request.Uf, request.DataDeNascimento))

            Return Ok(lstpessoa)
        End Function

        ' PUT: api/Pessoas/5
        ' Atualizar Pessoa por Código
        Public Function PutValue(<FromBody()> ByVal request As Pessoa) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim person As List(Of Pessoa) = gerperson.ListOfPerson
            For Each p In person
                If p.Codigo Like request.Codigo Then
                    p.Nome = request.Nome
                    p.Cpf = request.Cpf
                    p.Uf = request.Uf
                    p.DataDeNascimento = request.DataDeNascimento
                End If
            Next
            Return Ok(person)
        End Function

        ' DELETE: api/Pessoas/5
        ' Deleta a pessoa por código
        Public Function DeleteValue(ByVal id As Integer) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim person As List(Of Pessoa) = gerperson.ListOfPerson
            person.RemoveAll(Function(p As Pessoa) p.Codigo = id)
            Return Ok(person)
        End Function
    End Class
End Namespace