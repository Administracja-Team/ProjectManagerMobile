using ProjectManagerMobile.Models.DTO.Sprint;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services.Interfaces
{
    public interface ISprintApi
    {
        [Get("/project/{project_id}/sprints")]
        Task<ApiResponse<List<SprintDto>>> GetSprintsForProject(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId);

        [Get("/project/{project_id}/sprint/{sprint_id}")]
        Task<ApiResponse<SprintDetailsDto>> GetSprintDetails(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId,
            [AliasAs("sprint_id")] long sprintId);

        [Post("/project/{project_id}/sprint")]
        Task<ApiResponse<string>> CreateSprint(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId,
            [Body] SprintCreateRequest request);


        [Delete("/project/{project_id}/sprint/{sprint_id}")]
        Task<ApiResponse<string>> DeleteSprint(
            [Header("Authorization")] string accessToken,
            [AliasAs("project_id")] long projectId,
            [AliasAs("sprint_id")] long sprintId);
    }
}
