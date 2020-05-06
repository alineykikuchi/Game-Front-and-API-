using Games.Api.Models.Enums;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Games.Tools.GenericClientApi
{
    public class GenericRestApi
    {
        protected RestClient client;
        

        public GenericRestApi()
        {
            var host = ConfigurationManager.AppSettings.Get("HostApi");
            client = new RestClient(host);
        }

        public ResponseModelDados<T> Executar<T>(object body, RestRequest request)
        {
            var responseModel = new ResponseModelDados<T>();
            

            request.RequestFormat = DataFormat.Json;

            var retorno = client.Execute<ResponseModelDados<T>>(request);

            if (retorno.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                responseModel.Mensagens.Add("O servidor retornou um erro interno.");
                responseModel.StatusRetorno = TiposErro.InternalServerError;
            }
            else if (retorno.StatusCode == 0)
            {
                responseModel.Mensagens.Add("Impossível conectar-se ao servidor remoto. O servico pode estar fora do ar.");
                responseModel.StatusRetorno = TiposErro.InternalServerError;
            }
            else
                return retorno.Data;

            return responseModel;
        }
    }
}
