namespace UniversityBookShop.Application.Common.Models.ServicesModels
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
            Error = error ?? ServiceError.DefaultError;
        }

        public static ServiceResult Failed(ServiceError error) => new(error);
        public static ServiceResult<T> Failed<T>(T data, ServiceError error) => new(data, error);
        public static ServiceResult<T> Failed<T>(ServiceError error) => new(error);


        public static ServiceResult<T> Success<T>(T value) => new(value);


    }


}
