using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.WebUI.Common
{
    public interface IFormatQueryString
    {
        public T CreateRequestObject<T>(HttpRequest req) where T : new();
    }
}
