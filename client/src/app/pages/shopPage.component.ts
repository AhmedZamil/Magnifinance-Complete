import { Component, OnInit } from "@angular/core";
import { Course } from "../services/course.service";
import { Store } from "../services/store.service";

@Component({
  selector: "shop-page",
  templateUrl: "shopPage.component.html"
})
export class ShopPage {

    constructor(public course: Course) {
    }
    ngOnInit(): void {
        this.course.loadCourses()
            .subscribe(() => {
                // do something
            }); // <- Kicks off the operation
    }

}