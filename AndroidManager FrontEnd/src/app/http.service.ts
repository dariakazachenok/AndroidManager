import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { RequestOptions } from "@angular/http";

@Injectable()
export class HttpService {
  constructor(private http: HttpClient) { }
  private jobsUrl = "http://localhost:64845/api/jobs";
  private androidsUrl = "http://localhost:64845/api/androids";

  getData() {
    return this.http.get("http://localhost:64845/api/values");
  }

  getJobs() {
    return this.http.get(`${this.jobsUrl}`);
  }

  postJob(data: any) {
    return this.http.post(`${this.jobsUrl}`, data);
  }

  getJobById(id: number) {
    return this.http.get(`${this.jobsUrl}/${id.toString()}`);
  }

  putJob(id: number, data?: any) {
    return this.http.put(`${this.jobsUrl}/${id.toString()}`, data);
  }

  deleteJob(id: number) {
    return this.http.delete(`${this.jobsUrl}/${id.toString()}`);
  }

  getAndroids() {
    return this.http.get(`${this.androidsUrl}`);
  }

  postAndroid(data: any, options: any) {
    return this.http.post(`${this.androidsUrl}`, data, options);
  }

  getAndroidById(id: number) {
    return this.http.get(`${this.androidsUrl}/${id.toString()}`)
  }

  putAndroid(id: number, data?: any) {
    return this.http.put(`${this.androidsUrl}/${id.toString()}`, data)
  }

  deleteAndroid(id: number) {
    return this.http.delete(`${this.androidsUrl}/${id.toString()}`);
  }

  assignJob(data: any) {
    debugger;
    return this.http.post(`${this.androidsUrl}/assignJobs`, data)
  }
}
