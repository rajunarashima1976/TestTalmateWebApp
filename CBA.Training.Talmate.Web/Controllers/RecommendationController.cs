﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using CBA.Training.Talmate.Web.Comman;
using CBA.Training.Talmate.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CBA.Training.Talmate.Web.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly IMapper _mapper;
        private AppSettings _settings;
        public RecommendationController(IMapper mapper, IOptions<AppSettings> settings)
        {
            _mapper = mapper;
            _settings = settings.Value;

        }
        [HttpGet]
        public async Task<IActionResult> Seek()
        {
            var recommendation = new List<Recommendation>();
            using (var client = new HttpClient())
            {
                string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Recommendation + "/" + Constants.Seek + "/";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                var result = response.Content.ReadAsStringAsync().Result;
                recommendation = JsonConvert.DeserializeObject<List<Recommendation>>(result);
            }
            return await Task.FromResult(View(recommendation));
        }

        [HttpPost]       
        public async Task<string> RouteRecommendation(List<Recommendation> recommendation)
        {
            bool status = false;
            string message = string.Empty;
            
                using (var client = new HttpClient())
                {
                    string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Recommendation + "/" + Constants.RouteRecommendation + "/"; 
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync(baseUri, recommendation);
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result == "")
                        status = false;
                    else
                        status = JsonConvert.DeserializeObject<bool>(result);
                }
                if (status)
                {
                    message = "Recommendation routed to PM Successfully!";
                    ModelState.Clear();
                }
                else
                {
                   message = "Unable to route recommendation!";
                }
            
            return message;
        }

        [HttpGet]
        public async Task<IActionResult> AcceptReject()
        {
            var recommendations = new List<Recommendation>();
            using (var client = new HttpClient())
            {
                string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Recommendation + "/";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                var result = response.Content.ReadAsStringAsync().Result;
                recommendations = JsonConvert.DeserializeObject<List<Recommendation>>(result);
            }
            return await Task.FromResult(View(recommendations));
        }

        [HttpPost]
        public async Task<string> Accept(int Id)
        {
            bool status = false;
            string message = string.Empty;

            using (var client = new HttpClient())
            {
                string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Recommendation + "/" + Constants.Accept + "/";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(baseUri, Id);
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "")
                    status = false;
                else
                    status = JsonConvert.DeserializeObject<bool>(result);
            }
            if (status)
            {
                message = "Recommendation Accepted Successfully!";
                ModelState.Clear();
            }
            else
            {
                message = "Unable to accept recommendation!";
            }

            return message;
        }

        [HttpPost]
        public async Task<string> Reject(int Id)
        {
            bool status = false;
            string message = string.Empty;

            using (var client = new HttpClient())
            {
                string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Recommendation + "/" + Constants.Reject + "/";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(baseUri, Id);
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "")
                    status = false;
                else
                    status = JsonConvert.DeserializeObject<bool>(result);
            }
            if (status)
            {
                message = "Recommendation Rejected Successfully!";
                ModelState.Clear();
            }
            else
            {
                message = "Unable to reject recommendation!";
            }

            return message;
        }
    }
}
