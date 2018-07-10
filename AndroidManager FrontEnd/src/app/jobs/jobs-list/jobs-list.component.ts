import { Component, OnInit } from "@angular/core";
import { HttpService } from "../../http.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-jobs-list",
  templateUrl: "./jobs-list.component.html",
  styleUrls: ["./jobs-list.component.css"]
})
export class JobsListComponent implements OnInit {
  jobs;

  constructor(private httpService: HttpService, private router: Router) {}

  ngOnInit() {
    this.httpService.getJobs().subscribe((jobs: any) => (this.jobs = jobs));
  }

  editJob(jobId: number) {
    this.router.navigate(["/jobs/edit/", jobId]);
  }
}
