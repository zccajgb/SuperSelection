namespace ApiGateway.Infrastructure
{
    using System.Linq;
    using Newtonsoft.Json;

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

        public static object BuildCommand(string json)
        {
            var cmdObj = JsonConvert.DeserializeObject<CommandObject>(json);
            var assembly = typeof(CommandObject).Assembly;

            var type = assembly.GetTypes().FirstOrDefault(t => t.IsClass && t.Name == cmdObj.Type);

            var payload = JsonConvert.DeserializeObject(cmdObj.Payload, type);
            return payload;
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class CommandObject
#pragma warning restore SA1402 // File may only contain a single type
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
