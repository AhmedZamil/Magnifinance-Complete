import { ICourse } from "./Course";
import { IStudent } from "./Student";

export class IStudentCourse {
    studentCourseId: number;
    note: string;
    studentId: number;
    courseId: number;
    student: IStudent;
    course: ICourse
}