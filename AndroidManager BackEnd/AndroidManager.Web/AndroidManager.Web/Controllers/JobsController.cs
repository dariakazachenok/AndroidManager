using AndroidManager.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : Controller
    {
        private readonly JobService jobService;
        private readonly IMapper mapper;

        public JobsController(JobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(bool incompleted)
        {
            var jobs = jobService.GetAllJobs(incompleted);
            var dtoModels = mapper.Map<List<Job>, List<JobDTOModel>>(jobs);

            return Ok(dtoModels);
        }

        [HttpPost]
        public ActionResult Create([FromBody] JobBindModel jobBindModel)
        {
            var job = mapper.Map<Job>(jobBindModel);
            jobService.Create(job);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Update(int id)
        {
            var job = jobService.GetJobById(id);

            var dtoModel = mapper.Map<JobDTOModel>(job);

            return Ok(dtoModel);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] JobBindModel jobBindModel)
        {
            var job = jobService.GetJobById(id);
            mapper.Map(jobBindModel, job);

            jobService.Edit(job);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            jobService.Remove(id);

            return Ok();
        }
    }
}
