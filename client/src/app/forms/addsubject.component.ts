import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Course } from "../services/course.service";

import { SubjectService } from "../services/subject.service";
import { IAddSubject } from "../shared/addSubject";
import { ICourse } from "../shared/Course";
import { ISubject } from "../shared/Subject";
import { ITeacher } from "../shared/Teacher";

@Component({
    selector: "add-subject",
    templateUrl: "addsubject.component.html",
    styleUrls:["addsubject.component.css"]
})
export class AddSubjectPage implements OnInit {
    constructor(private subjectService: SubjectService, public courseService: Course, private router: Router) { }

    public subject: ISubject = {
        subjectId: 0,
        subjectName: "",
        subjectTitle: "",
        isMajor: false,
        courseId: 0,
        subjectGrade: [],
        course: new ICourse,
        teacherId: 0,
        subjectTeacher: new ITeacher,
        totalStudents: 0,
    };

    public addSubject: IAddSubject = {
        subjectId: 0,
        subjectName: "",
        subjectTitle: "",
        courseId: 0,
        teacherId: 0
    };

  /*  courses: Observable<ICourse[]>;*/

    public errorMessage = "";

    ngOnInit() {
        this.courseService.loadCourses()
            .subscribe(() => {
               
            });

    }

    addsubject() {

        this.addSubject.subjectId = this.subject.subjectId;
        this.addSubject.subjectName = this.subject.subjectName;
        this.addSubject.subjectTitle = this.subject.subjectTitle;
        this.addSubject.courseId = this.subject.courseId;
        this.addSubject.teacherId = 1;


        //subjectId: 0,
        //    subjectName: "",
        //        subjectTitle: "",
        //            courseId: 0,
        //                teacherId: 0
 /*       this.subject.course = this.courseService.courses.find(c => c.courseId == this.subject.courseId);*/
        this.subjectService.addSubject(this.addSubject)
            .subscribe(() => {
                // Successfully added in
                this.router.navigate(['/subject'])
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to add course";
            });
    }
}