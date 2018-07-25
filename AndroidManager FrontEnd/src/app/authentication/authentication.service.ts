import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";

import { LoginModel } from "../models/login.model";
import { AppSettings } from "../appSettings";
import { Operator } from "../models/operator";

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) {}

  login(loginModel: LoginModel) {
    return this.http
      .post<any>(`${AppSettings.API_ENDPOINT}auth/token`, loginModel)
      .pipe(
        map(operator => {
          if (operator && operator.token) {
            localStorage.setItem("currentOperator", JSON.stringify(operator));
          }

          return operator;
        })
      );
  }

  logout() {
    localStorage.removeItem("currentOperator");
  }

  create(operator: Operator) {
    return this.http.post(`${AppSettings.API_ENDPOINT}auth/register`, operator);
  }
}
