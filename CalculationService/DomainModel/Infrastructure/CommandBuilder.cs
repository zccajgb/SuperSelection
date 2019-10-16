using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DomainModel.Infrastructure
{
    public static class CommandBuilder
    {
        public static string BuildJson(object obj)
        {
            var type = obj.GetType().Name;
            var payload = JsonConvert.SerializeObject(obj);
            var cmdObj = new CommandObject(type, payload);
            var json = JsonConvert.SerializeObject(cmdObj);
            return json;
        }

        public static object BuildCommand(CommandObject cmdObj)
        {
            //var cmdObj = JsonConvert.DeserializeObject<CommandObject>(json);
            var assembly = typeof(CommandObject).Assembly;

            var type = assembly.GetTypes().FirstOrDefault(t => t.IsClass && t.Name == cmdObj.Type);


            var payload = JsonConvert.DeserializeObject(cmdObj.Payload, type);
            return payload;
        }
    }

    public class CommandObject
    {
        public string Type { get; }
        public string Payload { get; }

        public CommandObject(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}
