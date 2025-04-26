using ProjectManagerMobile.Models.DTO;
using ProjectManagerMobile.Models.DTO.Project;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services.Interfaces
{
    public interface IProjectApi
    {
        [Get("/project/list")]
        Task<ApiResponse<List<ProjectMemberDto>>> GetAllUserProjects(
            [Header("Authorization")] string accessToken);

        [Get("/project/{project_id}")]
        Task<ApiResponse<ProjectDetailsDto>> GetProjectDetails(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId
            );

        [Post("/project/create")]
        Task<ApiResponse<ProjectMemberDto>> CreateProject(
            [Header("Authorization")] string accessToken,
            [Body] ProjectCreateRequest request);

        [Post("/project/{project_id}/code/create")]
        Task<ApiResponse<ProjectInvitationCode>> CreateInvitationCode(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId);

        [Post("/project/connect/{code}")]
        Task<ApiResponse<ProjectMemberDto>> ConnectToProjectByCode(
            [Header("Authorization")] string accessToken,
            [AliasAs("code")] string code);

        [Patch("/project/member/{member_id}/system-role")]
        Task<ApiResponse<string>> SetMemberSystemRole(
            [Header("Authorization")] string accessToken,
            [AliasAs("member_id")] long memberId,
            [Body] StringRequest role);

        [Post("/project/member/{member_id}/descriptive-role")]
        Task<ApiResponse<string>> SetDescriptiveRole(
            [Header("Authorization")] string accessToken,
            [AliasAs("member_id")] long memberId,
            [Body] StringRequest role);

        [Delete("/project/member/{member_id}/delete")]
        Task<ApiResponse<string>> DeleteMemberFromProject(
            [Header("Authorization")] string accessToken,
            [AliasAs("member_id")] long memberId);


        [Get("/project/member/{member_id}/avatar")]
        Task<HttpResponseMessage> GetMemberAvatar(
        [Header("Authorization")] string accessToken,
        [AliasAs("member_id")] long memberId,
        [Header("Accept")] string accept = "image/png");
    }
}
