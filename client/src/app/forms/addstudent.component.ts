import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Course } from "../services/course.service";
import { StudentService } from "../services/student.service";

import { SubjectService } from "../services/subject.service";
import { ICourse } from "../shared/Course";
import { IStudent } from "../shared/Student";
import { ISubject } from "../shared/Subject";
import { ITeacher } from "../shared/Teacher";

@Component({
    selector: "add-student",
    templateUrl: "addstudent.component.html",
    styleUrls:["addstudent.component.css"]
})
export class AddStudentPage implements OnInit {
    constructor(private studentService: StudentService,
        private subjectService: SubjectService, public courseService: Course,
        private router: Router) { }

    public student: IStudent = {
        studentId: 0,
        firstName: "",
        lastName: "",
        age: 0,
        studentCourse: [],
        subjectGrade: []
    };

  /*  courses: Observable<ICourse[]>;*/

    public errorMessage = "";

    ngOnInit() {
        this.courseService.loadCourses()
            .subscribe(() => {
                // do something
            });

    }

    addstudent() {
        this.studentService.addStudent(this.student)
            .subscribe(() => {
                this.router.navigate(['/student'])
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to add course";
            });
    }
}