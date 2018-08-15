namespace Ddd.Application.Base.Dto
{
    public class ValidationFailureDto
    {
        public ValidationFailureDto(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}