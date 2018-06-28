using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App5.Rest
{
    public class Rest
    {
        private string baseUrl { get; set; }

        private HttpClient client;

        public const string urlUsuario = "usuario";
        public const string urlMovie = "movie";
        public const string urlImages = "image";
        public const string urlCategories = "category";



        public Rest(string urlBase)
        {
            try
            {
                this.baseUrl = urlBase;
                this.client = new HttpClient(new NativeMessageHandler());
                this.client.Timeout = new TimeSpan(0, 0, 10);
                this.client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<TEntity> tratarRetornoAsync<TEntity>(HttpResponseMessage msg) where TEntity : class
        {
            try
            {
                if (msg.IsSuccessStatusCode)
                {
                    string json = await msg.Content.ReadAsStringAsync();

               

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(json);

                }
                else
                {
                    throw new Exception("Falha REST, código: " + msg.StatusCode);
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<TEntity> getAsync<TEntity>(string url) where TEntity : class
        {
            try
            {
                HttpResponseMessage msg = await this.client.GetAsync(baseUrl + url);
                return await this.tratarRetornoAsync<TEntity>(msg);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public virtual async Task<TEntity> putAsync<TEntity>(string url, object obj) where TEntity : class
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                HttpResponseMessage msg = await this.client.PutAsync(baseUrl + url, new StringContent(json, Encoding.UTF8, "application/json"));

                return await this.tratarRetornoAsync<TEntity>(msg);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<TEntity> postAsync<TEntity>(string url, object obj) where TEntity : class
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                HttpResponseMessage msg = await this.client.PostAsync(baseUrl + url, new StringContent(json, Encoding.UTF8, "application/json"));

                return await this.tratarRetornoAsync<TEntity>(msg);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual async Task<Boolean> deleteAsync<TEntity>(string url, string id) where TEntity : class
        {
            try
            {
                HttpResponseMessage msg = await this.client.GetAsync(baseUrl + url + id.ToString());

                try
                {
                    if (msg.IsSuccessStatusCode)
                    {
                        string json = await msg.Content.ReadAsStringAsync();

                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Boolean>(json);

                    }
                    else
                    {
                        throw new Exception("Falha REST, código: " + msg.StatusCode);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual async Task<List<Model.Movie.Movie>> getMoviesAsync()
        {
            return await this.getAsync<List<Model.Movie.Movie>>(urlMovie+"/all");
        }

        public virtual async Task<List<Model.Usuario.Usuario>> getUsuariosAsync()
        {
            return await this.getAsync<List<Model.Usuario.Usuario>>(urlUsuario+"/all");
        }

        public virtual async Task<Model.Usuario.Usuario> getLoginAsync(string login, string senha)
        {
            return await this.getAsync<Model.Usuario.Usuario>(urlUsuario+"/"+login+"/"+senha);
        }

        public virtual async Task<Boolean> deleteUsuarioAsync(Model.Usuario.Usuario u)
        {
            return await this.deleteAsync<Model.Usuario.Usuario>(urlUsuario+"/delete/", u.id);
        }
        public virtual async Task<Model.Usuario.Usuario> putUsuarioAsync(Model.Usuario.Usuario u)
        {
            return await this.putAsync<Model.Usuario.Usuario>(urlUsuario, u);
        }

        public virtual async Task<Model.Usuario.Usuario> postUsuariosAsync(Model.Usuario.Usuario _usuario)
        {
            return await this.postAsync<Model.Usuario.Usuario>(urlUsuario, _usuario);
        }

    }
}
