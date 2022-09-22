import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Course } from "../services/course.service";
import { StudentService } from "../services/student.service";

import { SubjectService } from "../services/subject.service";
import { IAddSubject } from "../shared/addSubject";
import { IAddSubjectGrade } from "../shared/AddSubjectGrade";
import { ICourse } from "../shared/Course";
import { IStudent } from "../shared/Student";
import { ISubject } from "../shared/Subject";
import { ISubjectGrade } from "../shared/SubjectGrade";
import { ITeacher } from "../shared/Teacher";

@Component({
    selector: "student-grading",
    templateUrl: "grading.component.html",
    styleUrls:["grading.component.css"]
})
export class GradingPage implements OnInit {
    constructor(public studentService: StudentService,public subjectService: SubjectService, public courseService: Course, private router: Router) { }

    public subjectgrade: ISubjectGrade = {
        subjectGradeId: 0,
        studentId: 0,
        student: new IStudent,
        grade: "",
        gradePoint: 0,
        subjectId: 0,
        subject: new ISubject
    };

    public addsubjectGrade: IAddSubjectGrade = {
        subjectGradeId: 0,
        studentId: 0,
        grade: "",
        gradePoint: 0,
        subjectId: 0
    };

  /*  courses: Observable<ICourse[]>;*/

    public errorMessage = "";

    ngOnInit() {
        this.courseService.loadCourses()
            .subscribe(() => {
                // do something
            });
        this.subjectService.loadSubjects()
            .subscribe(() => {
                // do something
            });
        this.studentService.loadStudents()
            .subscribe(() => {
                // do something
            });

    }

    addsubjectgrade() {

        this.addsubjectGrade.subjectId = this.subjectgrade.subjectId;
        this.addsubjectGrade.subjectGradeId = this.subjectgrade.subjectGradeId;
        this.addsubjectGrade.studentId = this.subjectgrade.studentId;
        this.addsubjectGrade.grade = this.subjectgrade.grade;
        this.addsubjectGrade.gradePoint = this.subjectgrade.gradePoint;


        this.studentService.addSubjectGrade(this.addsubjectGrade)
            .subscribe(() => {
                // Successfully added in
                this.router.navigate(['/student'])
            }, error => {
                console.log(error);
                this.errorMessage = "Failed to add course";
            });
    }
}