import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { SubjectService } from "../services/subject.service";
import { ISubject } from "../shared/Subject";
import { ISubjectGrade } from "../shared/SubjectGrade";

@Component({
    selector: "subjectgrade-page",
    templateUrl: "subjectgrade.component.html",
    styleUrls: ['subjectgrade.component.css']

})
export class SubjectGradePage implements OnInit {

    constructor(public subjectService: SubjectService, private route: ActivatedRoute) {
    }

    public subjectGrade: ISubjectGrade[] = [];
    subject!: ISubject[];
    subjectName: string = "";
    
    
    ngOnInit(): void {


        this.subjectService.loadSubjects()
            .subscribe(() => {
                const subjectid = Number(this.route.snapshot.paramMap.get('id'));
                /*this.subject = this.subjectService.subj.filter(x => x.subjectId === subjectid);*/
                this.subjectName = this.subjectService.subj.find(x => x.subjectId === subjectid).subjectName;
                this.subjectGrade = this.subjectService.subj.find(x => x.subjectId === subjectid).subjectGrade;
                // do something
            }); // <- Kicks off the operation




    }

}