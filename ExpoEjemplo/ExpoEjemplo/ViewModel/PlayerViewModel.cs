using ExpoEjemplo.Model;
using ExpoEjemplo.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpoEjemplo.ViewModel
{
    public class PlayerViewModel
    {
        Crud crud = new Crud();
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string nickname { get; set; }
        public string game { get; set; }

        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var response = await crud.CreatePlayer(name, lastname, email, phone, nickname, game);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("success insert");
                    }
                    else
                    {
                        Console.WriteLine("error insert");
                    }

                });
            }
        }


        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var response = await crud.UpdatePlayer(id.ToString(), name, lastname, email, phone, nickname, game);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("success update");
                    }
                    else
                    {
                        Console.WriteLine("error update");
                    }
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var response = await crud.DeletePlayer(id);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("success delete");
                    }
                    else
                    {
                        Console.WriteLine("error delete");
                    }
                });
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var response = await crud.SearchPlayer(id);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        JObject data = (JObject)JsonConvert.DeserializeObject(content);
                        var players = data.Value<object>("data");
                        var player = JsonConvert.DeserializeObject<Player>(players.ToString());
                    }
                    else
                    {
                        Console.WriteLine("No existe");
                    }
                });
            }
        }
    }
}
