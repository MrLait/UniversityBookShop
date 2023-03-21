namespace UniversityBookShop.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }

    public NotFoundException(string message)
        : base(message) { }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }

    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\"{key} not found.") { }

    public NotFoundException(string name, object keyFirst, object keySecond)
        : base($"Entity \"{name}\"{keyFirst}, {keySecond} not found.") { }
}
