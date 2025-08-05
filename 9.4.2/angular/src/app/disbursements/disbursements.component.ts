import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
 
@Component({
  selector: 'app-disbursements',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './disbursements.component.html',
  styleUrls: ['./disbursements.component.css'],
})
export class DisbursementsComponent {
  searchTerm = '';
  filterType = 'all';
 
  feeTypes = ['Tuition Fee', 'Lab Fee', 'Library Fee', 'Sports Fee', 'Annual Fee', 'Exam Fee'];
 
  transactions = [
    {
      date: '2025-08-01',
      time: '10:30 AM',
      memberName: 'John Doe',
      memberRef: 'MBR001',
      memberId: 'ID1001',
      feeType: 'Tuition Fee',
      amount: 500,
      transactionId: 'TXN123456',
      status: 'Completed',
      paymentMethod: 'Bank Transfer',
    },
    {
      date: '2025-08-01',
      time: '11:15 AM',
      memberName: 'Jane Smith',
      memberRef: 'MBR002',
      memberId: 'ID1002',
      feeType: 'Library Fee',
      amount: 200,
      transactionId: 'TXN123457',
      status: 'Pending',
      paymentMethod: 'UPI',
    },
    {
      date: '2025-08-02',
      time: '09:45 AM',
      memberName: 'Rahul Mehta',
      memberRef: 'MBR003',
      memberId: 'ID1003',
      feeType: 'Lab Fee',
      amount: 300,
      transactionId: 'TXN123458',
      status: 'Completed',
      paymentMethod: 'Cash',
    },
    {
      date: '2025-08-02',
      time: '02:10 PM',
      memberName: 'Aisha Khan',
      memberRef: 'MBR004',
      memberId: 'ID1004',
      feeType: 'Annual Fee',
      amount: 1500,
      transactionId: 'TXN123459',
      status: 'Completed',
      paymentMethod: 'Bank Transfer',
    },
    {
      date: '2025-08-03',
      time: '12:30 PM',
      memberName: 'Michael Brown',
      memberRef: 'MBR005',
      memberId: 'ID1005',
      feeType: 'Sports Fee',
      amount: 250,
      transactionId: 'TXN123460',
      status: 'Failed',
      paymentMethod: 'UPI',
    },
    {
      date: '2025-08-03',
      time: '03:00 PM',
      memberName: 'Sara Ali',
      memberRef: 'MBR006',
      memberId: 'ID1006',
      feeType: 'Exam Fee',
      amount: 400,
      transactionId: 'TXN123461',
      status: 'Pending',
      paymentMethod: 'Cash',
    },
    {
      date: '2025-08-04',
      time: '10:00 AM',
      memberName: 'David Singh',
      memberRef: 'MBR007',
      memberId: 'ID1007',
      feeType: 'Tuition Fee',
      amount: 800,
      transactionId: 'TXN123462',
      status: 'Completed',
      paymentMethod: 'Bank Transfer',
    },
    {
      date: '2025-08-04',
      time: '11:30 AM',
      memberName: 'Priya Sharma',
      memberRef: 'MBR008',
      memberId: 'ID1008',
      feeType: 'Library Fee',
      amount: 100,
      transactionId: 'TXN123463',
      status: 'Completed',
      paymentMethod: 'UPI',
    },
  ];
 
  get filteredTransactions() {
    return this.transactions.filter((t) => {
      const matchesSearch =
        t.memberName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        t.memberRef.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        t.date.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        t.transactionId.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        t.paymentMethod.toLowerCase().includes(this.searchTerm.toLowerCase());
 
      const matchesFilter = this.filterType === 'all' || t.feeType === this.filterType;
 
      return matchesSearch && matchesFilter;
    });
  }
 
  get totalAmount(): number {
    return this.filteredTransactions.reduce((sum, t) => sum + t.amount, 0);
  }
}