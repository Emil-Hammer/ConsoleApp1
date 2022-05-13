using Newtonsoft.Json;

namespace ConsoleApp1.Processing.Utils
{
    public static class JSONLoader
    {
        public static T LoadFromJson<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var json = reader.ReadToEnd();
            if (json != null)
            {
                var obj = JsonConvert.DeserializeObject<T>(json);

                if (obj != null)
                {
                    return obj;
                }
            }

            throw new FileLoadException($"Could not load {filePath} correctly.");
        }
    }
}
