using AutoMapper;
using Tareas.Api.DTOs;
using Tareas.Api.Models;

namespace Tareas.Api.Automapper.Tareas
{
    public class TareasMapperProfile : Profile
    {
        public TareasMapperProfile() 
        {
            CreateMap<TaskDTO, Tarea>(); // Mapeo desde el DTO a la entidad
            CreateMap<Tarea, TaskDTO>(); // Mapeo desde la entidad al DTO            
        }
    }
}
