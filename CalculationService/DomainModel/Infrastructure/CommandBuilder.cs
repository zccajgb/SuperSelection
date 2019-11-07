namespace DomainModel.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Serilog;

    public static class CommandBuilder
    {
        public static string BuildJson(object obj)
        {
            CommandObject cmdObj = BuildCommandObject(obj);
            var json = JsonConvert.SerializeObject(cmdObj);
            Log.Logger.Information("Command Serialised: {@command}", json);
            return json;
        }

        public static CommandObject BuildCommandObject(object obj)
        {
            var type = obj.GetType().Name;
            var payload = JsonConvert.SerializeObject(obj);
            var cmdObj = new CommandObject(type, payload);
            return cmdObj;
        }

        public static object BuildCommand(CommandObject cmdObj)
        {
            var assembly = typeof(CommandObject).Assembly;

            var type = assembly.GetTypes().FirstOrDefault(t => t.IsClass && t.Name == cmdObj.Type);

            var payload = JsonConvert.DeserializeObject(cmdObj.Payload, type);
            Log.Logger.Information("Command Deserialised: {@command}", payload);
            return payload;
        }

        public static object BuildCommand(string json)
        {
            var cmdObj = JsonConvert.DeserializeObject<CommandObject>(json);
            return BuildCommand(cmdObj);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Makes sense")]
    public class CommandObject
    {
        public CommandObject(string type, string payload)
        {
            this.Type = type;
            this.Payload = payload;
        }

        public string Type { get; }

        public string Payload { get; }
    }
}
