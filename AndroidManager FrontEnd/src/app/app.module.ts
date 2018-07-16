import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule, Routes } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { MultiselectDropdownModule } from "angular-2-dropdown-multiselect";

import { AppComponent } from "./app.component";
import { JobsListComponent } from "./jobs/jobs-list/jobs-list.component";
import { JobDetailComponent } from "./jobs/job-detail/job-detail.component";
import { HomeComponent } from "./home/home.component";
import { AndroidsListComponent } from "./androids/androids-list/androids-list.component";
import { AndroidDetailComponent } from "./androids/android-detail/android-detail.component";
import { LoginComponent } from "./authentication/login/login.component";
import { RegisterComponent } from "./authentication/register/register.component";
import { NotAccessComponent } from "./authentication/not-access/not-access.component";
import { NotFoundComponent } from "./authentication/not-found/not-found.component";
import { AlertService } from "./services/alert.service";
import { UserService } from "./services/user.service";
import { AuthenticationService } from "./authentication/authentication.service";
import { JwtInterceptor } from "./helpers/jwt.interceptor";
import { fakeBackendProvider } from "./helpers/fake-backend";
import { AuthGuard } from "./guards/auth.guard";

const routes: Routes = [
  { path: "", component: HomeComponent, canActivate: [AuthGuard] },
  { path: "jobs", component: JobsListComponent, canActivate: [AuthGuard] },
  {
    path: "androids",
    component: AndroidsListComponent,
    canActivate: [AuthGuard]
  },
  { path: "androids/create", component: AndroidDetailComponent },
  { path: "androids/edit/:id", component: AndroidDetailComponent },
  { path: "jobs/create", component: JobDetailComponent },
  { path: "jobs/edit/:id", component: JobDetailComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "not-access", component: NotAccessComponent },
  { path: "**", component: NotFoundComponent }
];

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(routes),
    MultiselectDropdownModule,
    CommonModule
  ],
  declarations: [
    AppComponent,
    JobsListComponent,
    JobDetailComponent,
    HomeComponent,
    AndroidsListComponent,
    AndroidDetailComponent,
    LoginComponent,
    RegisterComponent,
    NotAccessComponent,
    NotFoundComponent
  ],
  providers: [
    AlertService,
    UserService,
    AuthenticationService,
    AuthGuard,

    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  /* static components = [
    LoginComponent
  ];*/
}
