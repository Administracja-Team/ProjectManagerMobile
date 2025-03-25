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
        Task<ApiResponse<object>> UpdateUserProfile([Body] UserUpdateProfileRequest request);

        [Get("/user/avatar")]
        Task<ApiResponse<byte[]>> GetUserAvatar();

        [Multipart]
        [Post("/user/avatar")]
        Task<ApiResponse<object>> UploadUserAvatar([AliasAs("file")] StreamPart file);
    }
}
