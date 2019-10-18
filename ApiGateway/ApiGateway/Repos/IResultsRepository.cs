using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiGateway.Controllers;
using ApiGateway.Documents.Queries;
using ApiGateway.Infrastructure;
using ApiGateway.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ApiGateway.Repos
{
    public interface IResultsRepository
    {
        Task<string> PostResultsQuery(BaseQuery query);
    }
}
