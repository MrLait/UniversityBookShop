namespace UniversityBookShop.Application.Common.Models
{

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public ServiceResult(T value) => Data = value;
        public ServiceResult(T value, ServiceError error) : base(error) => Data = value;
        public ServiceResult(ServiceError error) : base(error) { }
    }

    public class ServiceResult
    {
        public bool IsSucceeded => Error == null;
        public ServiceError Error { get; set; }

        public ServiceResult() { }

        public ServiceResult(ServiceError error)
        {
            if (error == null)
            {
                Error = ServiceError.DefaultError;
            }

            Error = error;
        }

        public static ServiceResult Failed(ServiceError error) => new(error);

        public static ServiceResult<T> Success<T>(T value) => new(value);

        public static ServiceResult<T> Failed<T>(ServiceError error) => new(error);

    }


}
