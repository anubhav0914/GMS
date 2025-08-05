import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
 
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  totalStudents = 1234;
  totalTeachers = 89;
  todayCollection = 15600;
  saccoBalance = 123456.78;
 
  recentTransactions = [
    {
      name: 'John Doe',
      reference: 'STU001',
      type: 'Tuition Fee',
      amount: 1200,
      date: '2025-08-03'
    },
    {
      name: 'Sarah Wilson',
      reference: 'STU045',
      type: 'Lab Fee',
      amount: 800,
      date: '2025-08-03'
    },
    {
      name: 'Mike Johnson',
      reference: 'STU123',
      type: 'Annual Fee',
      amount: 1500,
      date: '2025-08-02'
    },
    {
      name: 'Emma Davis',
      reference: 'STU089',
      type: 'Sports Fee',
      amount: 600,
      date: '2025-08-02'
    }
  ];
}
 
 