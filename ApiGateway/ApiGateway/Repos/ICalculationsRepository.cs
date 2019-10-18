using ApiGateway.Documents.Commands;
using ApiGateway.Documents.Queries;
using ApiGateway.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Repos
{
    public interface ICalculationsRepository
    {
        Task<string> PostCommand(BaseCommand cmd);
        Task<string> PostQuery(BaseQuery qry);
    }
}
