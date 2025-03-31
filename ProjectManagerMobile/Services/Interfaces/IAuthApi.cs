using ProjectManagerMobile.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services.Interfaces
{
    public interface IAuthApi
    {
        [Post("/authorization/register")]
        [Multipart]
        Task<ApiResponse<BearerTokenDto>> RegisterUser(
            [AliasAs("user")] UserRegistrationRequest request,
            [AliasAs("avatar")] StreamPart avatar);

        [Post("/authorization/login")]
        Task<ApiResponse<BearerTokenDto>> LoginUser([Body] UserLoginRequest request);

        [Patch("/authorization/refresh")]
        Task<ApiResponse<BearerTokenDto>> RefreshToken([Body] UserTokensRequest request);

        [Delete("/authorization/logout")]
        Task<ApiResponse<string>> LogoutUser([Body] UserTokensRequest request);
    }
}
