using Microsoft.AspNetCore.Mvc;
using Tareas.Api.DTOs;

namespace Tareas.Api.Application.Contracts
{
    public interface ITareaAppService
    {
        /// <summary>
        /// Crea una tarea en el sistema.
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<TaskDTO>> CreateTask(TaskDTO data);

        /// <summary>
        /// Obtiene todas las tareas existentes en el sistema.
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<List<TaskDTO>>> GetAllTask();

        /// <summary>
        /// Obtiene una tarea específica por su identificador.
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<TaskDTO>> GetTask(Guid id);

        /// <summary>
        /// Actualiza la información de una tarea específica.
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> UpdateTask(TaskDTO taskDTO);

        /// <summary>
        /// Elimina una tarea específica del sistema.
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> DeleteTask(Guid id);

        Task<ActionResult<List<TaskDTO>>> GetPagedTasks(int pageIndex = 1, int pageSize = 10);
    }
}
