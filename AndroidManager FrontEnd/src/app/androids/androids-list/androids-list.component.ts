import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import {
  IMultiSelectOption,
  IMultiSelectSettings
} from "angular-2-dropdown-multiselect";
import { forkJoin } from "rxjs";

import { HttpService } from "../../http.service";
import { Android } from "../../models/android.model";
import { Job } from "../../models/job.model";

@Component({
  selector: "app-androids-list",
  templateUrl: "./androids-list.component.html",
  styleUrls: ["./androids-list.component.css"]
})
export class AndroidsListComponent implements OnInit {
  androids: Array<Android>;
  jobs: Array<Job>;
  closeResult: string;
  jobItems: IMultiSelectOption[];
  androidId: number;
  jobId: number;
  modalReference: any;
  optionsModel: number[];
  defaultImg: string = "../../../assets/img/default-image.jpg";
  isInvalidCount = false;

  jobSelectSettings: IMultiSelectSettings = {
    enableSearch: true,
    dynamicTitleMaxItems: 10,
    displayAllSelectedText: true
  };
  constructor(
    private httpService: HttpService,
    private router: Router,
    private modalService: NgbModal
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    forkJoin([
      this.httpService.getAndroids(),
      this.httpService.getJobs(true)
    ]).subscribe((data: any) => {
      this.androids = data[0];
      this.androids.forEach(
        x =>
          (x.avatarImage = x.avatarImage
            ? "data:image/jpeg;base64," + x.avatarImage
            : this.defaultImg)
      );
      this.jobs = data[1];
      this.jobItems = this.jobs.map((opt: Job) => ({
        id: opt.id,
        name: opt.jobName
      }));
    });
  }

  openDialog(content) {
    this.modalReference = this.modalService.open(content, { centered: true });
  }

  editAndroid(androidId: number) {
    this.router.navigate(["/androids/edit/", androidId]);
  }

  deleteAndroid(androidId: number) {
    if (confirm("Are you sure you want to delete the android?")) {
      this.httpService.deleteAndroid(androidId).subscribe(() => {
        this.androids = this.androids.filter(x => x.id !== androidId);
      });
    }
  }

  onChangeJob(event: Array<number>, reliability: number) {
    event.length > reliability
      ? (this.isInvalidCount = true)
      : (this.isInvalidCount = false);
  }

  assignJobs(androidId: number) {
    if (!this.optionsModel || this.optionsModel.length === 0) {
      this.modalReference.close();
      return;
    }

    let jobIds = Array<number>();
    this.optionsModel.forEach(x => jobIds.push(x));
    const model = { jobIds: jobIds, androidId: androidId };
    this.httpService.assignJobs(model).subscribe(() => {
      this.loadData();
      this.optionsModel = [];
      this.modalReference.close();
    });
  }

  closeDialog() {
    this.optionsModel = [];
    this.modalReference.close();
  }
}
