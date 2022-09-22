import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { ICourse } from "../shared/Course";
import { LoginRequest, LoginResults } from "../shared/LoginResults";

@Injectable()
export class Store {

  constructor(private http: HttpClient) {

  }

  public courses: ICourse[] = [];
  public token = "";
  public expiration = new Date();

  loadProducts(): Observable<void> {
      return this.http.get<[]>("/api/course")
        .pipe(map(data => {
            this.courses = data;
          /*this.products = data;*/
        return;
      }));
  }

  get loginRequired(): boolean {
    return this.token.length === 0 || this.expiration > new Date();
  }

  login(creds: LoginRequest) {
    return this.http.post<LoginResults>("/account/createtoken", creds)
      .pipe(map(data => {
        this.token = data.token;
        this.expiration = data.expiration;
      }));
  }


}