using System.Net;

namespace ASDP.FinalProject.Helpers
{
    public class SigexCookieHelper
    {
        public static CookieContainer AddAuthCookies(string baseAddress, string jwt)
        {
            var cookies = new List<Cookie>
            {
                new Cookie("HttpOnly", null),
                new Cookie("Secure", null),
                new Cookie("jwt", null)
            };

            CookieContainer cookiesContainer = new CookieContainer();


            var cookie = new Cookie("jwt", jwt)
            {
                HttpOnly = true,
                Secure = true,
                Domain = new Uri(baseAddress).Host,
                Path = "/",
                Expires = DateTime.UtcNow.AddHours(5)
            };

            cookiesContainer.Add(new Uri(baseAddress), cookie);

            return cookiesContainer;
        }
    }
}
