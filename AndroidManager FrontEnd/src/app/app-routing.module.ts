import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from "./guards/auth.guard";
import { JobsListComponent } from "./jobs/jobs-list/jobs-list.component";
import { AndroidsListComponent } from "./androids/androids-list/androids-list.component";
import { AndroidDetailComponent } from "./androids/android-detail/android-detail.component";
import { JobDetailComponent } from "./jobs/job-detail/job-detail.component";
import { LoginComponent } from "./authentication/login/login.component";
import { NotFoundComponent } from "./authentication/not-found/not-found.component";
import { NotAccessComponent } from "./authentication/not-access/not-access.component";

const routes: Routes = [
  { path: "", component: HomeComponent, canActivate: [AuthGuard] },
  { path: "jobs", component: JobsListComponent, canActivate: [AuthGuard] },
  {
    path: "androids",
    component: AndroidsListComponent, canActivate: [AuthGuard]
   
  },
  { path: "androids/create", component: AndroidDetailComponent },
  { path: "androids/edit/:id", component: AndroidDetailComponent },
  { path: "jobs/create", component: JobDetailComponent },
  { path: "jobs/edit/:id", component: JobDetailComponent },
  { path: "login", component: LoginComponent },
  { path: "not-access", component: NotAccessComponent },
  { path: "**", component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
    static components = [
        HomeComponent,
        AndroidDetailComponent,
        AndroidsListComponent,
        JobDetailComponent,
        JobsListComponent,
        LoginComponent,
        NotAccessComponent,
        NotFoundComponent
      ];
}
