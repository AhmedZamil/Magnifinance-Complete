import { Component } from "@angular/core";
import { Course } from "../services/course.service";

@Component({
    selector: "nav-bar-view",
    templateUrl: "navbar.component.html"
})
export class NavBarView {
    constructor(public course: Course) {

    }
}