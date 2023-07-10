using TaskMgt.DTOs;

namespace TaskMgt.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto register);
    }
}
