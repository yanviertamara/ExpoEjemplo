using ExpoEjemplo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpoEjemplo.Services
{
    public class Crud
    {
        public async Task<HttpResponseMessage> CreatePlayer(string nombre, string apellido, string email, string telefono, string nickname, string game)
        {
            var client = new HttpClient();
            var player = new Player
            {
                name = nombre,
                lastname = apellido,
                email = email,
                phone = telefono,
                nickname = nickname,
                game = game
            };
            var json = JsonConvert.SerializeObject(player);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://127.0.0.1:8000/api/players/new", content);
            Console.WriteLine(json);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePlayer(string id ,string nombre, string apellido, string email, string telefono, string nickname, string game)
        {
            var client = new HttpClient();
            var player = new Player
            {
                id   = Convert.ToInt32(id),
                name = nombre,
                lastname = apellido,
                email = email,
                phone = telefono,
                nickname = nickname,
                game = game
            };
            var json = JsonConvert.SerializeObject(player);
            Console.WriteLine(json);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://127.0.0.1:8000/api/players/update", content);
            return response;
        }

        public async Task<HttpResponseMessage> DeletePlayer(int id)
        {
            var client = new HttpClient();
            var player = new Player
            {
                id = Convert.ToInt32(id)
            };
            var json = JsonConvert.SerializeObject(player);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(json);
            var response = await client.DeleteAsync("http://127.0.0.1:8000/api/players/delete/"+id);
            return response;
        }
        public async Task<HttpResponseMessage> SearchPlayer(int id)
        {
            var client = new HttpClient();
            var player = new Player
            {
                id = id
            };
            var json = JsonConvert.SerializeObject(player);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.GetAsync("http://127.0.0.1:8000/api/players/search/");
            return response;
        }
    }
}
