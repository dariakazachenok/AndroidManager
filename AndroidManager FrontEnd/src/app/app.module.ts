import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from "./app.component";
import { JobsListComponent } from "./jobs/jobs-list/jobs-list.component";
import { JobDetailComponent } from "./jobs/job-detail/job-detail.component";
import { HomeComponent } from "./home/home.component";
import { AndroidsListComponent } from "./androids/androids-list/androids-list.component";
import { AndroidDetailComponent } from "./androids/android-detail/android-detail.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "jobs", component: JobsListComponent },
  { path: "androids", component: AndroidsListComponent },
  { path: "androids/create", component: AndroidDetailComponent },
  { path: "androids/edit/:id", component: AndroidDetailComponent },
  { path: "jobs/create", component: JobDetailComponent },
  { path: "jobs/edit/:id", component: JobDetailComponent }
];

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  declarations: [
    AppComponent,
    JobsListComponent,
    JobDetailComponent,
    HomeComponent,
    AndroidsListComponent,
    AndroidDetailComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
