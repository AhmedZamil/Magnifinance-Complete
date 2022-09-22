import { Component, OnInit } from "@angular/core";
import { SubjectService } from "../services/subject.service";

@Component({
    selector: "subject-page",
    templateUrl: "subject.component.html",
    styleUrls: ['subject.component.css']

})
export class SubjectPage implements OnInit {

    constructor(public subjectService: SubjectService) {
    }
    ngOnInit(): void {
        this.subjectService.loadSubjects()
            .subscribe(() => {
                // do something
            }); // <- Kicks off the operation
    }

}