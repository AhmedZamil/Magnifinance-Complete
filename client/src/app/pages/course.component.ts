import { Component, OnInit } from "@angular/core";
import { Course } from "../services/course.service";

@Component({
    selector: "course-page",
    templateUrl: "course.component.html",
    styleUrls:["course.component.css"]
})
export class CoursePage {

    constructor(public course: Course) {
    }
    ngOnInit(): void {
        this.course.loadCourses()
            .subscribe(() => {
                // do something
            }); // <- Kicks off the operation

        //this.course.useSignalR()
        //    .subscribe(() => {
        //        // do something
        //    }); 
    }

}