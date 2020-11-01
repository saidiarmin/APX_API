using System.ComponentModel.DataAnnotations;

namespace Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Success")]
        Success = 0,

        [Display(Name = "Internal Server Error")]
        ServerError = 1,

        [Display(Name = "Bad Request")]
        BadRequest = 2,

        [Display(Name = "Not Found")]
        NotFound = 3,

        [Display(Name = "List Is Empty")]
        ListEmpty = 4,

        [Display(Name = "Logic Error")]
        LogicError = 5,

        [Display(Name = "UnAuthorized")]
        UnAuthorized = 6
    }
}
