import {
  Component,
  OnInit,
  ElementRef,
  ViewChild,
  ChangeDetectorRef
} from "@angular/core";
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

  fileToUpload: File = null;
  defaultImg: string = "../../../assets/img/default-image.jpg";

  @ViewChild("fileInput") fileInput: ElementRef;

  constructor(
    private httpService: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private cd: ChangeDetectorRef
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
    this.setDefaultImage();
  }

  setDefaultImage() {
    this.androidForm.controls.avatarImage.setValue(this.defaultImg);
  }

  createAndroidForm() {
    this.androidForm = this.fb.group({
      androidName: [
        "",
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(24)
        ])
      ],
      avatarImage: ["", Validators.required],
      skills: ["", Validators.required],
      reliability: [{ value: "10", disabled: true }]
    });
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length) {
      this.fileToUpload = event.target.files[0];
      var reader = new FileReader();

      const imageName = this.fileToUpload.name;
      reader.readAsDataURL(this.fileToUpload);
      reader.onload = () => {
        this.androidForm.controls.avatarImage.setValue(reader.result);
      };
    }
  }

  populateForm() {
    this.androidForm.patchValue({
      androidName: this.android.androidName,
      skills: this.android.skills,
      reliability: this.android.reliability,
      avatarImage: this.android.avatarImage
        ? "data:image/jpeg;base64," + this.android.avatarImage
        : this.defaultImg
    });
  }

  submitForm() {
    const model = this.prepareModel();

    if (!this.androidId) {
      this.httpService.postAndroid(model).subscribe(() => {
        this.router.navigate(["/androids"]);
      });
    } else {
      this.httpService.putAndroid(this.androidId, model).subscribe(() => {
        this.router.navigate(["/androids"]);
      });
    }
  }

  prepareModel(): any {
    const formControls = this.androidForm.controls;
    return {
      id: this.androidId,
      androidName: formControls.androidName.value,
      skills: formControls.skills.value,
      reliability: formControls.reliability.value,
      avatarImage:
        formControls.avatarImage.value === this.defaultImg
          ? null
          : formControls.avatarImage.value,
      status: true
    };
  }
}
