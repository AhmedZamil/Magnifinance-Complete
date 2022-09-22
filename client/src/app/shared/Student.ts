import { ICourse } from "./Course";
import { IStudentCourse } from "./StudentCourse";
import { ISubjectGrade } from "./SubjectGrade";

export class IStudent {
    studentId: number;
    firstName: string;
    lastName: string;
    age: number;
    studentCourse: IStudentCourse[];
    subjectGrade: ISubjectGrade[]
}



