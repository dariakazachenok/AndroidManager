using System.Collections.Generic;
using AndroidManager.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class AndroidsController : Controller
    {
        private readonly AndroidService androidService;
        private readonly IMapper mapper;

        public AndroidsController(AndroidService androidService, IMapper mapper)
        {
            this.androidService = androidService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var androids = androidService.GetAllAndroids();
            var dtoModels = mapper.Map<List<Android>, List<AndroidDTOModel>>(androids);

            return Ok(dtoModels);
        }

        [HttpPost]
        public ActionResult Create(AndroidBindModel androidBindModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var android = mapper.Map<Android>(androidBindModel);
            androidService.Create(android);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Update(int id)
        {
            var android = androidService.GetAndroidById(id);

            var dtoModel = mapper.Map<AndroidDTOModel>(android);

            return Ok(dtoModel);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, AndroidBindModel androidBindModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var android = androidService.GetAndroidById(id);
            mapper.Map(androidBindModel, android);

            androidService.Edit(android);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            androidService.Remove(id);

            return Ok();
        }
    }
}

