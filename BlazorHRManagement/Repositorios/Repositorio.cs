using System.Text;
using System.Text.Json;

namespace BlazorHRManagement.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// class's Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Method to get OpcionesPorDefectoJSON object
        /// </summary>
        private static JsonSerializerOptions OpcionesPorDefectoJSON =>
            new()
            { PropertyNameCaseInsensitive = true };

        /// <summary>
        /// Generic Delete method implementation
        /// </summary>
        /// <param name="url">Url endpoint</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var respuestaHttp = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(
                null,
                !respuestaHttp.IsSuccessStatusCode,
                respuestaHttp
            );
        }

        /// <summary>
        /// Generic Get method implementation
        /// </summary>
        /// <typeparam name="T">Generic type to get</typeparam>
        /// <param name="url">url endpoint</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var respuestaHttp = await httpClient.GetAsync(url);
            if (respuestaHttp.IsSuccessStatusCode)
            {
                var respuesta = await DeserealizarRespuesta<T>(
                    respuestaHttp,
                    OpcionesPorDefectoJSON
                );
                return new HttpResponseWrapper<T>(respuesta, error: false, respuestaHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, error: true, respuestaHttp);
            }
        }

        /// <summary>
        /// Generic Post method implementation
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJson = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(
                null,
                !responseHttp.IsSuccessStatusCode,
                responseHttp
            );
        }

        /// <summary>
        /// Generic Post method implementation, it return TResponse as response
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <typeparam name="TResponse">Generic type to get as response</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJson = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserealizarRespuesta<TResponse>(
                    responseHttp,
                    OpcionesPorDefectoJSON
                );
                return new HttpResponseWrapper<TResponse>(response, error: false, responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(
                default,
                !responseHttp.IsSuccessStatusCode,
                responseHttp
            );
        }

        /// <summary>
        /// Generic Put method implementation
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJson = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(
                null,
                !responseHttp.IsSuccessStatusCode,
                responseHttp
            );
        }

        /// <summary>
        /// DeserealizarRespuesta method
        /// </summary>
        /// <typeparam name="T">Generic content to deserialize</typeparam>
        /// <param name="httpResponse">HttpResponseMessage response object to deserialize</param>
        /// <param name="jsonSerializerOptions">JsonSerializerOptions object</param>
        /// <returns></returns>
        private async Task<T> DeserealizarRespuesta<T>(
            HttpResponseMessage httpResponse,
            JsonSerializerOptions jsonSerializerOptions
        )
        {
            var respuestaString = await httpResponse.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<T>(respuestaString, jsonSerializerOptions);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}