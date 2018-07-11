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

    getJobById(id: number){
        return this.http.get(`${this.jobsUrl}/${id.toString()}`)
    }

    putJob(id: number, data?: any) {
        return this.http.put(`${this.jobsUrl}/${id.toString()}`, data);
    }

    public deleteJob(id: number) {
        return this.http.delete(`${this.jobsUrl}/${id.toString()}`);
      }
}