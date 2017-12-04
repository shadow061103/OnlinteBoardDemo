using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinteBoardDemo.Model;
using OnlinteBoardDemo.Service;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlinteBoardDemo.Controllers
{
    public class DefaultController : baseController
    {
        // GET: Default
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<SportsMap> list = new List<SportsMap>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatioc/json"));
            HttpResponseMessage response = client.GetAsync("http://data.ntpc.gov.tw/od/data/api/54172EE2-975D-44C6-9465-9719E5EF5264?$format=json").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<SportsMap>>(responseBody);
            }
          
            ViewBag.QueryList = list;

            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<SportsMap> list = new List<SportsMap>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatioc/json"));
            HttpResponseMessage response = client.GetAsync("http://data.ntpc.gov.tw/od/data/api/54172EE2-975D-44C6-9465-9719E5EF5264?$format=json").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<SportsMap>>(responseBody);
            }
            ViewBag.QueryList = list.Where(c => c.G_title.Contains(model.KeyWord)).ToList(); ;
            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> Intro(string Sn)
        {
            List<SportsMap> list = new List<SportsMap>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatioc/json"));
            HttpResponseMessage response = client.GetAsync("http://data.ntpc.gov.tw/od/data/api/54172EE2-975D-44C6-9465-9719E5EF5264?$format=json").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<SportsMap>>(responseBody);
            }
            list = list.Where(c => c.G_sn == Sn).ToList();
            ViewBag.Intro = list[0].G_Intro;

            return View();
        }
    }
}