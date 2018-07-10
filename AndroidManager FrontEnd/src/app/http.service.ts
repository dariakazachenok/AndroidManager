import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
  
@Injectable()
export class HttpService{
  
    constructor(private http: HttpClient){ }
    private jobsUrl = 'http://localhost:64845/api/jobs';
    getData(){
        return this.http.get("http://localhost:64845/api/values")
    }

    getJobs(){
        return this.http.get(`${this.jobsUrl}`)
    }

    postJob(data: any){
        return this.http.post(`${this.jobsUrl}`, data)
    }
}