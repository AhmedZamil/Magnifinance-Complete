import { Component, OnInit } from "@angular/core";
import { Course } from "../services/course.service";
import { ICourse } from "../shared/Course";

@Component({
    selector: "course-page",
    templateUrl: "course.component.html",
    styleUrls:["course.component.css"]
})
export class CoursePage {

    public filteredCourses: ICourse[] = [];
    courses: ICourse[] = [];
    errorMessage = '';

    _listFilter = '';
    get listFilter(): string {
        return this._listFilter;
    }
    set listFilter(value: string) {
        this._listFilter = value;
        this.filteredCourses = this.listFilter ? this.performFilter(this.listFilter) : this.courseService.courses;
    }

    constructor(public courseService: Course) {
    }


    performFilter(filterBy: string): ICourse[] {
        filterBy = filterBy.toLocaleLowerCase();
        return this.courseService.courses.filter((course: ICourse) =>
            course.courseName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }
    ngOnInit(): void {
        this.courseService.loadCourses()
            .subscribe(() => {
                this.filteredCourses = this.courseService.courses;
                // do something
            }); // <- Kicks off the operation

        //this.course.useSignalR()
        //    .subscribe(() => {
        //        // do something
        //    }); 
    }

    deleteCourse(id: string, name: string): void {
        if (id === '') {
            this.onSaveComplete();
        } else {
            if (confirm(`Are you sure want to delete this Employee: ${name}?`)) {
                this.courseService.deleteCourse(id)
                    .subscribe(
                        () => this.onSaveComplete(),
                        (error: any) => this.errorMessage = <any>error
                    );
            }
        }
    }

    onSaveComplete(): void {
        this.courseService.getCourses().subscribe(
            employees => {
                this.courses = employees;
                this.filteredCourses = this.courses;
            },
            error => this.errorMessage = <any>error
        );
    }

}