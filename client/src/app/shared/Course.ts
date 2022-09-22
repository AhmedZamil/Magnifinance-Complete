import { IStudentCourse } from "./StudentCourse";
import { ISubject } from "./Subject";

export class ICourse {
    courseId: number;
    courseName: string;
    title: string;
    studentCourses: IStudentCourse[];
    subjects: ISubject[];
    totalTeachers: number;
    totalStudents: number;
    averageOfGrades: number;
}

export class ICreateCourse {
    courseName: string;
    title: string;
}

