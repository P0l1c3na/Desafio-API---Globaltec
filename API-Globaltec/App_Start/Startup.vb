Imports System.Web.Http
Imports Microsoft.Owin
Imports Microsoft.Owin.Cors
Imports Microsoft.Owin.Security.OAuth
Imports Owin

<Assembly: OwinStartup(GetType(PessoasAPIService.Startup))>
Namespace PessoasAPIService
    Public Class Startup
        Public Sub Configuration(ByVal app As IAppBuilder)
            Dim config = New HttpConfiguration()
            config.MapHttpAttributeRoutes()
            config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{id}",
                                       defaults:=New With {Key .id = RouteParameter.[Optional]
            })
            app.UseCors(CorsOptions.AllowAll)
            TokenAcess(app)
            app.UseWebApi(config)

        End Sub

        'Função para ativar o Token de Acesso
        Private Sub TokenAcess(ByVal app As IAppBuilder)
            Dim opcoesConfiguracaoToken = New OAuthAuthorizationServerOptions() With {
                .AllowInsecureHttp = True,
                .TokenEndpointPath = New PathString("/api/Auth"),
                .AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                .Provider = New ProviderDeTokensDeAcesso()
            }
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken)
            app.UseOAuthBearerAuthentication(New OAuthBearerAuthenticationOptions())
        End Sub
    End Class
End Namespace