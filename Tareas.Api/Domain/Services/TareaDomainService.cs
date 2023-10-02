
using Microsoft.EntityFrameworkCore;
using Tareas.Api.Domain.Contracts;
using Tareas.Api.DTOs;
using Tareas.Api.Models;

namespace Tareas.Api.Domain.Services
{
    public class TareaDomainService : ITareaDomainService
    {
        #region Fields
        private readonly TareasContext _context;
        #endregion

        #region Builder
        public TareaDomainService(TareasContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region Methods
        public async Task<Tarea> CreateTasks(Tarea tarea)
        {         
            tarea.Id = tarea.Id == Guid.Empty ? Guid.NewGuid() : tarea.Id;
            tarea.FechaCreacion = tarea.FechaCreacion == DateTime.MinValue ? DateTime.Now : tarea.FechaCreacion;                
            
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return tarea;
        }

        public IQueryable<Tarea> GetAllTask()
        {
            return _context.Tareas.OrderByDescending(x => x.FechaCreacion);
        }

        public async Task<Tarea?> GetTask(Guid id)
        {
            return await _context.Tareas.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<Tarea> UpdateTask(TaskDTO taskDTO)
        {
            var tareaToUpdate = await _context.Tareas.FindAsync(taskDTO.Id);

            if (tareaToUpdate == null)
            {
                throw new InvalidOperationException("La tarea con el ID proporcionado no existe.");
            }

            //_context.Entry(tareaToUpdate).CurrentValues.SetValues(taskDTO); //actualizar una entidad usando Change Tracking a través del método SetValues
            tareaToUpdate.Title = taskDTO.Title ?? tareaToUpdate.Title;
            tareaToUpdate.Descripcion = taskDTO.Descripcion ?? tareaToUpdate.Descripcion;
            tareaToUpdate.Completado = taskDTO.Completado;
            tareaToUpdate.FechaActualizacion = DateTime.Now;

            await _context.SaveChangesAsync();

            return tareaToUpdate;
        }

        public async Task<Tarea?> DeleteTask(Guid id)
        {
            var tareaToDelete = await _context.Tareas.FindAsync(id);
            if (tareaToDelete == null)
                return null;

            _context.Tareas.Remove(tareaToDelete);
            await _context.SaveChangesAsync();
            return tareaToDelete;
        }
        public async Task<int> GetTaskCount()
        {
            return await _context.Tareas.CountAsync();
        }

        #endregion

    }
}
