/*using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks; 

using Spv.Application.Interfaces.Repositories;
using Spv.Application.Wrappers;

using Spv.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Spv.Infrastructure.Persistence.Repositories
{
    public class ExternalRepository: IExternalRepositoryAsync
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ExternalRepository> _logger;

        public ExternalRepository(IHttpClientFactory httpClientFactory, ILogger<ExternalRepository> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public int Count => throw new NotImplementedException();
        public Customer Add(Customer t)
        {
            throw new NotImplementedException();
        }
        public Task<Customer> AddAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }
        public IQueryable<Customer> All()
        {
            throw new NotImplementedException();
        }
        public bool Contains(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public int Delete(Customer t)
        {
            throw new NotImplementedException();
        }
        public int Delete(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }
        public Task<int> DeleteAsync(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {        
   
            GC.SuppressFinalize(this);
        }       
        public IQueryable<Customer> Filter(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Customer> Filter(Expression<Func<Customer, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }
        public Customer Find(params object[] keys)
        {
            throw new NotImplementedException();
        }
        public Customer Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Customer> Get(Expression<Func<Customer, bool>> filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
        public async Task<IList<Customer>> GetAllAsync()
        {
            List<Customer> result = new List<Customer>();

            var httpClient = _httpClientFactory.CreateClient("Customer");

            var response = await httpClient.GetAsync($"Customer");

            if (response.IsSuccessStatusCode)
            {
                var resultResponse = await response.Content.ReadAsAsync<List<Customer>>();
                _logger.LogInformation(new EventId(100, "respuesta External service: "), "Respuesta {@result}", result);
                result = resultResponse;
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError(responseContent);


            }

            return result;
        }
        public Task<Customer> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<IList<Customer>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }
        public IQueryable<Customer> Includes(string includeProperties)
        {
            throw new NotImplementedException();
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        public int Update(Customer t)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }
   
    }
}
*/