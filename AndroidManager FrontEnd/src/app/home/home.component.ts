import { Component, OnInit } from "@angular/core";
import { LoginModel } from "../models/login.model";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  currentOperator: LoginModel;

  constructor() {
    this.currentOperator = JSON.parse(localStorage.getItem("currentOperator"));
  }

  ngOnInit() {}

}
