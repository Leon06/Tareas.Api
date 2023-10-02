using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.Api.Application.Contracts;
using Tareas.Api.Constants;
using Tareas.Api.Domain.Contracts;
using Tareas.Api.DTOs;


namespace Tareas.Api.Application.Tarea
{
    public class TareaAppService : ITareaAppService
    {
        #region Fields
        private readonly ITareaDomainService _tareaDomainService;
        private readonly IMapper _mapper;
        #endregion

        #region Builder
        public TareaAppService(ITareaDomainService tareaDomainService, IMapper mapper)
        {
            _tareaDomainService = tareaDomainService ?? throw new ArgumentNullException(nameof(tareaDomainService));
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO data)
        {
            try
            {
                //Convertimos el DTO de entrada a la entidad Tarea
                var tareas = _mapper.Map<Models.Tarea>(data);
                var resultEntity = await _tareaDomainService.CreateTasks(tareas);
                //Convertimos la entidad resultante de vuelta a un DTO
                //List<TaskDTO> resultDTOs = _mapper.Map<List<TaskDTO>>(resultEntity);
                return new OkObjectResult(resultEntity);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorCreatingTask, detail = ex.Message });
            }

        }

        public async Task<ActionResult<List<TaskDTO>>> GetAllTask()
        {
            try
            {
                var tasks = await _tareaDomainService.GetAllTask().ToListAsync();
                var tasksDTOs = _mapper.Map<List<TaskDTO>>(tasks);
                return new OkObjectResult(tasksDTOs);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorGettingTasks, detail = ex.Message });

            }
        }

        public async Task<ActionResult<TaskDTO>>GetTask(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return new BadRequestObjectResult( ResponseMessages.InvalidGuid);

                var task = await _tareaDomainService.GetTask(id);
                if (task != null)
                {
                    var taskDTO = _mapper.Map<TaskDTO>(task);
                    return new OkObjectResult(taskDTO);               
                }
                else
                {
                    return new NotFoundObjectResult(ResponseMessages.TaskNotFound);
                }
            }
            catch(Exception ex) 
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorCreatingTask, detail = ex.Message });

            }
        }

        public async Task<IActionResult> UpdateTask(TaskDTO taskDTO)
        {
            try
            {
                if (taskDTO.Id == Guid.Empty)
                {
                    return new BadRequestObjectResult(ResponseMessages.InvalidGuid);
                }
                var updatedTask = await _tareaDomainService.UpdateTask(taskDTO);             
                return new OkObjectResult(new { updatedTask, message = ResponseMessages.UpdateSuccess });

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorUpdatingTask, detail = ex.Message });
            }
        }

        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    return new BadRequestObjectResult(ResponseMessages.InvalidGuid);
                }
                var response = await _tareaDomainService.DeleteTask(id);
                if(response != null)
                {
                    return new OkObjectResult(new {ID = response.Id, message = ResponseMessages.DeletionSuccess });
                }
                else
                {
                    return new NotFoundObjectResult(ResponseMessages.ErrorDeletingTask);
                }
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorDeletingTask, detail = ex.Message });
            }
        }

        public async Task<ActionResult<List<TaskDTO>>> GetPagedTasks(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                int totalTasks = await _tareaDomainService.GetTaskCount();
                int totalPages = (int)Math.Ceiling(totalTasks / (double)pageSize);

                var task = await _tareaDomainService.GetAllTask()
                            .Skip((pageIndex - 1)* pageSize)
                            .Take(pageSize)
                            .ToListAsync();
                var tasksDTOs = _mapper.Map<List<TaskDTO>>(task);

                var response = new PagedTasksResponse
                {
                    Data = tasksDTOs,
                    TotalItems = totalTasks,
                    TotalPages = totalPages,
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { error = ResponseMessages.ErrorGettingTasks, detail = ex.Message });

            }
        }
        #endregion

    }
}
