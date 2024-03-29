using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasGregTest.Busines.Busines;
using ThomasGregTest.ViewModels.VM;

namespace ThomasGregTest.API.Controllers
{
    public class LogradouroController : Controller
    {
        private string _urlBase = "https://localhost:44377/api/LogradouroAPI";
        public async Task<ActionResult> Index(int? id)
        {
            LogradouroViewModels logradouroViewModels = new LogradouroViewModels();

            using (HttpClient httpClient = new HttpClient())
            {

                if (id.GetValueOrDefault() != 0)
                {
                    _urlBase += $"?id={id}";
                }

                httpClient.BaseAddress = new Uri(_urlBase);

                BearerTokenViewModels bearerTokenViewModels = JsonConvert.DeserializeObject<BearerTokenViewModels>(await GenerateToken());
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(bearerTokenViewModels.token_type, bearerTokenViewModels.access_token);

                HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();

                    if (jsonResult != "[]" && id.GetValueOrDefault() == 0)
                    {

                        logradouroViewModels.ListaLogradouroViewModels = JsonConvert.DeserializeObject<List<LogradouroViewModels>>(jsonResult);
                    }
                    else if (jsonResult != "[]" && id.GetValueOrDefault() != 0)
                    {
                        logradouroViewModels = JsonConvert.DeserializeObject<LogradouroViewModels>(jsonResult);
                    }

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    TempData["Message"] = "Você não possuí autorização para buscar os clientes";
                }
                else
                {
                    TempData["Message"] = "Ocorreu algum erro ao trazer os clientes";
                }

                ViewBag.ClienteId = new SelectList(new ClienteBLI().GetAll(), "ClienteId", "Nome", logradouroViewModels.ClienteId);
                logradouroViewModels.ListaLogradouroViewModels = new LogradouroBLI().GetAll();
            }

            return View(logradouroViewModels);
        }

        [HttpPost]
        public async Task<ActionResult> Index(LogradouroViewModels logradouroViewModels)
        {

            if (ModelState.IsValid)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_urlBase);
                    var logradouroJson = JsonConvert.SerializeObject(logradouroViewModels);
                    HttpContent content = new StringContent(logradouroJson);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(httpClient.BaseAddress, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Cliente salvo com sucesso !";
                    }
                    else
                    {
                        TempData["Message"] = "Houve o seguinte erro ao salvar o cliente: " + response.Content;
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                if (id != 0)
                {
                    httpClient.BaseAddress = new Uri(_urlBase + $"?id={id}");
                    HttpResponseMessage response = await httpClient.DeleteAsync(httpClient.BaseAddress);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Cliente salvo com sucesso !";
                    }
                    else
                    {
                        TempData["Message"] = "Houve o seguinte erro ao salvar o cliente: " + response.Content;
                    }
                }

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<string> GenerateToken()
        {
            var body = new Dictionary<string, string>
            {
                { "username", "Teste" },
                { "password", "Teste" },
                { "grant_type", "password" }
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var conteudo = new FormUrlEncodedContent(body);

                httpClient.BaseAddress = new Uri("https://localhost:44377/token");
                HttpResponseMessage response = await httpClient.PostAsync(httpClient.BaseAddress, conteudo);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = response.Content.ReadAsStringAsync();
                    return await tokenResponse;
                }
                else
                {
                    return null;
                }

            }
        }

    }
}