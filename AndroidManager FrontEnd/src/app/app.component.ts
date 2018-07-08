import { Component, OnInit } from "@angular/core";
import { HttpService} from './http.service';

@Component({
  selector: "my-app",
  templateUrl: "./app.component.html",
  providers: [HttpService]
})
export class AppComponent implements OnInit {
  public values: any;
  constructor(private httpService: HttpService) {}

  ngOnInit() {
    
    this.httpService.getData().subscribe((data:any) => this.values=data);
  }
}
