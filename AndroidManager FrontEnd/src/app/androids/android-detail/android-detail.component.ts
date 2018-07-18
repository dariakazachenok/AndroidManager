import { Component, OnInit, ElementRef, ViewChild } from "@angular/core";
import { Headers, RequestOptions } from "@angular/http";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { HttpService } from "../../http.service";
import { Android } from "../../models/android.model";

@Component({
  selector: "app-android-detail",
  templateUrl: "./android-detail.component.html",
  styleUrls: ["./android-detail.component.css"]
})
export class AndroidDetailComponent implements OnInit {
  androidForm: FormGroup;
  android: Android;
  controls: FormGroup;
  androidId: number;
  status: boolean;
  headers: Headers = new Headers();
  imageUrl: string = "../../../assets/img/default-image.jpg";
  fileToUpload: File = null;

  @ViewChild("fileInput") fileInput: ElementRef;

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createAndroidForm();
    this.androidId = this.route.snapshot.params["id"];

    if (this.androidId) {
      this.httpService.getAndroidById(this.androidId).subscribe((resp: any) => {
        this.android = resp;
        this.populateForm();
      });
    }
  }

  createAndroidForm() {
    this.androidForm = this.fb.group({
      androidName: ["", Validators.required],
      avatarImage: null,
      skills: ["", Validators.required],
      reliability: [{ value: "10", disabled: true }, , Validators.required]
    });
  }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      let file = event.target.files[0];
      this.androidForm.get("avatarImage").setValue(file);
    }
  }

  populateForm() {
    this.androidForm.patchValue({
      androidName: this.android.androidName,
      avatarImage: this.android.avatarImage,
      skills: this.android.reliability,
      reliability: this.android.reliability
    });
  }

  submitForm() {
    const model = this.prepareModel();

    let options = new RequestOptions();
    if (model.image) {
      let headers = new Headers();
      headers.set("Content-Type", "application/octet-stream");
      headers.set("Upload-Content-Type", model.image.type);

      this.headers = headers;
      options.headers = this.headers;
    }
    /*    const formData = new FormData();
    formData.append('Image', this.fileToUpload, this.fileToUpload.name)*/

    if (!this.androidId) {
      this.httpService.postAndroid(model, options).subscribe(() => {
        this.router.navigate(["/androids"]);
      });
    } else {
      this.httpService.putAndroid(this.androidId, model).subscribe(() => {
        this.router.navigate(["/androids"]);
      });
    }
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  prepareModel(): any {
    const formControls = this.androidForm.controls;
    return {
      id: this.androidId,
      androidName: formControls.androidName.value,
      skills: formControls.skills.value,
      reliability: formControls.reliability.value,
      image: formControls.avatarImage.value,
      status: true
    };
  }
}
