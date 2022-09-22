import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import router from './router';
import { ShopPage } from './pages/shopPage.component';
import { LoginPage } from './pages/loginPage.component';
import { AuthActivator } from './services/authActivator.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Course } from './services/course.service';
import { CoursePage } from './pages/course.component';
import { SubjectPage } from './pages/subject.component';
import { SubjectService } from './services/subject.service';
import { NavBarView } from './views/navbar.component';
import { StudentPage } from './pages/student.component';
import { StudentService } from './services/student.service';
import { SubjectGradePage } from './pages/subjectgrade.component';
import { AddCoursePage } from './forms/addcourse.component';
import { AddSubjectPage } from './forms/addsubject.component';
import { AddStudentPage } from './forms/addstudent.component';
import { GradingPage } from './forms/grading.component';
import { TeacherPage } from './pages/teacher.component';
import { AddTeacherPage } from './forms/addteacher.component';


@NgModule({
    declarations: [
        AppComponent,
        NavBarView,
        ShopPage,
        CoursePage,
        AddCoursePage,
        AddSubjectPage,
        AddStudentPage,
        AddTeacherPage,
        GradingPage,
        SubjectPage,
        SubjectGradePage,
        StudentPage,
        TeacherPage,
        LoginPage
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        router,
        FormsModule
    ],
    providers: [
        Store,
        Course,
        SubjectService,
        StudentService,
        AuthActivator
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
