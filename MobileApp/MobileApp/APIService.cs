﻿using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

#if DEBUG
        const string apiUrl = "http://localhost:50302/api";
#endif
#if RELEASE
        const string apiUrl = "http://localhost:50302/api";
#endif

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(string attribute = "", string queries = "")
        {
            var filter = "";
            if (!string.IsNullOrWhiteSpace(queries))
                filter = "?$filter=" + attribute + " eq " + "'" + queries + "'";

            try
            {
                var result = await $"{apiUrl}/{ _route}{filter}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch(FlurlHttpException ex)
            {
                if(ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška!", "Niste autentificirani..", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetAndSort<T>(string queries = "")
        {
            var filter = "";
            if (!string.IsNullOrWhiteSpace(queries))
                filter = "?$orderBy=" + queries;

            var result = await $"{apiUrl}/{ _route}{filter}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetbyId<T>(int? id)
        {
            var result = await $"{apiUrl}/{ _route}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var result = $"{apiUrl}/{ _route}";

            return await result.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object request, object id)
        {
            var result = $"{apiUrl}/{ _route}/{id}";

            return await result.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task Delete(int? id)
        {
            await $"{apiUrl}/{ _route}/{id}".WithBasicAuth(Username, Password).DeleteAsync();
        }
    }
}