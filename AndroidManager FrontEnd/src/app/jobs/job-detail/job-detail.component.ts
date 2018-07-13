import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { HttpService } from "../../http.service";
import { Job } from "../../models/job.model";

@Component({
  selector: "app-job-detail",
  templateUrl: "./job-detail.component.html",
  styleUrls: ["./job-detail.component.css"]
})
export class JobDetailComponent implements OnInit {
  jobForm: FormGroup;
  job: Job;
  jobId: number;
  controls: FormGroup;

  complexityLevels = [
    { name: "Level 1", id: 1 },
    { name: "Level 2", id: 2 },
    { name: "Level 3", id: 3 }
  ];

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.jobId = this.route.snapshot.params["id"];
    this.createJobForm();

    if (this.jobId) {
      this.httpService.getJobById(this.jobId).subscribe((resp: any) => {
        this.job = resp;
        this.populateForm();
      });
    }
  }

  populateForm() {
    this.jobForm.patchValue({
      name: this.job.jobName,
      description: this.job.description,
      complexitylevel: this.complexityLevels.filter(
        x => x.id == this.job.complexityLevel
      )[0]
    });
  }

  createJobForm() {
    this.jobForm = new FormGroup({
      jobName: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required),
      complexitylevel: new FormControl(
        this.complexityLevels[3],
        Validators.required
      )
    });
  }

  submitForm() {
    const model = this.prepareModel();

    if (!this.jobId) {
      this.httpService.postJob(model).subscribe(() => {
        this.router.navigate(["/jobs"]);
      });
    } else {
      this.httpService.putJob(this.jobId, model).subscribe(() => {
        this.router.navigate(["/jobs"]);
      });
    }
  }

  prepareModel(): Job {
    const formModel = this.jobForm.value;
    return {
      id: this.jobId,
      jobName: formModel.jobName,
      description: formModel.description,
      complexityLevel: formModel.complexitylevel.id
    };
  }
}
