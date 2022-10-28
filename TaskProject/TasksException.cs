using System;

namespace TaskProject
{
    public class TasksException : Exception
    {
        public TasksException(string message = "", Exception innerException = null) : 
            base(message, innerException) 
        { }      
    }
}
