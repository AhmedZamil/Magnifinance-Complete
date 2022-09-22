import { Component, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { Course } from "../services/course.service";
import { Store } from "../services/store.service";
import { SubjectService } from "../services/subject.service";
import { ICourse, ICreateCourse } from "../shared/Course";
import { LoginRequest } from "../shared/LoginResults";
import { ITeacher } from "../shared/Teacher";

@Component({
    selector: "add-teacher",
    templateUrl: "addteacher.component.html",
    styleUrls:["addcourse.component.css"]
})
export class AddTeacherPage {
    constructor(private teacherService: SubjectService,
        private router: Router) { }

    public teacher: ITeacher = {
        teacherId: 0,
        firstName: "",
        lastName: "",
        age: 0,
        isActive: false,
        teacherSubjects: []
    };

    public errorMessage = "";

    addteacher() {
        this.teacherService.addTeacher(this.teacher)
            .subscribe(() => {
                this.router.navigate(['/teacher'])
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to add teacher";
            });
    }
}