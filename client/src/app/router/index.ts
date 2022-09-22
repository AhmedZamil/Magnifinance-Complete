import { RouterModule } from "@angular/router";
import {  AddCoursePage } from "../forms/addcourse.component";
import { AddStudentPage } from "../forms/addstudent.component";
import { AddSubjectPage } from "../forms/addsubject.component";
import { AddTeacherPage } from "../forms/addteacher.component";
import { GradingPage } from "../forms/grading.component";
import { CoursePage } from "../pages/course.component";
import { LoginPage } from "../pages/loginPage.component";
import { StudentPage } from "../pages/student.component";
import { SubjectPage } from "../pages/subject.component";
import { SubjectGradePage } from "../pages/subjectgrade.component";
import { TeacherPage } from "../pages/teacher.component";
import { AuthActivator } from "../services/authActivator.service";
import { EmployeeDetailComponent } from "../signalr/employee-detail.component";
import { EmployeeEditComponent } from "../signalr/employee-edit.component";
import { EmployeeListComponent } from "../signalr/employee-list.component";

const routes = [
    /*  { path: "", component: ShopPage },*/
    {
        path: 'employees',
        component: EmployeeListComponent
    },
    {
        path: 'employees/:id',
        component: EmployeeDetailComponent
    },
    {
        path: 'employees/:id/edit',
        component: EmployeeEditComponent
    },
    { path: "course", component: CoursePage },
    { path: "grade/:id", component: SubjectGradePage },
    //{ path: "course", component: CoursePage, canActivate: [AuthActivator] },
    { path: "subject", component: SubjectPage },
    { path: "student", component: StudentPage },
    { path: "teacher", component: TeacherPage },
    { path: "addcourse", component: AddCoursePage },
    { path: "addsubject", component: AddSubjectPage },
    { path: "addstudent", component: AddStudentPage },
    { path: "addteacher", component: AddTeacherPage },
    { path: "grading", component: GradingPage },
    { path: "login", component: LoginPage },
    { path: "", redirectTo: "course", pathMatch: 'full' },
    { path: "**", redirectTo: "/" }
];

const router = RouterModule.forRoot(routes, {
    useHash: false
});

export default router;