import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { IAddSubject } from "../shared/addSubject";
import { ICourse } from "../shared/Course";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { ISubject } from "../shared/Subject";
import { ITeacher } from "../shared/Teacher";

@Injectable()
export class SubjectService {

    constructor(private http: HttpClient) {

    }
    public subj: ISubject[] = [];
    public teachers: ITeacher[] = [];
    public token = "";
    public expiration = new Date();

    loadSubjects(): Observable<void> {
        return this.http.get<[]>("/api/subjects")
            .pipe(map(data => {
                this.subj = data;
                /*this.products = data;*/
                return;
            }));
    }

    addSubject(subject: IAddSubject) {
        subject.teacherId = 1;
        return this.http.post<any>("/api/Subjects", subject)
            .pipe(map(data => {
                //this.token = data.token;
                //this.expiration = data.expiration;
            }));
    }


    

    loadTeachers(): Observable<void> {
        return this.http.get<[]>("/api/Teachers")
            .pipe(map(data => {
                this.teachers = data;
            }));
    }

    addTeacher(teacher: ITeacher) {
        let headers = new HttpHeaders({ 'Access-Control-Allow-Origin': '*', 'content-type': 'application/json' });
        return this.http.post<any>("/api/Teachers", teacher)
            .pipe(map(data => {
                //this.token = data.token;
                //this.expiration = data.expiration;
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