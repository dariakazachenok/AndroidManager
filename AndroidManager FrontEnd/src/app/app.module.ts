import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { MultiselectDropdownModule } from "angular-2-dropdown-multiselect";

import { AppComponent } from "./app.component";
import { AlertService } from "./services/alert.service";
import { AuthenticationService } from "./authentication/authentication.service";
import { AuthGuard } from "./guards/auth.guard";
import { AppRoutingModule } from "./app-routing.module";

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
  declarations: [AppRoutingModule.components, AppComponent],
  providers: [AlertService, AuthenticationService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule {}
