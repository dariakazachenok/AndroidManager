using AndroidManager.Web.Models.BindModel.AssingTaskAndroid;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class AssingTaskAndroidsController : Controller
    {
        private readonly AssingTaskAndroidService assingTaskAndroidService;
        private readonly IMapper mapper;

        public AssingTaskAndroidsController(AssingTaskAndroidService assingTaskAndroidService, IMapper mapper)
        {
            this.assingTaskAndroidService = assingTaskAndroidService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var assingTaskAndroids = assingTaskAndroidService.GetAllAssingTaskAndroids();
           var dtoModels = mapper.Map<List<AssingTaskAndroid>, List<AssingTaskAndroidDTOModel>>(assingTaskAndroids);

            return Ok(dtoModels);
        } 
    }
}
