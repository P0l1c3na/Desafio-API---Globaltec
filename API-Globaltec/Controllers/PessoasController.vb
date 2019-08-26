Imports System.Net
Imports System.Web.Http
Imports API_Globaltec.Pessoas

Namespace Pessoas
    Public Class PessoasController
        Inherits ApiController

        ' GET: api/Pessoas
        ' Lista todas as Pessoas
        <Authorize>
        Public Function GetValues() As IHttpActionResult
            Dim gerperson As New Pessoa
            Try
                Return Ok(gerperson.ListOfPerson)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ' GET: api/Pessoas/5
        ' Lista a pessoa por codigo
        <Authorize>
        Public Function GetValue(ByVal id As Integer) As IHttpActionResult
            Dim gerperson As New Pessoa

            Try
                Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Codigo = id)
                If (person.Count > 0) Then
                    Return Ok(person)
                Else
                    Return BadRequest("Não existe pessoa com o id - " & id & " cadastrada!")
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function


        ' GET: api/Pessoas/5
        ' Lista a pessoa por Uf
        <Authorize>
        Public Function GetValue(ByVal Uf As String) As IHttpActionResult
            Dim gerperson As New Pessoa
            Try
                Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Uf = Uf)
                If (person.Count > 0) Then
                    Return Ok(person)
                Else
                    Return BadRequest("Não existe pessoa com o Uf - " & Uf & " cadastrada!")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ' POST: api/Pessoas
        ' Gravar Pessoa
        <Authorize>
        Public Function PostValue(<FromBody()> ByVal request As Pessoa) As IHttpActionResult
            Dim gerperson As New Pessoa
            Dim lstpessoa = gerperson.ListOfPerson
            Try
                If IsNothing(request.Codigo) Or Not IsNumeric(request.Codigo) Or request.Codigo Like 0 Then
                    Return BadRequest("O campo Codigo não pode estar vazio!")
                Else
                    lstpessoa.Add(New Pessoa(request.Codigo, request.Nome, request.Cpf, request.Uf, request.DataDeNascimento))
                    Return Ok("Salvo com sucesso!")
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ' PUT: api/Pessoas/5
        ' Atualizar Pessoa por Código
        <Authorize>
        Public Function PutValue(<FromBody()> ByVal request As Pessoa)
            Dim gerperson As New Pessoa
            Try
                ' Procuro se existe a pessoa na lista.
                Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Codigo = request.Codigo)

                'Se a lista retornada for maior que 0 eu comparo o id e faço a atualização da pessoa.
                If (person.Count > 0) Then
                    Dim pes As List(Of Pessoa) = gerperson.ListOfPerson
                    For Each p In pes
                        If p.Codigo Like request.Codigo Then
                            p.Nome = request.Nome
                            p.Cpf = request.Cpf
                            p.Uf = request.Uf
                            p.DataDeNascimento = request.DataDeNascimento
                        End If
                    Next
                    'Retorno a lista de pessoas atualizada
                    Return Ok(pes)
                Else
                    Return BadRequest("Não existe pessoa com o id - " & request.Codigo & " cadastrada!")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ' DELETE: api/Pessoas/5
        ' Deleta a pessoa por código
        <Authorize>
        Public Function DeleteValue(ByVal id As Integer) As IHttpActionResult
            Dim gerperson As New Pessoa
            Try
                Dim person As List(Of Pessoa) = gerperson.ListOfPerson.FindAll(Function(p As Pessoa) p.Codigo = id)
                If (person.Count > 0) Then
                    Dim pes As List(Of Pessoa) = gerperson.ListOfPerson
                    pes.RemoveAll(Function(p As Pessoa) p.Codigo = id)
                    Return Ok(pes)
                Else
                    Return BadRequest("Não existe pessoa com o id - " & id & " cadastrada!")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace