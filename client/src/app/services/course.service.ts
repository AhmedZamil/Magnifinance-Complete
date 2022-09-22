import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { ICourse, ICreateCourse } from "../shared/Course";
import * as signalR from '@aspnet/signalr'; 

@Injectable()
export class Course {

    constructor(private http: HttpClient) {

    }

    public courses: ICourse[] = [];
    public token = "";
    public expiration = new Date();
    public connection = null;

    loadCourses(): Observable<void> {
        return this.http.get<[]>("/api/course")
            .pipe(map(data => {
                this.courses = data;
                /*this.products = data;*/
                return;
            }));
    }

    //useSignalR

    //useSignalR(): Observable<void> {

    

    //    this.connection = new signalR.HubConnectionBuilder()
    //        .withUrl("/universityhub")
    //        .build();

    //    this.connection.on("ReceiveOrderUpdate", (update) => {
    //        const statusDiv = document.getElementById("status");
    //        statusDiv.innerHTML = update;
    //    }
    //    );

    //    this.connection.on("NewOrder", function (order) {
    //        var statusDiv = document.getElementById("status");
    //        statusDiv.innerHTML = "Someone ordered an " + order.product;
    //    }
    //    );

    //    this.connection.on("finished", function () {
    //        this.connection.stop();
    //    }
    //    );

    //    this.connection.start().then(function () {
    //        console.log('SignalR Connected!');
    //    })
    //        .catch(function (err) {
    //            return console.error(err.toString());
    //        });

       

    //    return this.http.get<[]>("/api/course")
    //        .pipe(map(data => {
    //            this.courses = data;
    //            this.connection.invoke("GetUpdateForOrder");

    //            /*this.products = data;*/
    //           /* return;*/
    //        }));
    //}

    get loginRequired(): boolean {
        return this.token.length === 0 || this.expiration > new Date();
    }

    addCourse(course: ICourse) {
        let headers = new HttpHeaders({ 'Access-Control-Allow-Origin': '*', 'content-type': 'application/json' });
        return this.http.post<any>("/api/course", course)
            .pipe(map(data => {
                //this.token = data.token;
                //this.expiration = data.expiration;
            }));
    }


    getCourses(): Observable<ICourse[]> {
        return this.http.get<ICourse[]>('/api/course')
            .pipe(
                catchError(this.handleError)
            );
    }

    getEmployee(id: string): Observable<ICourse> {
        if (id === '') {
            return of(this.initializeCourse());
        }
        const url = `$/api/course/${id}`;
        return this.http.get<ICourse>(url)
            .pipe(
                catchError(this.handleError)
            );
    }

    deleteCourse(id: string): Observable<{}> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        const url = `$/api/course/${id}`;
        return this.http.delete<ICourse>(url, { headers: headers })
            .pipe(
                catchError(this.handleError)
            );
    }

    updateCourse(course: ICourse): Observable<ICourse> {
        debugger
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        const url = `$/api/course/${course.courseId}`;
        return this.http.put<ICourse>(url, course, { headers: headers })
            .pipe(
                map(() => course),
                catchError(this.handleError)
            );
    }

    private handleError(err) {
        let errorMessage: string;
        if (err.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
        }
        console.error(err);
        return throwError(errorMessage);
    }

    private initializeCourse(): ICourse {
        return {
            courseId: 0,
            courseName: "",
            title: "",
            studentCourses: [],
            subjects: [],
            totalTeachers: 0,
            totalStudents: 0,
            averageOfGrades: 0
        };
    }

}