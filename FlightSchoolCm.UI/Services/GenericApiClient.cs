using FlightSchoolCm.UI.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace FlightSchoolCm.UI.Services;

public class GenericApiClient<TEntity> : HttpClient, IGenericApiClient<TEntity> where TEntity : class
{
    private readonly string _basePath;
    private const string MEDIA_TYPE = "application/json";

    public GenericApiClient(string basePath, string baseAddress)
    {
        BaseAddress = new Uri(baseAddress);
        _basePath = basePath + baseAddress;
    }
    public async Task<List<TEntity>?> GetAllAsync()
    {
        try
        {
            SetupHeaders();

            var testme = BaseAddress;
            var response = await GetAsync(_basePath);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var returnModel = JsonConvert.DeserializeObject<List<TEntity>>(result);

                return returnModel;
            }
            else
            {
                throw new Exception
                    ("Failed to retrieve items returned " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TEntity> CreateAsync(TEntity item)
    {
        try
        {
            SetupHeaders();
            var serializedJson = GetSerializedObject(item);
            var bodyContent = GetBodyContent(serializedJson);

            var response = await PostAsync(_basePath, bodyContent);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception
                    ($"Failed to create item returned  { response.StatusCode }");
            }
            var result = response.Content.ReadFromJsonAsync<TEntity>();
            return await result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            SetupHeaders();

            var response = await DeleteAsync(_basePath + $"/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception
                    ($"Failed to Delete the resource id: {id}, returned {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public async Task<TEntity> GetByIdAsync(int id)
    {
        try
        {
            SetupHeaders();

            var response = await GetAsync(_basePath + $"/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var returnModel = JsonConvert.DeserializeObject<TEntity>(result);

                return returnModel;
            }
            else
            {
                throw new Exception
                    ("Failed to retrieve item id: " + id + $" returned " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateAsync(int? id, TEntity item)
    {
        try
        
        {
            SetupHeaders();
            var serializedJson = GetSerializedObject(item);
            var bodyContent = GetBodyContent(serializedJson);

            var response = await PutAsync(_basePath + $"/{id}", bodyContent);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception
                    ($"Failed to update the item with ID of {id}, returned { response.StatusCode }");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #region Helpers
    protected virtual void SetupHeaders()
    {
        DefaultRequestHeaders.Clear();

        //Define request data format  
        DefaultRequestHeaders.Accept.Add
            (new MediaTypeWithQualityHeaderValue
            (MEDIA_TYPE));
    }
    protected virtual string GetSerializedObject(object obj)
    {
        var serializedJson = JsonConvert.SerializeObject(obj);

        return serializedJson;
    }
    protected virtual StringContent GetBodyContent(string serializedJson)
    {
        var bodyContent = new StringContent
            (serializedJson, Encoding.UTF8, "application/json");

        return bodyContent;
    }
    #endregion
}
