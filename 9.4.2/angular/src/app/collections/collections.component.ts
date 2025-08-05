import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
 
@Component({
  selector: 'app-collections',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './collections.component.html',
  styleUrls: ['./collections.component.css']
})
export class CollectionsComponent {
  searchTerm: string = '';
  filterType: string = 'all';
 
  submissions = [
    {
      id: 1,
      date: '2025-01-15',
      time: '10:30 AM',
      studentRef: 'STU001',
      studentName: 'John Doe',
      class: 'Grade 10A',
      feeType: 'Tuition Fee',
      amount: 1200,
      submissionId: 'SUB202501150001',
      status: 'Submitted to SACCO',
      paymentMethod: 'Bank Transfer'
    },
    {
      id: 2,
      date: '2025-01-15',
      time: '02:45 PM',
      studentRef: 'STU045',
      studentName: 'Sarah Wilson',
      class: 'Grade 11B',
      feeType: 'Lab Fee',
      amount: 150,
      submissionId: 'SUB202501150002',
      status: 'Submitted to SACCO',
      paymentMethod: 'Cash'
    },
    {
      id: 3,
      date: '2025-01-14',
      time: '09:15 AM',
      studentRef: 'STU123',
      studentName: 'Mike Johnson',
      class: 'Grade 9C',
      feeType: 'Annual Fee',
      amount: 500,
      submissionId: 'SUB202501140001',
      status: 'Submitted to SACCO',
      paymentMethod: 'Bank Transfer'
    },
    {
      id: 4,
      date: '2025-01-14',
      time: '03:20 PM',
      studentRef: 'STU089',
      studentName: 'Emma Davis',
      class: 'Grade 10A',
      feeType: 'Sports Fee',
      amount: 100,
      submissionId: 'SUB202501140002',
      status: 'Submitted to SACCO',
      paymentMethod: 'Mobile Money'
    },
    {
      id: 5,
      date: '2025-01-13',
      time: '11:00 AM',
      studentRef: 'STU067',
      studentName: 'Lisa Garcia',
      class: 'Grade 11B',
      feeType: 'Library Fee',
      amount: 50,
      submissionId: 'SUB202501130001',
      status: 'Submitted to SACCO',
      paymentMethod: 'Cash'
    },
    {
      id: 6,
      date: '2025-01-13',
      time: '04:30 PM',
      studentRef: 'STU134',
      studentName: 'Tom Anderson',
      class: 'Grade 9C',
      feeType: 'Exam Fee',
      amount: 75,
      submissionId: 'SUB202501130002',
      status: 'Submitted to SACCO',
      paymentMethod: 'Bank Transfer'
    }
  ];
 
  get filteredSubmissions() {
    return this.submissions.filter(submission => {
      const term = this.searchTerm.toLowerCase();
      const matchesSearch =
        submission.date.toLowerCase().includes(term) ||
        submission.studentRef.toLowerCase().includes(term) ||
        submission.submissionId.toLowerCase().includes(term) ||
        submission.paymentMethod.toLowerCase().includes(term);
 
      if (this.filterType === 'all') return matchesSearch;
 
      return (
        matchesSearch &&
        submission.feeType.toLowerCase().includes(this.filterType.toLowerCase())
      );
    });
  }
 
  get totalAmount(): number {
    return this.filteredSubmissions.reduce((sum, submission) => sum + submission.amount, 0);
  }
 
  onSearchChange(event: any) {
    this.searchTerm = event.target.value;
  }
 
  onFilterChange(event: any) {
    this.filterType = event.target.value;
  }
 
  onExport() {
    // Placeholder for export logic
    console.log('Export clicked!');
  }
}