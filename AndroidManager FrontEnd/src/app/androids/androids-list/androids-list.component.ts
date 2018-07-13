import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { HttpService } from "../../http.service";
import { Android } from "../../models/android.model";

@Component({
  selector: "app-androids-list",
  templateUrl: "./androids-list.component.html",
  styleUrls: ["./androids-list.component.css"]
})
export class AndroidsListComponent implements OnInit {
  androids: Array<Android>;

  constructor(private httpService: HttpService, private router: Router) {}

  ngOnInit() {
    this.httpService
      .getAndroids()
      .subscribe((androids: any) => (this.androids = androids));
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
}
