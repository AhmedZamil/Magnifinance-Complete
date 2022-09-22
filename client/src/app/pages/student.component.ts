import { Component, OnInit } from "@angular/core";
import { StudentService } from "../services/student.service";

@Component({
    selector: "student-page",
    templateUrl: "student.component.html",
    styleUrls:["student.component.css"]
})
export class StudentPage {

    constructor(public studentService: StudentService) {
    }
    ngOnInit(): void {
        this.studentService.loadStudents()
            .subscribe(() => {
                // do something
            }); // <- Kicks off the operation
    }

}