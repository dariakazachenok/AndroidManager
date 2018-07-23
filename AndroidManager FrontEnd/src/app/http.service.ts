import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AppSettings } from "./appSettings";
import { Job } from "./models/job.model";


@Injectable()
export class HttpService {
  constructor(private http: HttpClient) {}

  getJobs(incompleted:boolean = false) {
    return this.http.get<Array<Job>>(`${AppSettings.API_ENDPOINT}jobs?incompleted=${incompleted}`);
  }

  postJob(data: any) {
    return this.http.post(`${AppSettings.API_ENDPOINT}jobs`, data);
  }

  getJobById(id: number) {
    return this.http.get(`${AppSettings.API_ENDPOINT}jobs/${id.toString()}`);
  }

  putJob(id: number, data?: any) {
    return this.http.put(`${AppSettings.API_ENDPOINT}jobs/${id.toString()}`, data);
  }

  deleteJob(id: number) {
    return this.http.delete(`${AppSettings.API_ENDPOINT}jobs/${id.toString()}`);
  }

  getAndroids() {
    return this.http.get(`${AppSettings.API_ENDPOINT}androids`);
  }

  postAndroid(data: any) {
    return this.http.post(`${AppSettings.API_ENDPOINT}androids`, data);
  }

  getAndroidById(id: number) {
    return this.http.get(`${AppSettings.API_ENDPOINT}androids/${id.toString()}`);
  }

  putAndroid(id: number, data?: any) {
    return this.http.put(`${AppSettings.API_ENDPOINT}androids/${id.toString()}`, data);
  }

  deleteAndroid(id: number) {
    return this.http.delete(`${AppSettings.API_ENDPOINT}androids/${id.toString()}`);
  }

  assignJob(data: any) {
    return this.http.post(`${AppSettings.API_ENDPOINT}androids/assignJobs`, data);
  }
}
