import { ChangeDetectorRef, Component, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent{
  showModal = false;
  showFileModal = false;
  searchTerm = '';
  selectedStudent: any = null;
  showViewModal = false;
  isDragOver = false;
  selectedFile: string | null = null;
  excelFile: File | null = null;

  // constructor(injector: Injector, cd: ChangeDetectorRef) {
  //   super(injector, cd);
  // }

  // ngOnInit(): void {
  //   this.pageSize = 10;
  //   this.pageNumber = 1;
  //   this.initializePagination();
  // }

  // private initializePagination(): void {
  //   const filteredData = this.filteredStudents;
  //   this.totalItems = filteredData.length;
  //   const startIndex = (this.pageNumber - 1) * this.pageSize;
  //   const endIndex = startIndex + this.pageSize;
  //   this.paginatedStudents = filteredData.slice(startIndex, endIndex);

  //   this.showPaging({
  //     totalCount: this.totalItems,
  //     items: this.paginatedStudents
  //   }, this.pageNumber);
  // }


  students = [{
    name: 'John Doe',
    ref: 'STU001',
    email: 'john.doe@email.com',
    phone: '(555) 123-4567',
    guardianName: 'Jane Doe',
    guardianPhone: '(555) 987-6543',
    status: 'Active'
  }, {
    name: 'Sarah Wilson',
    ref: 'STU045',
    email: 'sarah.wilson@email.com',
    phone: '(555) 234-5678',
    guardianName: 'Robert Wilson',
    guardianPhone: '(555) 876-5432',
    status: 'Active'
  }, {
    name: 'Mike Johnson',
    ref: 'STU123',
    email: 'mike.johnson@email.com',
    phone: '(555) 345-6789',
    guardianName: 'Lisa Johnson',
    guardianPhone: '(555) 765-4321',
    status: 'Active'
  }, {
    name: 'Emily Brown',
    ref: 'STU002',
    email: 'emily.brown@email.com',
    phone: '(555) 123-7890',
    guardianName: 'Michael Brown',
    guardianPhone: '(555) 987-1234',
    status: 'Active'
  }, {
    name: 'David Wilson',
    ref: 'STU046',
    email: 'david.wilson@email.com',
    phone: '(555) 234-8901',
    guardianName: 'Susan Wilson',
    guardianPhone: '(555) 876-2345',
    status: 'Active'
  }, {
    name: 'Lisa Johnson',
    ref: 'STU124',
    email: 'lisa.johnson@email.com',
    phone: '(555) 345-9012',
    guardianName: 'James Johnson',
    guardianPhone: '(555) 765-3456',
    status: 'Active'
  }, {
    name: 'Robert Davis',
    ref: 'STU003',
    email: 'robert.davis@email.com',
    phone: '(555) 456-1234',
    guardianName: 'Mary Davis',
    guardianPhone: '(555) 654-9876',
    status: 'Active'
  }, {
    name: 'Jennifer Miller',
    ref: 'STU047',
    email: 'jennifer.miller@email.com',
    phone: '(555) 567-2345',
    guardianName: 'Thomas Miller',
    guardianPhone: '(555) 543-8765',
    status: 'Active'
  }, {
    name: 'William Garcia',
    ref: 'STU125',
    email: 'william.garcia@email.com',
    phone: '(555) 678-3456',
    guardianName: 'Patricia Garcia',
    guardianPhone: '(555) 432-7654',
    status: 'Active'
  }, {
    name: 'Jessica Martinez',
    ref: 'STU004',
    email: 'jessica.martinez@email.com',
    phone: '(555) 789-4567',
    guardianName: 'Daniel Martinez',
    guardianPhone: '(555) 321-6543',
    status: 'Active'
  }, {
    name: 'Christopher Anderson',
    ref: 'STU048',
    email: 'christopher.anderson@email.com',
    phone: '(555) 890-5678',
    guardianName: 'Linda Anderson',
    guardianPhone: '(555) 210-5432',
    status: 'Active'
  }, {
    name: 'Amanda Taylor',
    ref: 'STU126',
    email: 'amanda.taylor@email.com',
    phone: '(555) 901-6789',
    guardianName: 'Kevin Taylor',
    guardianPhone: '(555) 109-4321',
    status: 'Active'
  }, {
    name: 'Matthew Thomas',
    ref: 'STU005',
    email: 'matthew.thomas@email.com',
    phone: '(555) 012-7890',
    guardianName: 'Nancy Thomas',
    guardianPhone: '(555) 098-3210',
    status: 'Active'
  }, {
    name: 'Ashley Jackson',
    ref: 'STU049',
    email: 'ashley.jackson@email.com',
    phone: '(555) 123-8901',
    guardianName: 'Mark Jackson',
    guardianPhone: '(555) 987-2109',
    status: 'Active'
  }, {
    name: 'Joshua White',
    ref: 'STU127',
    email: 'joshua.white@email.com',
    phone: '(555) 234-9012',
    guardianName: 'Karen White',
    guardianPhone: '(555) 876-1098',
    status: 'Active'
  }];

  collections = [{
    id: 1,
    date: '2025-01-15',
    time: '10:30 AM',
    studentRef: 'STU001',
    studentName: 'John Doe',
    class: 'Grade 10A',
    feeType: 'Tuition Fee',
    amount: 1200,
    submissionId: 'SUB202501150001',
    status: 'Paid',
    paymentMethod: 'Bank Transfer'
  }, {
    id: 2,
    date: '2025-01-15',
    time: '02:45 PM',
    studentRef: 'STU045',
    studentName: 'Sarah Wilson',
    class: 'Grade 11B',
    feeType: 'Lab Fee',
    amount: 150,
    submissionId: 'SUB202501150002',
    status: 'Pending',
    paymentMethod: 'Cash'
  }, {
    id: 3,
    date: '2025-01-14',
    time: '09:15 AM',
    studentRef: 'STU123',
    studentName: 'Mike Johnson',
    class: 'Grade 9C',
    feeType: 'Annual Fee',
    amount: 500,
    submissionId: 'SUB202501140001',
    status: 'Paid',
    paymentMethod: 'Bank Transfer'
  }, {
    id: 4,
    date: '2025-01-14',
    time: '03:20 PM',
    studentRef: 'STU089',
    studentName: 'Emma Davis',
    class: 'Grade 10A',
    feeType: 'Sports Fee',
    amount: 100,
    submissionId: 'SUB202501140002',
    status: 'Paid',
    paymentMethod: 'Mobile Money'
  }, {
    id: 5,
    date: '2025-01-13',
    time: '11:00 AM',
    studentRef: 'STU067',
    studentName: 'Lisa Garcia',
    class: 'Grade 11B',
    feeType: 'Library Fee',
    amount: 50,
    submissionId: 'SUB202501130001',
    status: 'Pending',
    paymentMethod: 'Cash'
  }, {
    id: 6,
    date: '2025-01-13',
    time: '04:30 PM',
    studentRef: 'STU134',
    studentName: 'Tom Anderson',
    class: 'Grade 9C',
    feeType: 'Exam Fee',
    amount: 75,
    submissionId: 'SUB202501130002',
    status: 'Paid',
    paymentMethod: 'Bank Transfer'
  }];

  get filteredStudents() {
    if (!this.searchTerm) {
      return this.students;
    }
    return this.students.filter(student =>
      student.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      student.ref.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  newStudent = {
    name: '',
    ref: '',
    email: '',
    phone: '',
    class: '',
    guardianName: '',
    guardianPhone: '',
    status: 'Active'
  };

  // list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
  //   const filteredData = this.filteredStudents;
  //   const startIndex = (pageNumber - 1) * this.pageSize;
  //   const endIndex = startIndex + this.pageSize;
  //   const paginatedData = filteredData.slice(startIndex, endIndex);
  //   this.paginatedStudents = paginatedData;
  //   this.totalItems = filteredData.length;
  //   finishedCallback();
  // }

  currentPage: number = 1;
  pageSize: number = 5;

  get pagedStudents() {
    const start = (this.currentPage - 1) * this.pageSize;
    return this.filteredStudents.slice(start, start + this.pageSize);
  }
 
  get totalPages() {
    return Math.ceil(this.filteredStudents.length / this.pageSize);
  }
 
  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }
  // paginatedStudents: any[] = [];

  // public getDataPage(page: number): void {
  //   this.pageNumber = page;
  //   this.refresh();
  // }

  // onSearchChange(): void {
  //   this.pageNumber = 1;
  //   this.initializePagination();
  // }

  openModal() {
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
    this.resetForm();
  }

  addStudent() {
    const newRef = 'STU' + String(this.students.length + 1).padStart(3, '0');
    const studentToAdd = {
      ...this.newStudent,
      ref: this.newStudent.ref || newRef
    };
    this.students.push(studentToAdd);
    this.closeModal();
  }

  // refresh(): void {
  //   this.totalItems = this.filteredStudents.length;
  //   this.showPaging({ totalCount: this.totalItems, items: this.filteredStudents }, this.pageNumber);
  // }

  // delete(entity: any): void {
  //   const index = this.students.findIndex(s => s.ref === entity.ref);
  //   if (index > -1) {
  //     this.students.splice(index, 1);
  //     const maxPage = Math.ceil(this.filteredStudents.length / this.pageSize);
  //     if (this.pageNumber > maxPage && maxPage > 0) {
  //       this.pageNumber = maxPage;
  //     }
  //     this.initializePagination();
  //   }
  // }

  get selectedStudentTransactions() {
    if (!this.selectedStudent) return [];
    return this.collections.filter(collection => collection.studentRef === this.selectedStudent.ref);
  }

  get totalFee() {
    return this.selectedStudentTransactions.reduce((sum, tx) => sum + tx.amount, 0);
  }

  get pendingFee() {
    return this.selectedStudentTransactions
      .filter(tx => tx.status === 'Pending')
      .reduce((sum, tx) => sum + tx.amount, 0);
  }

  openViewModal(student: any) {
    this.selectedStudent = student;
    this.showViewModal = true;
  }

  closeViewModal() {
    this.showViewModal = false;
    this.selectedStudent = null;
  }

  private resetForm() {
    this.newStudent = {
      name: '',
      ref: '',
      email: '',
      phone: '',
      class: '',
      guardianName: '',
      guardianPhone: '',
      status: 'Active'
    };
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      this.processFile(file);
    }
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragOver = true;
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragOver = false;
  }

  onFileDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragOver = false;
    const files = event.dataTransfer?.files;
    if (files && files.length > 0) {
      this.processFile(files[0]);
    }
  }

  private processFile(file: File): void {
    this.selectedFile = file.name;
    console.log('Processing file:', file.name);
    this.excelFile = file;
    console.log('File type:', file.type);
    console.log('File size:', file.size, 'bytes');
    // this.showFileModal = false;

  }

  addStudentFromFile(): void {
    const reader: FileReader = new FileReader();
    reader.onload = (e: any) => {
      const data = e.target.result;
      const workbook = XLSX.read(data, { type: 'binary' });
      const firstSheetName = workbook.SheetNames[0];
      const worksheet = workbook.Sheets[firstSheetName];
      const jsonData = XLSX.utils.sheet_to_json(worksheet);
      console.log('Parsed data:', jsonData);

      // jsonData.forEach((row: any) => {
      //   if (row.length > 0) {
      //     const newStudent = {
      //       name: row[0],
      //       ref: row[1],
      //       email: row[2],
      //       phone: row[3],
      //       class: row[4],
      //       guardianName: row[5],
      //       guardianPhone: row[6],
      //       status: 'Active'
      //     };
      //     this.students.push(newStudent);
      //   }
      // });

      // this.showFileModal = false;
    };
    reader.readAsBinaryString(this.excelFile);
  }
}