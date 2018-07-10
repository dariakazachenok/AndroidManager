import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { HttpService } from "../../http.service";

@Component({
  selector: "app-job-detail",
  templateUrl: "./job-detail.component.html",
  styleUrls: ["./job-detail.component.css"]
})
export class JobDetailComponent implements OnInit {
  jobForm: FormGroup;
  createProjectForm: FormGroup;
  jobId: number;
  levels = {
    ONE: 1,
    TWO: 2
  };

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.jobId = this.route.snapshot.params["id"];
    this.createForm();
  }

  createForm() {
    this.jobForm = new FormGroup({
      name: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required),
      complexitylevel: new FormControl("", Validators.required)
    });
  }

  submitForm() {
    debugger;
    const formModel = this.jobForm.value;
    const data = {
      name: formModel.name,
      description: formModel.description,
      complexitylevel: formModel.complexitylevel
    };

    this.httpService.postJob(data).subscribe();
    this.router.navigate(["/jobs"]);
  }
}
