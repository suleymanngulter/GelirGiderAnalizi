using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Models.GelirGiderAnalizi.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace GelirGiderAnalizi.Services.AuthService
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginModel loginModel);
    }

}
