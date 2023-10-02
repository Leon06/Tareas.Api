namespace Tareas.Api.DTOs
{
    public class PagedTasksResponse
    {
        public List<TaskDTO> Data { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
