import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";
import { LoginModel } from "../models/login.model";
import { AppSettings } from "../appSettings";

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) {}

  login(loginModel: LoginModel) {
    return this.http
      .post<any>(`${AppSettings.API_ENDPOINT}auth/token`, loginModel)
      .pipe(
        map(user => {
          if (user && user.token) {
            localStorage.setItem("currentUser", JSON.stringify(user));
          }

          return user;
        })
      );
  }

  logout() {
    localStorage.removeItem("currentUser");
  }
}
