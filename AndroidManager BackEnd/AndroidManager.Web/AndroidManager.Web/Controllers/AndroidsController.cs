using System.Collections.Generic;
using AndroidManager.Web.Models;
using AndroidManager.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class AndroidsController : Controller
    {
        private readonly AndroidService androidService;
        private readonly JobService jobService;
        private readonly IMapper mapper;

        public AndroidsController(AndroidService androidService, JobService jobService, IMapper mapper)
        {
            this.androidService = androidService;
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var androids = androidService.GetAllAndroids();
            var dtoModels = mapper.Map<List<Android>, List<AndroidDTOModel>>(androids);

            var jobs = jobService.GetNotComplitedJobs();
            var jobsDto = mapper.Map<List<Job>, List<JobDTOModel>>(jobs);

            return Ok(new { androids = dtoModels, jobs = jobsDto });
        }

        [HttpPost]
        public ActionResult Create([FromBody] AndroidBindModel androidBindModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var android = mapper.Map<Android>(androidBindModel);
            androidService.Create(android);
            return Ok();
        }

        [HttpPost]
        [Route("assignJobs")]
        public ActionResult AssignJobs([FromBody] AssignJobsModel assignJobsModel)
        {
            var androidId = assignJobsModel.AndroidId;
            var android = androidService.GetAndroidById(assignJobsModel.AndroidId);
            var jobs = jobService.GetJobsByIds(assignJobsModel.JobIds);

            android.Reliability = android.Reliability - jobs.Count;
            androidService.Edit(android);

            jobs.ForEach(job =>
            {
                job.ComplexityLevel = job.ComplexityLevel - 1;
                job.AndroidJobs.Add(new AndroidJob
                {
                    AndroidId = androidId,
                    JobId = job.Id.Value
                });
                jobService.Edit(job);
               /* android.AndroidJobs.Add(new AndroidJob
                {
                    AndroidId = androidId,
                    JobId = job.Id.Value
                }); */

            });
         

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
        public ActionResult Update(int id, [FromBody] AndroidBindModel androidBindModel)
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

