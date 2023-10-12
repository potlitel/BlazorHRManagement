namespace BlazorHRManagement.Repositorios
{
    public interface IRepositorio
    {
        /// <summary>
        /// Generic Delete method contract
        /// </summary>
        /// <param name="url">Url endpoint</param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> Delete(string url);

        /// <summary>
        /// Generic Get method contract
        /// </summary>
        /// <typeparam name="T">Generic type to get</typeparam>
        /// <param name="url">url endpoint</param>
        /// <returns></returns>
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        /// <summary>
        /// Generic Post method contract
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);

        /// <summary>
        /// Generic Post method contrat, it return TResponse as response
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <typeparam name="TResponse">Generic type to get as response</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);

        /// <summary>
        /// Generic Put method contract
        /// </summary>
        /// <typeparam name="T">Generic type to send</typeparam>
        /// <param name="url">url endpoint</param>
        /// <param name="enviar">Content itselft to sent</param>
        /// <returns></returns>
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
    }
}