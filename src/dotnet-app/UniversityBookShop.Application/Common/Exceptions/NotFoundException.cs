namespace UniversityBookShop.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }

    public NotFoundException(string message)
        : base(message) { }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }

    public NotFoundException(string name, object key)
        : base($"Entity with name: '{name}'; Id: '{key}' was not found.") { }

    public NotFoundException(string name, object keyFirst, object keySecond)
        : base($"Entity with name: '{name}'; First id: '{keyFirst}'; Second id: '{keySecond}' was not found.") { }
}
