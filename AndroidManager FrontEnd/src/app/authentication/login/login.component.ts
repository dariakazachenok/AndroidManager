import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Injectable } from "@angular/core";

import { AlertService } from "../../services/alert.service";
import { AuthenticationService } from "../authentication.service";
import { LoginModel } from "../../models/login.model";

@Component({ templateUrl: "./login.component.html" })
@Injectable()
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  loginModel: LoginModel;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ["", Validators.required],
      password: ["", Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;

    this.loginModel = this.prepareLoginModel();

    this.authenticationService.login(this.loginModel).subscribe(
      () => {
        this.router.navigate([this.returnUrl]);
      },
      error => {
        this.alertService.error(error);
        this.loading = false;
      }
    );
  }

  prepareLoginModel(): LoginModel {
    const formControls = this.loginForm.controls;
    return {
      email: formControls.email.value,
      password: formControls.password.value
    };
  }
}
