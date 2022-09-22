import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { IAddSubjectGrade } from "../shared/AddSubjectGrade";
import { ICourse } from "../shared/Course";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { IStudent } from "../shared/Student";
import { ISubjectGrade } from "../shared/SubjectGrade";

@Injectable()
export class StudentService {

    constructor(private http: HttpClient) {

    }
    public students: IStudent[] = [];
    public token = "";
    public expiration = new Date();

    loadStudents(): Observable<void> {
        return this.http.get<[]>("/api/students")
            .pipe(map(data => {
                this.students = data;
                /*this.products = data;*/
            }));
    }
    addStudent(student: IStudent) {
        let headers = new HttpHeaders({ 'Access-Control-Allow-Origin': '*', 'content-type': 'application/json' });
        return this.http.post<any>("/api/Students", student)
            .pipe(map(data => {
                //this.token = data.token;
                //this.expiration = data.expiration;
            }));
    }

    addSubjectGrade(subjectGrade: IAddSubjectGrade) {
        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);

        return this.http.post<any>("/api/SubjectGrade", subjectGrade).pipe(map(data => {
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