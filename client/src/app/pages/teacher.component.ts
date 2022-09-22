import { Component, OnInit } from "@angular/core";
import { SubjectService } from "../services/subject.service";

@Component({
    selector: "teacher-page",
    templateUrl: "teacher.component.html",
    styleUrls: ['Teacher.component.css']

})
export class TeacherPage implements OnInit {

    constructor(public teacherService: SubjectService) {
    }
    ngOnInit(): void {
        this.teacherService.loadTeachers()
            .subscribe(() => {
                // this.router.navigate(['/events'])
                // do something
            }); // <- Kicks off the operation
    }

}