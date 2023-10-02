using Tareas.Api.DTOs;
using Tareas.Api.Models;

namespace Tareas.Api.Domain.Contracts
{
    public interface ITareaDomainService
    {
        /// <summary>
        /// Crea una tarea en el sistema.
        /// </summary>     
        Task<Tarea> CreateTasks(Tarea tarea);

        /// <summary>
        /// Obtiene todas las tareas existentes en el sistema.
        /// </summary>     
        IQueryable<Tarea> GetAllTask();

        /// <summary>
        /// Obtiene una tarea específica por su identificador.
        /// </summary>       
        Task<Tarea?> GetTask(Guid id);

        /// <summary>
        /// Actualiza la información de una tarea específica.
        /// </summary>        
        Task<Tarea> UpdateTask(TaskDTO taskDTO);

        /// <summary>
        /// Elimina una tarea específica del sistema.
        /// </summary>      
        Task<Tarea?> DeleteTask(Guid id);

        Task<int> GetTaskCount();
    }
}
