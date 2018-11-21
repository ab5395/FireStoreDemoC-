using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "EUc5khEDVSpRWL6a8JtiPH4BuUwEFrTb0G1kaUCZ",
            BasePath = "https://hardik-f9e7c.firebaseio.com/"
        };
        public IFirebaseClient client;

        public async Task<ActionResult> Index()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                //await InsertData();
                //await FetchData();
                //await UpdateData();
                await DeleteData();
                Response.Write("Connection Esthablished");
            }


            return View();
        }

        public async Task InsertData()
        {
            try
            {
                var data = new List<Data> {
            new Data (){

                Id = 1,
                Name = "Abh Narola",
                Address = "Adajan",
                Interest = "Sleeping"
            },
            new Data (){

                Id = 2,
                Name = "Anc Narola",
                Address = "Adajan",
                Interest = "Sleeping"
            },
            new Data (){

                Id = 3,
                Name = "Kdh Narola",
                Address = "Adajan",
                Interest = "Sleeping"
            },
            new Data (){

                Id = 4,
                Name = "Hsn Narola",
                Address = "Adajan",
                Interest = "Sleeping"
            },
            new Data (){

                Id = 5,
                Name = "Abp Narola",
                Address = "Adajan",
                Interest = "Sleeping"
            }
            };
                var i = 0;
                foreach (var item in data)
                {
                    i++;
                    var response = await client.SetTaskAsync("FirstTestCollection/" + i, item);
                    var result = response.ResultAs<Data>();
                }
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }

        public async Task UpdateData()
        {
            try
            {
                var data = new List<Data> {
                    new Data (){

                        Id = 1,
                        Name = "Ajay Narola",
                        Address = "Adajan",
                        Interest = "Sleeping"
                    },
                    new Data (){

                        Id = 2,
                        Name = "Ankit Narola",
                        Address = "Adajan",
                        Interest = "Sleeping"
                    },
                    new Data (){

                        Id = 3,
                        Name = "Amit Narola",
                        Address = "Adajan",
                        Interest = "Sleeping"
                    },
                    new Data (){

                        Id = 4,
                        Name = "Hardik Narola",
                        Address = "Adajan",
                        Interest = "Sleeping"
                    },
                    new Data (){

                        Id = 5,
                        Name = "Abhay Narola",
                        Address = "Adajan",
                        Interest = "Sleeping"
                    }
                };
                var i = 0;
                foreach (var item in data)
                {
                    i++;
                    var response = await client.UpdateTaskAsync("FirstTestCollection/" + item.Id, item);
                    var result = response.ResultAs<Data>();
                }
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }

        public async Task FetchData()
        {
            try
            {
                var response = await client.GetTaskAsync("FirstTestCollection/1");
                var result = response.ResultAs<Data>();

                var response1 = await client.GetTaskAsync("FirstTestCollection");
                var result1 = JsonConvert.DeserializeObject<List<Data>>(response1.Body);
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }

        public async Task DeleteData()
        {
            try
            {
                var response = await client.DeleteTaskAsync("FirstTestCollection/1");

                var response1 = await client.DeleteTaskAsync("FirstTestCollection");
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class Data
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Interest { get; set; }
        }
    }
}