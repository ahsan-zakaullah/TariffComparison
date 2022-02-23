using System.Net.Http;
using System.Threading.Tasks;
using TariffComparison.Api.Test.Integration.Utilities;

namespace TariffComparison.Api.Test.Integration.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static Task<T> DeserializeContent<T>(this HttpResponseMessage message)
        {
            return JsonUtils.DeserializeAsync<T>(message.Content.ReadAsStreamAsync());
        }
    }
}
