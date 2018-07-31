import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { HttpService } from "../../http.service";
import { Job } from "../../models/job.model";

@Component({
  selector: "app-jobs-list",
  templateUrl: "./jobs-list.component.html",
  styleUrls: ["./jobs-list.component.css"]
})
export class JobsListComponent implements OnInit {
  jobs: Array<Job>;

  constructor(private httpService: HttpService, private router: Router) {}

  ngOnInit() {
    this.httpService.getJobs().subscribe((jobs) => (this.jobs = jobs));
  }

  editJob(jobId: number) : void {
    this.router.navigate(["/jobs/edit/", jobId]);
  }

  deleteJob(jobId: number) {
    if (confirm("Are you sure you want to delete the job?")) {
      this.httpService.deleteJob(jobId).subscribe(() => {
        this.jobs = this.jobs.filter(x => x.id !== jobId);
      });
    }
  }
}
