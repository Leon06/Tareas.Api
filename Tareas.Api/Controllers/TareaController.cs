using Microsoft.AspNetCore.Mvc;
using Tareas.Api.Application.Contracts;
using Tareas.Api.DTOs;

namespace Tareas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        #region Fields
        //<summary>
        //Instanciar al servicio
        //</summary>
        private readonly ITareaAppService _tareaAppService; //_ por convencion que indica que la variable es privada
        #endregion

        #region Builder
        public TareaController(ITareaAppService tareaAppService)
        {
            _tareaAppService = tareaAppService ?? throw new ArgumentNullException(nameof(tareaAppService));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Crea una tarea en el sistema.
        /// </summary>
        /// <param name="data">Información de las tareas a crear.</param>        
        /// <returns>Lista de tareas creadas.</returns>
        [HttpPost]
        [Route(nameof(TareaController.CreateTask))]
        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO data)
        {
            return await _tareaAppService.CreateTask(data);
        }

        /// <summary>
        /// Obtiene todas las tareas existentes en el sistema.
        /// </summary>
        /// <returns>Lista de todas las tareas.</returns>
        [HttpGet]
        [Route(nameof(TareaController.GetAllTask))]
        public async Task<ActionResult<List<TaskDTO>>> GetAllTask()
        {
            return await _tareaAppService.GetAllTask();
        }

        /// <summary>
        /// Obtiene una tarea específica por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la tarea a obtener.</param>
        /// <returns>Información detallada de la tarea solicitada.</returns>
        [HttpGet]
        [Route(nameof(TareaController.GetTask))]
        public async Task<ActionResult<TaskDTO>> GetTask(Guid id)
        {
            return await _tareaAppService.GetTask(id);
        }

        /// <summary>
        /// Actualiza la información de una tarea específica.
        /// </summary>
        /// <param name="taskDTO">Datos actualizados de la tarea.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut]
        [Route(nameof(TareaController.UpdateTask))]
        public async Task<IActionResult> UpdateTask(TaskDTO taskDTO)
        {
            return await _tareaAppService.UpdateTask(taskDTO);
        }

        /// <summary>
        /// Elimina una tarea específica del sistema.
        /// </summary>
        /// <param name="id">Identificador de la tarea a eliminar.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete]
        [Route(nameof(TareaController.DeleteTask))]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            return await _tareaAppService.DeleteTask(id);
        }

        /// <summary>
        /// Obtiene todas las tareas existentes en el sistema por paginacion
        /// </summary>
        /// <param name="pageIndex">Identificador de ...</param>
        /// /// <param name="pageSize">Identificador de ...</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpGet]
        [Route(nameof(TareaController.GetPagedTasks))]
        public async Task<ActionResult<List<TaskDTO>>> GetPagedTasks(int pageIndex = 1, int pageSize = 10)
        {
            return await _tareaAppService.GetPagedTasks(pageIndex, pageSize);
        }


        #endregion
    }
}
