import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Course } from "../services/course.service";
import { Store } from "../services/store.service";
import { ICourse, ICreateCourse } from "../shared/Course";
import { LoginRequest } from "../shared/LoginResults";

@Component({
    selector: "add-course",
    templateUrl: "addcourse.component.html",
    styleUrls:["addcourse.component.css"]
})
export class AddCoursePage {
    constructor(private courseService: Course, private router: Router) { }

    public course: ICourse = {
        courseId: 0,
        courseName: "",
        title: "",
        studentCourses: [],
        subjects: [],
        totalTeachers: 0,
        totalStudents: 0,
        averageOfGrades: 0
    };

    public errorMessage = "";

    addcourse() {
        this.courseService.addCourse(this.course)
            .subscribe(() => {
                this.router.navigate(['/course'])
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to add course";
            });
    }
}