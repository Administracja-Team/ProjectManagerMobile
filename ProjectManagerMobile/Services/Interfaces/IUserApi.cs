using DevExpress.Internal;
using ProjectManagerMobile.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services.Interfaces
{
    public interface IUserApi
    {
        [Get("/user")]
        Task<ApiResponse<UserDto>> GetUserProfile([Header("Authorization")] string accessToken);

        [Post("/user")]
        Task<ApiResponse<string>> UpdateUserProfile(
            [Header("Authorization")] string accessToken, 
            [Body] UserUpdateProfileRequest request);

        [Get("/user/avatar")]
        Task<HttpResponseMessage> GetUserAvatar(
            [Header("Authorization")] string accessToken,
            [Header("Accept")] string accept = "image/png");

        [Multipart]
        [Post("/user/avatar")]
        Task<ApiResponse<string>> UploadUserAvatar(
            [Header("Authorization")] string accessToken, 
            [AliasAs("file")] StreamPart file);
    }
}
