using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.v1
{
    #region Swagger Annotations
    public class AddressDto
    {
        [Required]
        public string Country { get; set; }

        [DefaultValue("Kuala Lumpur")]
        public string City { get; set; }

        [JsonProperty("promo-code")]
        public string Code { get; set; }

        [JsonIgnore]
        public int Discount { get; set; }
    }
    #endregion

    [ApiVersion("1")]
    public class TestController : BaseController
    {
        [HttpPost("[action]")]
        [AllowAnonymous]
        public ActionResult UploadFile1(IFormFile file1)
        {
            return Ok();
        }

        [AddSwaggerFileUploadButton]
        [HttpPost("[action]")]
        [AllowAnonymous]
        public ActionResult UploadFile2()
        {
            var file = Request.Form.Files[0];
            return Ok();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        [SwaggerRequestExample(typeof(UserDto), typeof(CreateUserRequestExample))]
        [SwaggerResponseExample(200, typeof(CreateUserResponseExample))]
        [SwaggerResponse(200)]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable)]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult Address(AddressDto addressDto)
        {
            return Ok();
        }
    }

    public class CreateUserRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserDto
            {
                FullName = "Armin Saeedi",
                Age = 35,
                UserName = "admin",
                Email = "admin@site.com",
                Gender = Entities.GenderType.Male,
                Password = "1234567"
            };
        }
    }

    public class CreateUserResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserDto
            {
                FullName = "Armin Saeedi",
                Age = 35,
                UserName = "admin",
                Email = "admin@site.com",
                Gender = Entities.GenderType.Male,
                Password = "1234567"
            };
        }
    }
}
