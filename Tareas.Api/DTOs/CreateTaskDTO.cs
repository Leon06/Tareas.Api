namespace Tareas.Api.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Descripcion { get; set; }
        public bool Completado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }

    public class CreateTasksDTO
    {
        public List<TaskDTO> Tasks { get; set; } = new List<TaskDTO>();
    }
}
