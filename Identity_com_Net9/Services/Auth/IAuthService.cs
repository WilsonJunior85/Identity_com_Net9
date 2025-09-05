using Identity_com_Net9.Dto;
using Identity_com_Net9.Models;

namespace Identity_com_Net9.Services.Auth
{
    public interface IAuthService
    {
        Task<ResultModel<string>> Register (RegisterDto registerDto);
    }
}
