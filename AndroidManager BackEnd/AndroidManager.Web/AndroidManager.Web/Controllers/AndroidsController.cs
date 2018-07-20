using AndroidManager.Web.Models;
using AndroidManager.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            return Ok(dtoModels);
        }

       /* [HttpPost]
        [Route("postImage")]
        public ActionResult PostImage()
        {
            string imageName = null;
            var formRequest = HttpContext.Request.Form;
            var postedFile = formRequest.Files["Image"];

            imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);


            var path = Path.Combine("Image/", imageName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                postedFile.CopyToAsync(stream);
            }

            return Ok();
        } */

        [HttpPost]
        public ActionResult Create([FromBody] AndroidBindModel androidBindModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

           /* string imageName = null;
            var formRequest = HttpContext.Request.Form;
            var postedFile = formRequest.Files["Image"];

            imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

            var path = Path.Combine("Image/", imageName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                postedFile.CopyToAsync(stream);
            } */

            var android = mapper.Map<Android>(androidBindModel);
            /*android.AvatarImage = imageName;*/
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

            if (android.Reliability == 0)
            {
                android.Status = false;
            }
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

