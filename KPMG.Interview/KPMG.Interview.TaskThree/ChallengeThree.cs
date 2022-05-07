using Newtonsoft.Json;
using System.Linq;

namespace KPMG.Interview.TaskThree
{
    public class ChallengeThree
    {
        public string? GetValue(string? strObj, string? key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strObj) || string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException();

                dynamic? obj = JsonConvert.DeserializeObject(strObj);

                var keys = key.Split('/');

                var valueObj = obj[keys[0]];
                if (valueObj == null) throw new ArgumentOutOfRangeException(keys[0]);

                for (int i = 1; i < keys.Length; i++)
                {
                    valueObj = valueObj[keys[i]];
                    if (valueObj == null) throw new ArgumentOutOfRangeException(keys[i]);
                }

                var value = JsonConvert.SerializeObject(valueObj);

                return value.ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}