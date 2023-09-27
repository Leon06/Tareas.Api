using Microsoft.AspNetCore.Mvc;
using Tareas.Api.Constants;

namespace Tareas.Api.Constants
{
    public static class ResponseMessages
    {
        public const string ErrorCreatingTask = "Ocurrió un error al crear la tarea.";
        public const string ErrorGettingTasks = "Ocurrió un error al obtener las tareas.";
        public const string ErrorGettingTask = "Ocurrió un error al obtener la tarea.";
        public const string ErrorUpdatingTask = "Ocurrió un error al actualizar la tarea.";
        public const string ErrorDeletingTask = "Ocurrió un error al eliminar la tarea.";
        public const string InvalidGuid = "El Guid proporcionado es inválido.";
        public const string TaskNotFound = "No se encontró una tarea con el Id proporcionado.";
        public const string UpdateSuccess = "Actualización exitosa";
        public const string DeletionSuccess = "Elimación exitosa";

    }
}