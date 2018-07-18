import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { MultiselectDropdownModule } from "angular-2-dropdown-multiselect";

import { AppComponent } from "./app.component";
import { JobsListComponent } from "./jobs/jobs-list/jobs-list.component";
import { JobDetailComponent } from "./jobs/job-detail/job-detail.component";
import { AndroidsListComponent } from "./androids/androids-list/androids-list.component";
import { AndroidDetailComponent } from "./androids/android-detail/android-detail.component";
import { LoginComponent } from "./authentication/login/login.component";
import { NotAccessComponent } from "./authentication/not-access/not-access.component";
import { NotFoundComponent } from "./authentication/not-found/not-found.component";
import { AlertService } from "./services/alert.service";
import { AuthenticationService } from "./authentication/authentication.service";
import { AuthGuard } from "./guards/auth.guard";
import { AppRoutingModule } from "./app-routing.module";
import { HomeComponent } from "./home/home.component";

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([]),
    MultiselectDropdownModule,
    CommonModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    JobsListComponent,
    JobDetailComponent,
    AndroidsListComponent,
    AndroidDetailComponent,
    LoginComponent,
    NotAccessComponent,
    NotFoundComponent,
    HomeComponent
  ],
  providers: [
    AlertService,
    AuthenticationService,
    AuthGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
