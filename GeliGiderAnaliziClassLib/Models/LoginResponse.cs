

namespace GelirGiderAnalizi.Models
{
    namespace GelirGiderAnalizi.Models
    {
        public class LoginResponse
        {
            public bool? Success { get; set; }
            public string? Message { get; set; } 
            public LoginData? Data { get; set; }
        }

        public class LoginData
        {
            public string? Token { get; set; } 
            public string? Expiration { get; set; }
            public string? SubeAd { get; set; } 
            public string? DonemYil { get; set; } 
        }
    }

}
