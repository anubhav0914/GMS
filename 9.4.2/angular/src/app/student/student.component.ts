import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { GroupParticipantProxy } from "../../../openapi-proxy/api/groupParticipant.service";
import { MemberType } from "../../../openapi-proxy/model/memberType";
@Component({
  selector: "app-students",
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.css"],
})
export class StudentComponent implements OnInit {
  constructor(private groupParticipantProxy: GroupParticipantProxy) {}

  showModal = false;
  isEditMode = false;
  editIndex: number | null = null;

  currentPage = 1;
  itemsPerPage = 10;

  students: any[] = [];

  ngOnInit(): void {
    this.loadStudents();
    console.log("studet",this.students)
  }

  loadStudents(): void {
    this.groupParticipantProxy
      .apiServicesAppGroupParticipantGetParticipantsGet(0,null, 1)
      .subscribe({
       next: (res) => {
  console.log("API Response:", res?.result);
  this.students = res.result["result"] ?? [];
  console.log(this.students["result"])
  // this.students = Array.isArray(res.result)
  //   ? res.result.map((s: any) => ({
  //       name: s.userName,
  //       ref: s.groupMemberRefNO,
  //       email: s.email,
  //       phone: s.phoneNumber,
  //     }))
  //   : [];
},
        error: (err) => {
          console.error("Failed to load students:", err);
        },
      });
  }

  get paginatedStudents() {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    return this.students.slice(start, start + this.itemsPerPage);
  }

  get totalPages() {
    return Math.ceil(this.students.length / this.itemsPerPage);
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  newStudent = {
    userName: "",
    memberType: "Student",
    email: "",
    phoneNumber: "",
    groupId: "",
  };

  openModal() {
    this.newStudent = {
      userName: "",
      memberType: "Student",
      email: "",
      phoneNumber: "",
      groupId: "",
    };
    this.isEditMode = false;
    this.editIndex = null;
    this.showModal = true;
  }

  openEditModal(student: any, index: number) {
    this.isEditMode = true;
    this.editIndex = index;
    this.newStudent = {
      userName: student.name,
      memberType: "Student",
      email: student.email,
      phoneNumber: student.phone,
      groupId: student.ref,
    };
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
    this.isEditMode = false;
    this.editIndex = null;
  }

 addStudent() {
  if (this.isEditMode && this.editIndex !== null) {
    const updatedStudentPayload = {
      userName: this.newStudent.userName,
      email: this.newStudent.email,
      phoneNumber: this.newStudent.phoneNumber,
      memberType: MemberType.NUMBER_1,
      groupId: 1,
    };

    this.groupParticipantProxy
      .apiServicesAppGroupParticipantUpdateParticipantsPut(updatedStudentPayload)
      .subscribe({
        next: () => {
          alert("Student updated successfully!");
          this.loadStudents(); // Refresh updated list
          this.closeModal();
        },
        error: (err) => {
          console.error("Failed to update student:", err);
          alert("Failed to update student. Please try again.");
        }
      });
  } else {
    this.groupParticipantProxy
      .apiServicesAppGroupParticipantCreateGroupParticipantPost( MemberType.NUMBER_0,
    1,
    this.newStudent.userName,
    this.newStudent.email,
    this.newStudent.phoneNumber)
      .subscribe({
        next: (res) => {
          alert("Student added successfully!");
          this.loadStudents();
          this.closeModal();
          console.log(res);
        },
        error: (err) => {
          console.error("Failed to add student:", err);
          alert("Failed to add student. Please try again.");
        }
      });
  }
}



  deleteStudent(index: number) {
  const student = this.students[index];

  if (confirm("Are you sure you want to delete this student?")) {
    this.groupParticipantProxy
      .apiServicesAppGroupParticipantDeleteParticipantsDelete(student.ref)
      .subscribe({
        next: () => {
          alert("Student deleted successfully!");
          this.students.splice(index, 1);
          if ((this.currentPage - 1) * this.itemsPerPage >= this.students.length) {
            this.currentPage = Math.max(this.currentPage - 1, 1);
          }
        },
        error: (err) => {
          console.error("Failed to delete student:", err);
          alert("Failed to delete student. Please try again.");
        },
      });
  }
}

}
